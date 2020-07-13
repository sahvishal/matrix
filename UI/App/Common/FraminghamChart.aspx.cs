using System;
using System.Linq;
using System.Web.UI.WebControls;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.Impl;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Infrastructure.Repositories.Screening;
using System.Collections.Generic;
using System.Drawing;

namespace Falcon.App.UI.App.Common
{
    public partial class FraminghamChart : System.Web.UI.Page
    {
        private int? Age
        {
            get
            {
                int? age = null;
                if (!string.IsNullOrEmpty(Request.QueryString["A"]))
                {
                    int a;
                    if (Int32.TryParse(Request.QueryString["A"], out a))
                    {
                        age = a;
                    }
                }
                return age;
            }
        }

        private int? Systolic
        {
            get
            {
                int? systolic = null;
                if (!string.IsNullOrEmpty(Request.QueryString["S"]))
                {
                    int s;
                    if (Int32.TryParse(Request.QueryString["S"], out s))
                    {
                        systolic = s;
                    }
                }
                return systolic;
            }
        }

        private int? Diastolic
        {
            get
            {
                int? diastolic = null;
                if (!string.IsNullOrEmpty(Request.QueryString["D"]))
                {
                    int d;
                    if (Int32.TryParse(Request.QueryString["D"], out d))
                    {
                        diastolic = d;
                    }
                }
                return diastolic;
            }
        }

        private int? Smoker
        {
            get
            {
                int? smoker = null;
                if (!string.IsNullOrEmpty(Request.QueryString["Sm"]))
                {
                    int s;
                    if (Int32.TryParse(Request.QueryString["Sm"], out s))
                    {
                        smoker = s;
                    }
                }
                return smoker;
            }
        }

        private int? Diabetic
        {
            get
            {
                int? diabetic = null;
                if (!string.IsNullOrEmpty(Request.QueryString["Dia"]))
                {
                    int d;
                    if (Int32.TryParse(Request.QueryString["Dia"], out d))
                    {
                        diabetic = d;
                    }
                }
                return diabetic;
            }
        }

        private int? TotalCholestrol
        {
            get
            {
                int? totalCholestrol = null;
                if (!string.IsNullOrEmpty(Request.QueryString["TC"]))
                {
                    int tCholestrol;
                    if (Int32.TryParse(Request.QueryString["TC"], out tCholestrol))
                    {
                        totalCholestrol = tCholestrol;
                    }
                }
                return totalCholestrol;
            }
        }

        private int? LDLCholestrol
        {
            get
            {
                int? ldlCholestrol = null;
                if (!string.IsNullOrEmpty(Request.QueryString["LC"]))
                {
                    int ldl;
                    if (Int32.TryParse(Request.QueryString["LC"], out ldl))
                    {
                        ldlCholestrol = ldl;
                    }
                }
                return ldlCholestrol;
            }
        }

        private int? HDLCholestrol
        {
            get
            {
                int? hdlCholestrol = null;
                if (!string.IsNullOrEmpty(Request.QueryString["HC"]))
                {
                    int hdl;
                    if (Int32.TryParse(Request.QueryString["HC"], out hdl))
                    {
                        hdlCholestrol = hdl;
                    }
                }
                return hdlCholestrol;
            }
        }

        public bool IsMale
        {
            get
            {
                bool isMale = false;
                if (!string.IsNullOrEmpty(Request.QueryString["IM"]))
                {
                    Boolean.TryParse(Request.QueryString["IM"], out isMale);
                }
                return isMale;
            }
        }

        public int Score { get; set; }

        public bool IsScoreCalculated
        {
            get;
            set;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
                return;

            List<FraminghamCalculationSource> framinghamCalculationSources = BindGridViews();

            IFraminghamRiskCalculationService framinghamRiskCalculationService = new FraminghamRiskCalculationService();
            IsScoreCalculated = false;
            if (Age.HasValue && HDLCholestrol.HasValue && Systolic.HasValue && Diastolic.HasValue && Smoker.HasValue && Diabetic.HasValue && (TotalCholestrol.HasValue || LDLCholestrol.HasValue))
            {
                IsScoreCalculated = true;
                Score = framinghamRiskCalculationService.GetScoreForCalculatingFraminghamRisk(Age.Value, IsMale,
                                                                                              TotalCholestrol,
                                                                                              HDLCholestrol.Value,
                                                                                              LDLCholestrol,
                                                                                              Systolic.Value,
                                                                                              Diastolic.Value,
                                                                                              Smoker == 0 ? false : true,
                                                                                              Diabetic == 0
                                                                                                  ? false
                                                                                                  : true,
                                                                                              framinghamCalculationSources);
            }

        }

