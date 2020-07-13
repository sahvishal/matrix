using System;
using System.Configuration;
using System.Web.UI;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Domain;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Marketing;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Repositories.Users;
using System.IO;
using File = Falcon.App.Core.Application.Domain.File;

namespace Falcon.App.UI.App.Customer
{
    public partial class MyTestimony : Page
    {
        private readonly string _physicalPath = ConfigurationManager.AppSettings["PathInDB"];
        private readonly string _virtualPath = ConfigurationManager.AppSettings["PathToVIEW"];

        protected long CustomerId
        {
            get
            {
                if (ViewState["CustomerId"] == null) ViewState["CustomerId"] = 0;
                return Convert.ToInt64(ViewState["CustomerId"]);
            }
            set { ViewState["CustomerId"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            var objMaster = (Customer_CustomerMaster)Master;
            objMaster.SetBreadcrumb = "My Testimony";
            objMaster.SetPageView("Testimonial");
            if (!Page.IsPostBack)
            {
                // set customerid
                SetCustomerId();
                if (Session["LastLoginTime"] != null && Session["LastLoginTime"].ToString().Trim() != "")
                    spLastLogin.InnerText = "Last login: " + Convert.ToDateTime(Session["LastLoginTime"].ToString()).ToString("MMMM dd, yyyy, hh:mm tt");
                else
                    divLastLogin.Visible = false;
            }
        }

        public void SetName(object sender, EventArgs e) { }

        private void SaveTestimonial()
        {
            ITestimonialRepository testimonialRepository = new TestimonialRepository();
            Testimonial testimonial;

            // set testimonial and file id - update
            if (ViewState["TestimonialId"] != null)
            {
                testimonial = testimonialRepository.GetTestimonial(Convert.ToInt64(ViewState["TestimonialId"]));
                testimonial.TestimonialText = _testimonialText.Text;
            }
            else
            {
                testimonial = new Testimonial
                                  {
                                      CustomerId = CustomerId,
                                      IsAccepted = null,
                                      Rank = null,
                                      ReviewedBy = null,
                                      ReviewedOn = null,
                                      TestimonialText = _testimonialText.Text
                                  };
            }
            // upload vedio
            string savePathPhysical = _physicalPath + "Testimonial";
            string savePathVirtual = _virtualPath + "Testimonial";

            if (_uploadVedio.HasFile && _uploadVedio.FileName.Trim().Length > 0)
            {
                if (!Directory.Exists(savePathPhysical))
                    Directory.CreateDirectory(savePathPhysical);

                string fileExtension = new FileInfo(_uploadVedio.FileName).Extension;
                string fileName = "Testimonial_" + CustomerId + "_" + DateTime.Now.ToFileTimeUtc() + "_" + _uploadVedio.FileName;

                _uploadVedio.SaveAs(savePathPhysical + "\\" + fileName);

                if (testimonial.TestimonialVideo != null && testimonial.TestimonialVideo.Id > 0)
                {
                    testimonial.TestimonialVideo = new File(testimonial.TestimonialVideo.Id)
                                                   {
                                                       Path = savePathVirtual + "/" + fileName,
                                                       FileSize = (decimal)_uploadVedio.FileBytes.Length / 1024,
                                                       Type = FileType.Video,
                                                       UploadedBy = GetCreatorOrganizationRoleUser(),
                                                       UploadedOn = DateTime.Now
                                                   };
                }
                else
                {
                    testimonial.TestimonialVideo = new File
                                                       {
                                                           Path = savePathVirtual + "/" + fileName,
                                                           FileSize = (decimal)_uploadVedio.FileBytes.Length / 1024,
                                                           Type = FileType.Video,
                                                           UploadedBy = GetCreatorOrganizationRoleUser(),
                                                           UploadedOn = DateTime.Now
                                                       };
                }
            }

            testimonial = testimonialRepository.SaveTestimonial(testimonial);

            _divMessage.Style.Add(HtmlTextWriterStyle.Display, "block");
            if (testimonial.Id > 0)
            {
                ViewState["TestimonialId"] = testimonial.Id;
                _messageControl.ShowSuccessMessage("Testimonial Submitted Successfully for Review.");
            }
            else
            {
                _messageControl.ShowErrorMessage("Testimonial has not been submitted, Please try again.");
                ViewState["TestimonialId"] = null;
            }
        }

        private OrganizationRoleUser GetCreatorOrganizationRoleUser()
        {
            return IoC.Resolve<IOrgRoleUserModelBinder>().ToDomain(
                        IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole,
                        IoC.Resolve<ISessionContext>().UserSession.UserId);
        }

        private void SetCustomerId()
        {
            
            long userId = Convert.ToInt64(IoC.Resolve<ISessionContext>().UserSession.UserId);
            if (userId > 0)
            {
                ICustomerRepository customerRepository = new CustomerRepository();
                var customer = customerRepository.GetCustomerByUserId(userId);
                CustomerId = customer.CustomerId;
            }
        }

        protected void _uploadVedioButton_Click(object sender, EventArgs e)
        {
            ITestimonialRepository testimonialRepository = new TestimonialRepository();

            var testimonial = new Testimonial
                                  {
                                      CustomerId = CustomerId,
                                      IsAccepted = null,
                                      Rank = null,
                                      ReviewedBy = null,
                                      ReviewedOn = null,
                                      TestimonialText = string.Empty
                                  };
            
            // upload vedio
            string savePathPhysical = _physicalPath + "Testimonial";
            string savePathVirtual = _virtualPath + "Testimonial";

            if (_uploadVedio.HasFile && _uploadVedio.FileName.Trim().Length > 0)
            {
                if (!Directory.Exists(savePathPhysical))
                    Directory.CreateDirectory(savePathPhysical);

                string fileExtension = new FileInfo(_uploadVedio.FileName).Extension;
                string fileName = "Testimonial_" + CustomerId + "_" + DateTime.Now.ToFileTimeUtc() + "_" + _uploadVedio.FileName;

                _uploadVedio.SaveAs(savePathPhysical + "\\" + fileName);

                testimonial.TestimonialVideo = new File
                                                   {
                                                       Path = savePathVirtual + "/" + fileName,
                                                       FileSize = (decimal) _uploadVedio.FileBytes.Length/1024,
                                                       Type = FileType.Video,
                                                       UploadedBy = GetCreatorOrganizationRoleUser(),
                                                       UploadedOn = DateTime.Now
                                                   };
               
            }
            testimonial = testimonialRepository.SaveTestimonial(testimonial);

            _divMessage.Style.Add(HtmlTextWriterStyle.Display, "block");
            if (testimonial.Id > 0)
                _messageControl.ShowSuccessMessage("Testimonial submitted successfully for review.");
            else
                _messageControl.ShowErrorMessage("Testimonial has not been submitted, Please try again.");
        }

        protected void _submitButton_Click(object sender, EventArgs e)
        {
            ITestimonialRepository testimonialRepository = new TestimonialRepository();
            var testimonial = new Testimonial
                                  {
                                      CustomerId = CustomerId,
                                      IsAccepted = null,
                                      Rank = null,
                                      ReviewedBy = null,
                                      ReviewedOn = null,
                                      TestimonialText = _testimonialText.Text
                                  };
            
            testimonial = testimonialRepository.SaveTestimonial(testimonial);

            _divMessage.Style.Add(HtmlTextWriterStyle.Display, "block");
            if (testimonial.Id > 0)
            {
                _messageControl.ShowSuccessMessage("Testimonial submitted successfully for review.");
                _testimonialText.Text = string.Empty;
            }
            else
                _messageControl.ShowErrorMessage("Testimonial has not been submitted, Please try again.");
        }
    }
}
