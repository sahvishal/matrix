using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Falcon.App.Core;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Helper;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.ViewModels;

namespace Falcon.App.Infrastructure.Scheduling.Impl
{
    [DefaultImplementation]
    public class AppointmentBookedExportCsvHelper : IAppointmentBookedExportCsvHelper
    {
        public void WriteCsv(IEnumerable<AppointmentsBookedModel> modelData, string fileName, ILogger logger)
        {
            logger.Info("Writing CSV file " + fileName);
            DirectoryOperationsHelper.DeleteFileIfExist(fileName);

            var fileWriter = new StreamWriter(fileName);

            try
            {
                var members = (typeof(AppointmentsBookedModel)).GetMembers();

                var header = new List<string>();

                foreach (var memberInfo in members)
                {
                    if (memberInfo.MemberType != MemberTypes.Property)
                        continue;

                    var propInfo = (memberInfo as PropertyInfo);

                    if (propInfo != null)
                    {
                        if (propInfo.PropertyType == typeof(FeedbackMessageModel) || propInfo.PropertyType == typeof(IEnumerable<OrderedPair<string, string>>))
                            continue;
                    }
                    else
                        continue;

                    var propertyName = memberInfo.Name;
                    var isHidden = false;

                    var attributes = propInfo.GetCustomAttributes(false);

                    if (!attributes.IsNullOrEmpty())
                    {
                        foreach (var attribute in attributes)
                        {
                            if (attribute is HiddenAttribute)
                            {
                                isHidden = true;
                                break;
                            }
                            if (attribute is DisplayNameAttribute)
                            {
                                propertyName = (attribute as DisplayNameAttribute).DisplayName;
                            }
                        }
                    }

                    if (isHidden) continue;

                    header.Add(propertyName);
                }
                header.Add("Additional Fields");
                fileWriter.WriteLine(string.Join(",", header.ToArray()));

                var sanitizer = new CSVSanitizer();


                foreach (var model in modelData)
                {
                    var values = new List<string>();
                    foreach (var memberInfo in members)
                    {
                        if (memberInfo.MemberType != MemberTypes.Property)
                            continue;

                        var propInfo = (memberInfo as PropertyInfo);
                        if (propInfo != null)
                        {
                            if (propInfo.PropertyType == typeof(FeedbackMessageModel) || propInfo.PropertyType == typeof(IEnumerable<OrderedPair<string, string>>))
                                continue;
                            if (propInfo.PropertyType == typeof(IEnumerable<string>))
                            {
                                if (model.ShippingOptions != null && model.ShippingOptions.Any())
                                {
                                    var shippingOptions = string.Join(", \n", model.ShippingOptions.ToArray());
                                    values.Add(sanitizer.EscapeString(shippingOptions));
                                }
                                else
                                {
                                    values.Add(string.Empty);
                                }
                                continue;
                            }

                            if (propInfo.PropertyType == typeof(IEnumerable<RescheduleApplointmentModel>))
                            {
                                if (model.RescheduleInfo != null && model.RescheduleInfo.Any())
                                {
                                    var rescheduleInfoString = string.Empty;
                                    foreach (var rescheduleInfo in model.RescheduleInfo)
                                    {
                                        rescheduleInfoString += "Rescheduled By: " + rescheduleInfo.RescheduledBy + "\n";
                                        rescheduleInfoString += "Reason: " + rescheduleInfo.Reason + "\n";
                                        if (!string.IsNullOrEmpty(rescheduleInfo.SubReason))
                                            rescheduleInfoString += "SubReason: " + rescheduleInfo.SubReason + "\n";
                                        if (!string.IsNullOrEmpty(rescheduleInfo.Notes))
                                            rescheduleInfoString += "Notes: " + rescheduleInfo.Notes + "\n";
                                        rescheduleInfoString += "---------------------------\n";
                                    }
                                    values.Add(sanitizer.EscapeString(rescheduleInfoString));
                                }
                                else
                                {
                                    values.Add("N/A");
                                }
                                continue;
                            }
                        }
                        else
                            continue;


                        bool isHidden = false;
                        FormatAttribute formatter = null;

                        var attributes = propInfo.GetCustomAttributes(false);
                        if (!attributes.IsNullOrEmpty())
                        {
                            foreach (var attribute in attributes)
                            {
                                if (attribute is HiddenAttribute)
                                {
                                    isHidden = true;
                                    break;
                                }
                                if (attribute is FormatAttribute)
                                {
                                    formatter = (FormatAttribute)attribute;
                                }
                            }
                        }

                        if (isHidden) continue;
                        var obj = propInfo.GetValue(model, null);
                        if (obj == null)
                            values.Add(string.Empty);
                        else if (formatter != null)
                            values.Add(formatter.ToString(obj));
                        else
                            values.Add(sanitizer.EscapeString(obj.ToString()));

                    }

                    if (model.AdditionalFields != null && model.AdditionalFields.Any())
                    {
                        string additionFiledString = model.AdditionalFields.Aggregate(string.Empty,
                            (current, item) => current + item.FirstValue + ": " + item.SecondValue + "\n");

                        values.Add(sanitizer.EscapeString(additionFiledString));
                    }
                    else
                        values.Add(string.Empty);

                    fileWriter.WriteLine(string.Join(",", values.ToArray()));
                }

                logger.Info("file Name: " + fileName);
                logger.Info("CSV File Export was succesful!");
            }
            catch (Exception ex)
            {
                logger.Error((string.Format("File Write: \n Error {0} \n Trace: {1} \n\n\n", ex.Message, ex.StackTrace)));
            }
            finally
            {
                fileWriter.Close();
                fileWriter.Dispose();
            }

        }