        protected void BPGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            switch (e.Row.RowType)
            {
                case DataControlRowType.Header:
                    if (Systolic.HasValue && Diastolic.HasValue)
                    {
                        var bpHeaderLiteral = e.Row.FindControl("BPHeaderLiteral") as Literal;
                        if (bpHeaderLiteral != null)
                            bpHeaderLiteral.Text += " = " + Systolic + "/" + Diastolic;
                    }

                    break;
                case DataControlRowType.DataRow:
                    if (Systolic.HasValue && Diastolic.HasValue)
                    {
                        var framinghamCalculationSource = e.Row.DataItem as FraminghamSourceViewData;
                        if (framinghamCalculationSource != null)
                        {
                            if (IsSystolic)
                            {
                                if (framinghamCalculationSource.MaxValue.HasValue &&
                                    framinghamCalculationSource.MinValue.HasValue)
                                {
                                    if (Systolic >= framinghamCalculationSource.MinValue.Value &&
                                        Systolic <= framinghamCalculationSource.MaxValue.Value)
                                        SetRowColor(e);
                                }
                                else if (framinghamCalculationSource.MinValue.HasValue)
                                {
                                    if (Systolic >= framinghamCalculationSource.MinValue.Value)
                                        SetRowColor(e);
                                }
                                else if (framinghamCalculationSource.MaxValue.HasValue)
                                {
                                    if (Systolic <= framinghamCalculationSource.MaxValue.Value)
                                        SetRowColor(e);
                                }
                            }
                            else
                            {
                                if (framinghamCalculationSource.MaxValue.HasValue &&
                                    framinghamCalculationSource.MinValue.HasValue)
                                {
                                    if (Diastolic >= framinghamCalculationSource.MinValue.Value &&
                                        Diastolic <= framinghamCalculationSource.MaxValue.Value)
                                        SetRowColor(e);
                                }
                                else if (framinghamCalculationSource.MinValue.HasValue)
                                {
                                    if (Diastolic >= framinghamCalculationSource.MinValue.Value)
                                        SetRowColor(e);
                                }
                                else if (framinghamCalculationSource.MaxValue.HasValue)
                                {
                                    if (Diastolic <= framinghamCalculationSource.MaxValue.Value)
                                        SetRowColor(e);
                                }
                            }
                        }
                    }
                    break;
            }
        }

