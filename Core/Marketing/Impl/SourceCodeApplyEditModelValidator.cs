using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Marketing.Domain;
using Falcon.App.Core.Marketing.Enum;
using Falcon.App.Core.Marketing.Interfaces;
using Falcon.App.Core.Marketing.ViewModels;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Scheduling.Interfaces;
using FluentValidation;
using FluentValidation.Results;
using FluentValidation.Validators;

namespace Falcon.App.Core.Marketing.Impl
{
    [DefaultImplementation(Interface = typeof(IValidator<SourceCodeApplyEditModel>))]
    public class SourceCodeApplyEditModelValidator : AbstractValidator<SourceCodeApplyEditModel>
    {
        public SourceCodeApplyEditModelValidator(ISourceCodeRepository sourceCodeRepository, IEventCustomerRepository eventCustomerRepository, ISourceCodeOrderDetailRepository sourceCodeOrderDetailRepository, IConfigurationSettingRepository configurationSettingRepository)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.SourceCode).NotNull().WithMessage("Source Code can't be empty!").NotEmpty().WithMessage(
                "Source Code can't be empty!").SetValidator(new IsValidCode(sourceCodeRepository, sourceCodeOrderDetailRepository, eventCustomerRepository, configurationSettingRepository));
        }
    }
    //Not used
    //class IsValidCodeRule : IValidationRule<SourceCodeApplyEditModel>
    //{
    //    private ISourceCodeRepository _sourceCodeRepository;
    //    private SourceCode _sourceCode;

    //    public IsValidCodeRule(ISourceCodeRepository sourceCodeRepository)
    //    {
    //        _sourceCodeRepository = sourceCodeRepository;
    //    }

    //    public IEnumerable<ValidationFailure> Validate(ValidationContext<SourceCodeApplyEditModel> context)
    //    {
    //        var instance = context.InstanceToValidate;
    //        if (instance != null && !string.IsNullOrEmpty(instance.SourceCode))
    //            _sourceCode = _sourceCodeRepository.GetSourceCodeByCode(instance.SourceCode.Trim());

    //        var validators = new List<ValidationFailure>();

    //        var validator = IsValidSourceCode();
    //        if (validator != null)
    //            validators.Add(validator);

    //        validator = IsValidValidityStartDate();
    //        if (validator != null)
    //            validators.Add(validator);

    //        validator = IsValidValidityEndDate();
    //        if (validator != null)
    //            validators.Add(validator);

    //        return validators;
    //    }

    //    public IEnumerable<ValidationFailure> Validate(ValidationContext context)
    //    {
    //        if (context != null && context is ValidationContext<SourceCodeApplyEditModel>)
    //            return Validate(context as ValidationContext<SourceCodeApplyEditModel>);

    //        return null;
    //    }

    //    public IEnumerable<IPropertyValidator> Validators
    //    {
    //        get { throw new NotImplementedException(); }
    //    }

    //    public ValidationFailure IsValidSourceCode()
    //    {
    //        return (_sourceCode != null ? null : new ValidationFailure("Source Code", " Invalid Source Code! "));
    //    }

    //    public ValidationFailure IsValidValidityStartDate()
    //    {
    //        if (_sourceCode == null) return new ValidationFailure("Source Code", " Invalid Source Code! ");
    //        return _sourceCode.ValidityStartDate <= DateTime.Now.Date ? null : new ValidationFailure("Source Code", " Invalid Source Code! ");
    //    }

    //    public ValidationFailure IsValidValidityEndDate()
    //    {
    //        if (_sourceCode == null) return new ValidationFailure("Source Code", " Invalid Source Code! ");

    //        if (!_sourceCode.ValidityEndDate.HasValue || _sourceCode.ValidityEndDate.Value >= DateTime.Now.Date)
    //            return null;

    //        return new ValidationFailure("Source Code", " Invalid Source Code! ");
    //    }
    //}

    class IsValidCode : PropertyValidator
    {
        private ISourceCodeRepository _sourceCodeRepository;
        private ISourceCodeOrderDetailRepository _sourceCodeOrderDetailRepository;
        private IEventCustomerRepository _eventCustomerRepository;
        private SourceCode _sourceCode;
        private string _message;
        private string _sourceCodelabel;

        private IEnumerable<Func<bool>> _isValidatorList;
        private IEnumerable<Func<SourceCodeApplyEditModel, bool>> _isParemterizedValidatorList;

        public IsValidCode(ISourceCodeRepository sourceCodeRepository, ISourceCodeOrderDetailRepository sourceCodeOrderDetailRepository, IEventCustomerRepository eventCustomerRepository, IConfigurationSettingRepository configurationSettingRepository)
            : base("")
        {
            _sourceCodeOrderDetailRepository = sourceCodeOrderDetailRepository;
            _sourceCodeRepository = sourceCodeRepository;
            _eventCustomerRepository = eventCustomerRepository;
            _sourceCodelabel =
                configurationSettingRepository.GetConfigurationValue(ConfigurationSettingName.SourceCodeLabel);
            _sourceCodelabel = String.IsNullOrEmpty(_sourceCodelabel) ? "Coupon Code" : _sourceCodelabel;

            _message = "";

            _isValidatorList = new Func<bool>[] { IsValidSourceCode, IsValidValidityStartDate, IsValidValidityEndDate };
            _isParemterizedValidatorList = new Func<SourceCodeApplyEditModel, bool>[] { IsValidCustomerType, IsValidForMinimumPurchaseAmount, IsValidForMaximumUsageCount, IsValidPackage, IsValidProduct, IsValidShippingMode, IsValidSignUpMode, IsValidEvent };
        }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            if (context.Instance == null || !(context.Instance is SourceCodeApplyEditModel)) return false;

            var instance = context.Instance as SourceCodeApplyEditModel;

            if (!string.IsNullOrEmpty(instance.SourceCode))
                _sourceCode = _sourceCodeRepository.GetSourceCodeByCode(instance.SourceCode.Trim());

            foreach (var func in _isValidatorList)
            {
                var result = func();
                if (!result) return false;
            }

            foreach (var func in _isParemterizedValidatorList)
            {
                var result = func(instance);
                if (!result) return false;
            }
            // TODO: To Apply Existing Customer/New Customer Check
            return true;
        }

        protected override ValidationFailure CreateValidationError(PropertyValidatorContext context)
        {
            return new ValidationFailure(context.PropertyName, _message);
        }

        private bool IsValidSourceCode()
        {
            _message = "Invalid " + _sourceCodelabel + "!";
            return _sourceCode != null;
        }

        private bool IsValidValidityStartDate()
        {
            _message = _sourceCodelabel + " is applicable from " + _sourceCode.ValidityStartDate.ToShortDateString();
            return _sourceCode.ValidityStartDate <= DateTime.Now.Date;
        }

        private bool IsValidValidityEndDate()
        {
            _message = "This " + _sourceCodelabel + " has expired";
            return ((!_sourceCode.ValidityEndDate.HasValue) || _sourceCode.ValidityEndDate.Value >= DateTime.Now.Date);
        }

        private bool IsValidForMaximumUsageCount(SourceCodeApplyEditModel instance)
        {
            var count = _sourceCodeOrderDetailRepository.GetSourceCodeUsageCount(_sourceCode.Id);
            bool repeatForCustomer = false;
            if (instance.CustomerId > 0 && instance.EventId > 0)
            {
                repeatForCustomer = _sourceCodeOrderDetailRepository.IsSourceCodeAppliedforGivenEventCustomer(_sourceCode.Id, instance.EventId, instance.CustomerId);
            }

            _message = "This " + _sourceCodelabel + " has reached its maximum usage count!";
            return _sourceCode.MaximumNumberTimesUsed < 1 || _sourceCode.MaximumNumberTimesUsed > count || repeatForCustomer;
        }

        private bool IsValidCustomerType(SourceCodeApplyEditModel instance)
        {
            if ((int)_sourceCode.CustomerType > 0)
            {
                if (instance.CustomerId == 0 && _sourceCode.CustomerType == CustomerType.New) return true;

                var eventCustomers = _eventCustomerRepository.GetbyCustomerId(instance.CustomerId);
                if (_sourceCode.CustomerType == CustomerType.New && (eventCustomers == null || eventCustomers.Count() < 1 || eventCustomers.Where(ec => ec.TestConducted).Count() < 1))
                    return true;

                if (_sourceCode.CustomerType == CustomerType.Existing && eventCustomers != null && eventCustomers.Count() > 0 && eventCustomers.Where(ec => ec.TestConducted).Count() > 0)
                    return true;

                _message = _sourceCode.CustomerType == CustomerType.Existing ? "This " + _sourceCodelabel + " is applicable to Existing Customers only (i.e. who have atleast attended one screening Event)." : "This " + _sourceCodelabel + " is applicable to New Customers only.";
                return false;
            }

            return true;
        }

        private bool IsValidForMinimumPurchaseAmount(SourceCodeApplyEditModel instance)
        {
            _message = string.Format("This " + _sourceCodelabel + " is applicable on Minimum Purchase Amount (${0}).",
                _sourceCode.MinimumPurchaseAmount != null ? _sourceCode.MinimumPurchaseAmount.Value.ToString("0.00") : "");

            return _sourceCode.MinimumPurchaseAmount == null || _sourceCode.MinimumPurchaseAmount.Value == 0 || (_sourceCode.MinimumPurchaseAmount.Value > 0 && _sourceCode.MinimumPurchaseAmount.Value <= instance.OrderTotal);
        }

        private bool IsValidPackage(SourceCodeApplyEditModel instance)
        {
            bool isValid = false;
            if (_sourceCode.DiscountType != DiscountType.PerPackage) return true;

            if (_sourceCode.PackageDiscounts != null && _sourceCode.PackageDiscounts.Count() > 0 && instance.Package != null)
            {
                var package = _sourceCode.PackageDiscounts.Where(pd => pd.Id == instance.Package.FirstValue).SingleOrDefault();
                isValid = package != null;
            }

            if (_sourceCode.TestDiscounts != null && _sourceCode.TestDiscounts.Count() > 0 && instance.SelectedTests != null)
            {
                var tests = _sourceCode.TestDiscounts.Where(td => instance.SelectedTests.Select(i => i.FirstValue).Contains(td.Id)).ToArray();
                isValid = tests.Count() > 0;
            }

            if (!isValid)
            {
                _message = _sourceCodelabel + " is not applicable to the selected Package/Test Type.";
                return false;
            }

            return true;
        }

        private bool IsValidProduct(SourceCodeApplyEditModel instance)
        {
            bool isValid = false;
            if (_sourceCode.DiscountType != DiscountType.PerProduct) return true;

            if (_sourceCode.ProductDiscounts != null && _sourceCode.ProductDiscounts.Count() > 0 && instance.SelectedProducts != null)
            {
                var product = _sourceCode.ProductDiscounts.Where(pd => instance.SelectedProducts.Select(i => i.FirstValue).Contains(pd.Id)).SingleOrDefault();
                isValid = product != null;
            }

            if (!isValid)
            {
                _message = _sourceCodelabel + " is not applicable to the selected Product.";
                return false;
            }

            return true;
        }

        private bool IsValidShippingMode(SourceCodeApplyEditModel instance)
        {
            bool isValid = false;
            if (_sourceCode.DiscountType != DiscountType.PerShipping) return true;

            if (_sourceCode.ShippingDiscounts != null && _sourceCode.ShippingDiscounts.Count() > 0 && instance.SelectedShipping != null)
            {
                var product = _sourceCode.ShippingDiscounts.Where(sd => instance.SelectedShipping.Select(i => i.FirstValue).Contains(sd.Id)).SingleOrDefault();
                isValid = product != null;
            }

            if (!isValid)
            {
                _message = _sourceCodelabel + " is not applicable to the selected Shipping Mode.";
                return false;
            }

            return true;
        }

        private bool IsValidSignUpMode(SourceCodeApplyEditModel instance)
        {
            if (_sourceCode.SelectedSignUpModes == null || _sourceCode.SelectedSignUpModes.Count() < 1) return true;

            var count = _sourceCode.SelectedSignUpModes.Where(sm => (int)sm == instance.SignUpMode).Count();
            _message = "Invalid " + _sourceCodelabel + "!";
            return count > 0;
        }

        private bool IsValidEvent(SourceCodeApplyEditModel instance)
        {
            if (_sourceCode.EventIds == null || _sourceCode.EventIds.Count() < 1)
                return true;

            if (_sourceCode.EventIds.Contains(instance.EventId))
                return true;
            _message = "This " + _sourceCodelabel + " is not applicable for the selected event.";
            return false;
        }

    }

}