        public void WriteCsvforHourlyAppointmentBook(IEnumerable<HourlyAppointmentBookedModel> modelData, string fileName, ILogger logger)
        {
            logger.Info("Writing CSV file " + fileName);
            if (!DirectoryOperationsHelper.DeleteFileIfExist(fileName))
            {
                logger.Info("file Name contain some illegal Character");
                return;
            }

            var fileWriter = new StreamWriter(fileName);

            try
            {
                var members = (typeof(HourlyAppointmentBookedModel)).GetMembers();

                var header = new List<string>();

                foreach (var memberInfo in members)
                {
                    if (memberInfo.MemberType != MemberTypes.Property)
                        continue;

                    var propInfo = (memberInfo as PropertyInfo);

                    if (propInfo != null)
                    {
                        if (propInfo.PropertyType == typeof(FeedbackMessageModel) || propInfo.PropertyType == typeof(IEnumerable<OrderedPair<string, string>>))
                            continue;
                    }
                    else
                        continue;

                    var propertyName = memberInfo.Name;
                    var isHidden = false;

                    var attributes = propInfo.GetCustomAttributes(false);

                    if (!attributes.IsNullOrEmpty())
                    {
                        foreach (var attribute in attributes)
                        {
                            if (attribute is HiddenAttribute)
                            {
                                isHidden = true;
                                break;
                            }
                            if (attribute is DisplayNameAttribute)
                            {
                                propertyName = (attribute as DisplayNameAttribute).DisplayName;
                            }
                        }
                    }

                    if (isHidden) continue;

                    header.Add(propertyName);
                }

                header.Add("Additional Fields");
                fileWriter.WriteLine(string.Join(",", header.ToArray()));

                var sanitizer = new CSVSanitizer();


                foreach (var model in modelData)
                {
                    var values = new List<string>();
                    foreach (var memberInfo in members)
                    {
                        if (memberInfo.MemberType != MemberTypes.Property)
                            continue;

                        var propInfo = (memberInfo as PropertyInfo);
                        if (propInfo != null)
                        {
                            if (propInfo.PropertyType == typeof(FeedbackMessageModel) || propInfo.PropertyType == typeof(IEnumerable<OrderedPair<string, string>>))
                                continue;
                            if (propInfo.PropertyType == typeof(IEnumerable<string>))
                            {
                                if (model.ShippingOptions != null && model.ShippingOptions.Any())
                                {
                                    var shippingOptions = string.Join(", \n", model.ShippingOptions.ToArray());
                                    values.Add(sanitizer.EscapeString(shippingOptions));
                                }
                                else
                                {
                                    values.Add(string.Empty);
                                }
                                continue;
                            }

                            if (propInfo.PropertyType == typeof(IEnumerable<RescheduleApplointmentModel>))
                            {
                                if (model.RescheduleInfo != null && model.RescheduleInfo.Any())
                                {
                                    var rescheduleInfoString = string.Empty;
                                    foreach (var rescheduleInfo in model.RescheduleInfo)
                                    {
                                        rescheduleInfoString += "Rescheduled By: " + rescheduleInfo.RescheduledBy + "\n";
                                        rescheduleInfoString += "Reason: " + rescheduleInfo.Reason + "\n";
                                        if (!string.IsNullOrEmpty(rescheduleInfo.SubReason))
                                            rescheduleInfoString += "SubReason: " + rescheduleInfo.SubReason + "\n";
                                        if (!string.IsNullOrEmpty(rescheduleInfo.Notes))
                                            rescheduleInfoString += "Notes: " + rescheduleInfo.Notes + "\n";
                                        rescheduleInfoString += "---------------------------\n";
                                    }
                                    values.Add(sanitizer.EscapeString(rescheduleInfoString));
                                }
                                else
                                {
                                    values.Add("N/A");
                                }
                                continue;
                            }
                        }
                        else
                            continue;


                        bool isHidden = false;
                        FormatAttribute formatter = null;

                        var attributes = propInfo.GetCustomAttributes(false);
                        if (!attributes.IsNullOrEmpty())
                        {
                            foreach (var attribute in attributes)
                            {
                                if (attribute is HiddenAttribute)
                                {
                                    isHidden = true;
                                    break;
                                }
                                if (attribute is FormatAttribute)
                                {
                                    formatter = (FormatAttribute)attribute;
                                }
                            }
                        }

                        if (isHidden) continue;
                        var obj = propInfo.GetValue(model, null);
                        if (obj == null)
                            values.Add(string.Empty);
                        else if (formatter != null)
                            values.Add(formatter.ToString(obj));
                        else
                            values.Add(sanitizer.EscapeString(obj.ToString()));

                    }

                    if (model.AdditionalFields != null && model.AdditionalFields.Any())
                    {
                        string additionFiledString = model.AdditionalFields.Aggregate(string.Empty,
                            (current, item) => current + item.FirstValue + ": " + item.SecondValue + "\n");

                        values.Add(sanitizer.EscapeString(additionFiledString));
                    }
                    else
                        values.Add(string.Empty);

                    fileWriter.WriteLine(string.Join(",", values.ToArray()));
                }

                logger.Info("CSV File Export was succesful!");
            }
            catch (Exception ex)
            {
                logger.Error((string.Format("File Write: \n Error {0} \n Trace: {1} \n\n\n", ex.Message, ex.StackTrace)));
            }
            finally
            {
                fileWriter.Close();
                fileWriter.Dispose();
            }

        }
    }
}