        protected void SmokerGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            switch (e.Row.RowType)
            {
                case DataControlRowType.DataRow:
                    if (Smoker.HasValue)
                    {
                        var framinghamCalculationSource = e.Row.DataItem as FraminghamSourceViewData;
                        if (framinghamCalculationSource != null)
                        {
                            if (framinghamCalculationSource.MaxValue.HasValue &&
                                framinghamCalculationSource.MinValue.HasValue)
                            {
                                if (Smoker >= framinghamCalculationSource.MinValue.Value &&
                                    Smoker <= framinghamCalculationSource.MaxValue.Value)
                                    SetRowColor(e);
                            }
                            else if (framinghamCalculationSource.MinValue.HasValue)
                            {
                                if (Smoker >= framinghamCalculationSource.MinValue.Value)
                                    SetRowColor(e);
                            }
                            else if (framinghamCalculationSource.MaxValue.HasValue)
                            {
                                if (Smoker <= framinghamCalculationSource.MaxValue.Value)
                                    SetRowColor(e);
                            }
                        }
                    }
                    break;
            }
        }

        protected void TCholGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            switch (e.Row.RowType)
            {
                case DataControlRowType.Header:
                    if (TotalCholestrol.HasValue)
                    {
                        var tCholHeaderLiteral = e.Row.FindControl("TCholHeaderLiteral") as Literal;
                        if (tCholHeaderLiteral != null)
                            tCholHeaderLiteral.Text += " = " + TotalCholestrol;
                    }

                    break;
                case DataControlRowType.DataRow:
                    var framinghamCalculationSource = e.Row.DataItem as FraminghamSourceViewData;
                    if (framinghamCalculationSource != null && TotalCholestrol.HasValue)
                    {
                        if (framinghamCalculationSource.MaxValue.HasValue && framinghamCalculationSource.MinValue.HasValue)
                        {
                            if (TotalCholestrol >= framinghamCalculationSource.MinValue.Value &&
                                TotalCholestrol <= framinghamCalculationSource.MaxValue.Value)
                                SetRowColor(e);
                        }
                        else if (framinghamCalculationSource.MinValue.HasValue)
                        {
                            if (TotalCholestrol >= framinghamCalculationSource.MinValue.Value)
                                SetRowColor(e);
                        }
                        else if (framinghamCalculationSource.MaxValue.HasValue)
                        {
                            if (TotalCholestrol <= framinghamCalculationSource.MaxValue.Value)
                                SetRowColor(e);
                        }
                    }
                    break;
            }
        }

        protected void LDLGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            switch (e.Row.RowType)
            {
                case DataControlRowType.Header:
                    if (LDLCholestrol.HasValue)
                    {
                        var ldlHeaderLiteral = e.Row.FindControl("LDLHeaderLiteral") as Literal;
                        if (ldlHeaderLiteral != null)
                            ldlHeaderLiteral.Text += " = " + LDLCholestrol;
                    }

                    break;
                case DataControlRowType.DataRow:
                    var framinghamCalculationSource = e.Row.DataItem as FraminghamSourceViewData;
                    if (framinghamCalculationSource != null && LDLCholestrol.HasValue)
                    {
                        if (framinghamCalculationSource.MaxValue.HasValue && framinghamCalculationSource.MinValue.HasValue)
                        {
                            if (LDLCholestrol >= framinghamCalculationSource.MinValue.Value &&
                                LDLCholestrol <= framinghamCalculationSource.MaxValue.Value)
                                SetRowColor(e);
                        }
                        else if (framinghamCalculationSource.MinValue.HasValue)
                        {
                            if (LDLCholestrol >= framinghamCalculationSource.MinValue.Value)
                                SetRowColor(e);
                        }
                        else if (framinghamCalculationSource.MaxValue.HasValue)
                        {
                            if (LDLCholestrol <= framinghamCalculationSource.MaxValue.Value)
                                SetRowColor(e);
                        }
                    }
                    break;
            }
        }

        protected void HDLGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            switch (e.Row.RowType)
            {
                case DataControlRowType.Header:
                    if (HDLCholestrol.HasValue)
                    {
                        var hdlHeaderLiteral = e.Row.FindControl("HDLHeaderLiteral") as Literal;
                        if (hdlHeaderLiteral != null)
                            hdlHeaderLiteral.Text += " = " + HDLCholestrol;
                    }
                    break;
                case DataControlRowType.DataRow:
                    if (HDLCholestrol.HasValue)
                    {
                        var framinghamCalculationSource = e.Row.DataItem as FraminghamSourceViewData;
                        if (framinghamCalculationSource != null)
                        {
                            if (framinghamCalculationSource.MaxValue.HasValue &&
                                framinghamCalculationSource.MinValue.HasValue)
                            {
                                if (HDLCholestrol >= framinghamCalculationSource.MinValue.Value &&
                                    HDLCholestrol <= framinghamCalculationSource.MaxValue.Value)
                                    SetRowColor(e);
                            }
                            else if (framinghamCalculationSource.MinValue.HasValue)
                            {
                                if (HDLCholestrol >= framinghamCalculationSource.MinValue.Value)
                                    SetRowColor(e);
                            }
                            else if (framinghamCalculationSource.MaxValue.HasValue)
                            {
                                if (HDLCholestrol <= framinghamCalculationSource.MaxValue.Value)
                                    SetRowColor(e);
                            }
                        }
                    }
                    break;
            }
        }

        protected void DiabetesGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            switch (e.Row.RowType)
            {
                case DataControlRowType.DataRow:
                    if (Diabetic.HasValue)
                    {
                        var framinghamCalculationSource = e.Row.DataItem as FraminghamSourceViewData;
                        if (framinghamCalculationSource != null)
                        {
                            if (framinghamCalculationSource.MaxValue.HasValue &&
                                framinghamCalculationSource.MinValue.HasValue)
                            {
                                if (Diabetic >= framinghamCalculationSource.MinValue.Value &&
                                    Diabetic <= framinghamCalculationSource.MaxValue.Value)
                                    SetRowColor(e);
                            }
                            else if (framinghamCalculationSource.MinValue.HasValue)
                            {
                                if (Diabetic >= framinghamCalculationSource.MinValue.Value)
                                    SetRowColor(e);
                            }
                            else if (framinghamCalculationSource.MaxValue.HasValue)
                            {
                                if (Diabetic <= framinghamCalculationSource.MaxValue.Value)
                                    SetRowColor(e);
                            }
                        }
                    }
                    break;
            }
        }

        protected void AgeChartGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (Age.HasValue)
            {
                switch (e.Row.RowType)
                {
                    case DataControlRowType.Header:
                        var ageHeaderLiteral = e.Row.FindControl("AgeHeaderLiteral") as Literal;
                        if (ageHeaderLiteral != null)
                        {
                            ageHeaderLiteral.Text = "AGE = " + Age;
                        }
                        break;
                    case DataControlRowType.DataRow:
                        var framinghamCalculationSource = e.Row.DataItem as FraminghamSourceViewData;
                        if (framinghamCalculationSource != null)
                        {
                            if (framinghamCalculationSource.MaxValue.HasValue &&
                                framinghamCalculationSource.MinValue.HasValue)
                            {
                                if (Age >= framinghamCalculationSource.MinValue.Value &&
                                    Age <= framinghamCalculationSource.MaxValue.Value)
                                    SetRowColor(e);
                            }
                            else if (framinghamCalculationSource.MinValue.HasValue)
                            {
                                if (Age >= framinghamCalculationSource.MinValue.Value)
                                    SetRowColor(e);
                            }
                            else if (framinghamCalculationSource.MaxValue.HasValue)
                            {
                                if (Age <= framinghamCalculationSource.MaxValue.Value)
                                    SetRowColor(e);
                            }
                        }
                        break;
                }
            }
        }

        private void SetRowColor(GridViewRowEventArgs e)
        {
            var range = e.Row.FindControl("RangeLabel") as Label;
            if (range != null)
                range.BackColor = Color.FromName("#ffc600");
            if (IsMale)
            {
                var maleScore = e.Row.FindControl("MaleScoreLabel") as Label;
                if (maleScore != null)
                    maleScore.BackColor = Color.FromName("#ffc600");
            }
            else
            {
                var femaleScore = e.Row.FindControl("FemaleScoreLabel") as Label;
                if (femaleScore != null)
                    femaleScore.BackColor = Color.FromName("#ffc600");
            }
        }

        private bool IsSystolic { get; set; }

        private List<FraminghamCalculationSource> BindGridViews()
        {
            IFraminghamRiskCalculationRepository framinghamRiskCalculationRepository =
                new FraminghamRiskCalculationRepository();

            List<FraminghamCalculationSource> framinghamCalculationSources =
                framinghamRiskCalculationRepository.GetFraminghamCalculationSource();

            AgeChartGridView.DataSource =
                framinghamCalculationSources.Where(
                    framinghamCalculationSource => framinghamCalculationSource.Reading == ReadingLabels.Age).Select(
                    framinghamCalculationSource =>
                    new FraminghamSourceViewData()
                        {
                            Range = GetDisplayRange(framinghamCalculationSource.MinValue, framinghamCalculationSource.MaxValue),
                            MaxValue = framinghamCalculationSource.MaxValue,
                            MinValue = framinghamCalculationSource.MinValue,
                            MaleScore = framinghamCalculationSource.MaleScore,
                            FemaleScore = framinghamCalculationSource.FemaleScore
                        });
            AgeChartGridView.DataBind();

            var systolicData = framinghamCalculationSources.Where(
                framinghamCalculationSource => framinghamCalculationSource.Reading == ReadingLabels.SystolicRight).OrderBy(
                framinghamCalculationSource => framinghamCalculationSource.Id);

            var diastolicData = framinghamCalculationSources.Where(
                framinghamCalculationSource => framinghamCalculationSource.Reading == ReadingLabels.DiastolicRight).OrderBy(
                framinghamCalculationSource => framinghamCalculationSource.Id);

            IsSystolic = GetWorstBloodPressure(systolicData, diastolicData);

            var combinedData =
                systolicData.SelectMany(
                    systolic =>
                    diastolicData.Where(d => d.MaleScore == systolic.MaleScore && d.FemaleScore == systolic.FemaleScore),
                    (systolic, diastolic) =>
                    new FraminghamSourceViewData()
                        {
                            Range =
                                GetDisplayRange(systolic.MinValue, systolic.MaxValue) + "/" +
                                GetDisplayRange(diastolic.MinValue, diastolic.MaxValue),
                            MaxValue = IsSystolic ? systolic.MaxValue : diastolic.MaxValue,
                            MinValue = IsSystolic ? systolic.MinValue : diastolic.MinValue,
                            MaleScore = IsSystolic ? systolic.MaleScore : diastolic.MaleScore,
                            FemaleScore = IsSystolic ? systolic.FemaleScore : diastolic.FemaleScore
                        });

            BPGridView.DataSource = combinedData;
            BPGridView.DataBind();

            SmokerGridView.DataSource =
                framinghamCalculationSources.Where(
                    framinghamCalculationSource => framinghamCalculationSource.Reading == ReadingLabels.Smoker).Select(
                    framinghamCalculationSource =>
                    new FraminghamSourceViewData()
                        {
                            Range = framinghamCalculationSource.MaxValue.Value == 0 ? "No" : "Yes",
                            MaxValue = framinghamCalculationSource.MaxValue,
                            MinValue = framinghamCalculationSource.MinValue,
                            MaleScore = framinghamCalculationSource.MaleScore,
                            FemaleScore =
                                framinghamCalculationSource.FemaleScore
                        });
            SmokerGridView.DataBind();

            DiabetesGridView.DataSource =
                framinghamCalculationSources.Where(
                    framinghamCalculationSource => framinghamCalculationSource.Reading == ReadingLabels.Diabetes).Select
                    (
                    framinghamCalculationSource =>
                    new FraminghamSourceViewData()
                        {
                            Range = framinghamCalculationSource.MaxValue.Value == 0 ? "No" : "Yes",
                            MaxValue = framinghamCalculationSource.MaxValue,
                            MinValue = framinghamCalculationSource.MinValue,
                            MaleScore = framinghamCalculationSource.MaleScore,
                            FemaleScore =
                                framinghamCalculationSource.FemaleScore
                        });
            DiabetesGridView.DataBind();


            TCholGridView.DataSource = framinghamCalculationSources.Where(
                framinghamCalculationSource => framinghamCalculationSource.Reading == ReadingLabels.TotalCholestrol).
                Select(
                framinghamCalculationSource =>
                new FraminghamSourceViewData()
                    {
                        Range =
                            GetDisplayRange(framinghamCalculationSource.MinValue, framinghamCalculationSource.MaxValue),
                        MaxValue = framinghamCalculationSource.MaxValue,
                        MinValue = framinghamCalculationSource.MinValue,
                        MaleScore = framinghamCalculationSource.MaleScore,
                        FemaleScore = framinghamCalculationSource.FemaleScore
                    });
            TCholGridView.DataBind();

            HDLGridView.DataSource = framinghamCalculationSources.Where(
                framinghamCalculationSource => framinghamCalculationSource.Reading == ReadingLabels.HDL).Select(
                framinghamCalculationSource =>
                new FraminghamSourceViewData()
                    {
                        Range =
                            GetDisplayRange(framinghamCalculationSource.MinValue, framinghamCalculationSource.MaxValue),
                        MaxValue = framinghamCalculationSource.MaxValue,
                        MinValue = framinghamCalculationSource.MinValue,
                        MaleScore = framinghamCalculationSource.MaleScore,
                        FemaleScore = framinghamCalculationSource.FemaleScore
                    });
            HDLGridView.DataBind();

            LDLGridView.DataSource = framinghamCalculationSources.Where(
                framinghamCalculationSource => framinghamCalculationSource.Reading == ReadingLabels.LDL).Select(
                framinghamCalculationSource =>
                new FraminghamSourceViewData()
                    {
                        Range =
                            GetDisplayRange(framinghamCalculationSource.MinValue, framinghamCalculationSource.MaxValue),
                        MaxValue = framinghamCalculationSource.MaxValue,
                        MinValue = framinghamCalculationSource.MinValue,
                        MaleScore = framinghamCalculationSource.MaleScore,
                        FemaleScore = framinghamCalculationSource.FemaleScore
                    });
            LDLGridView.DataBind();

            return framinghamCalculationSources;
        }

        private bool GetWorstBloodPressure(IEnumerable<FraminghamCalculationSource> systolicData, IOrderedEnumerable<FraminghamCalculationSource> diastolicData)
        {
            if (Systolic.HasValue && Diastolic.HasValue)
            {
                var framinghamCalculationSourceSystolic = systolicData.ToList().Find(systolic =>
                                                                                         {
                                                                                             if (systolic.MinValue !=
                                                                                                 null &&
                                                                                                 systolic.MaxValue !=
                                                                                                 null)
                                                                                             {
                                                                                                 if (Systolic.Value >=
                                                                                                     systolic.MinValue &&
                                                                                                     Systolic.Value <=
                                                                                                     systolic.MaxValue)
                                                                                                     return true;
                                                                                             }
                                                                                             else if (
                                                                                                 systolic.MinValue !=
                                                                                                 null)
                                                                                             {
                                                                                                 if (Systolic.Value >=
                                                                                                     systolic.
                                                                                                         MinValue)
                                                                                                     return true;
                                                                                             }
                                                                                             else if (
                                                                                                 systolic.MaxValue !=
                                                                                                 null)
                                                                                             {
                                                                                                 if (Systolic.Value <=
                                                                                                     systolic.
                                                                                                         MaxValue)
                                                                                                     return true;
                                                                                             }
                                                                                             return false;
                                                                                         });

                var framinghamCalculationSourceDiastolic = diastolicData.ToList().Find(diastolic =>
                                                                                           {
                                                                                               if (diastolic.MinValue !=
                                                                                                   null &&
                                                                                                   diastolic.MaxValue !=
                                                                                                   null)
                                                                                               {
                                                                                                   if (
                                                                                                       Diastolic.Value >=
                                                                                                       diastolic.
                                                                                                           MinValue &&
                                                                                                       Diastolic.Value <=
                                                                                                       diastolic.
                                                                                                           MaxValue)
                                                                                                       return true;
                                                                                               }
                                                                                               else if (
                                                                                                   diastolic.
                                                                                                       MinValue !=
                                                                                                   null)
                                                                                               {
                                                                                                   if (
                                                                                                       Diastolic.Value >=
                                                                                                       diastolic.
                                                                                                           MinValue)
                                                                                                       return true;
                                                                                               }
                                                                                               else if (
                                                                                                   diastolic.
                                                                                                       MaxValue !=
                                                                                                   null)
                                                                                               {
                                                                                                   if (
                                                                                                       Diastolic.Value <=
                                                                                                       diastolic.
                                                                                                           MaxValue)
                                                                                                       return true;
                                                                                               }
                                                                                               return false;
                                                                                           });

                if (IsMale)
                {
                    return framinghamCalculationSourceSystolic.MaleScore >=
                           framinghamCalculationSourceDiastolic.MaleScore;
                }
                return framinghamCalculationSourceSystolic.FemaleScore >=
                       framinghamCalculationSourceDiastolic.FemaleScore;
            }
            return false;
        }

        private static string GetDisplayRange(int? minValue, int? maxValue)
        {
            string range = string.Empty;
            range += minValue.HasValue ? minValue.Value + " - " : "<= ";
            range = maxValue.HasValue ? range + maxValue.Value : ">= " + range.Replace(" - ", string.Empty);
            return range;
        }
    }
}
