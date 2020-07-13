using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Medical.Domain;

namespace Falcon.App.Core.Medical.Impl
{
    public class StandardFindingService
    {
        //TODO - test

        //public static int GetCalculatedStandardFinding<T>(List<StandardFinding<T>> standardFindings, T reading)
        //{
        //    var selectedStandardFinding = standardFindings.Where(standardFinding =>
        //    {
        //        if (standardFinding.MinValue == null && standardFinding.MaxValue > reading)
        //            return true;
        //        if (standardFinding.MaxValue == null && standardFinding.MinValue < reading)
        //            return true;
        //        if (standardFinding.MaxValue > reading && standardFinding.MinValue < reading)
        //            return true;
        //        return false;
        //    }
        //        ).SingleOrDefault();

        //    return Convert.ToInt32(selectedStandardFinding.Id);

        //}

        public static int GetCalculatedStandardFinding(List<StandardFinding<decimal?>> standardFindings, decimal? reading)
        {
            var selectedStandardFinding = standardFindings.Where(standardFinding =>
            {
                if (standardFinding.MinValue == null && standardFinding.MaxValue >= reading)
                    return true;
                if (standardFinding.MaxValue == null && standardFinding.MinValue <= reading)
                    return true;
                if (standardFinding.MaxValue >= reading && standardFinding.MinValue <= reading)
                    return true;
                return false;
            }
                ).SingleOrDefault();

            if (selectedStandardFinding != null)
                return Convert.ToInt32(selectedStandardFinding.Id);
            else return 0;

        }

        public static int GetCalculatedStandardFinding(List<StandardFinding<int?>> standardFindings, int? reading)
        {
            var selectedStandardFinding = standardFindings.Where(standardFinding =>
            {
                if (standardFinding.MinValue == null && standardFinding.MaxValue >= reading)
                    return true;
                if (standardFinding.MaxValue == null && standardFinding.MinValue <= reading)
                    return true;
                if (standardFinding.MaxValue >= reading && standardFinding.MinValue <= reading)
                    return true;
                return false;
            }
                ).SingleOrDefault();

            if (selectedStandardFinding != null)
                return Convert.ToInt32(selectedStandardFinding.Id);
            else return 0;

        }

        public static IEnumerable<long> GetMulitpleCalculatedStandardFinding(List<StandardFinding<int?>> standardFindings, int? reading)
        {
            return standardFindings.Where(standardFinding =>
            {
                if (standardFinding.MinValue == null && standardFinding.MaxValue >= reading)
                    return true;
                if (standardFinding.MaxValue == null && standardFinding.MinValue <= reading)
                    return true;
                if (standardFinding.MaxValue >= reading && standardFinding.MinValue <= reading)
                    return true;
                return false;
            }
                ).Select(sf => sf.Id).ToArray();

        }

        public static IEnumerable<long> GetMulitpleCalculatedStandardFinding(List<StandardFinding<decimal?>> standardFindings, decimal? reading)
        {
            return standardFindings.Where(standardFinding =>
            {
                if (standardFinding.MinValue == null && standardFinding.MaxValue >= reading)
                    return true;
                if (standardFinding.MaxValue == null && standardFinding.MinValue <= reading)
                    return true;
                if (standardFinding.MaxValue >= reading && standardFinding.MinValue <= reading)
                    return true;
                return false;
            }
                ).Select(sf => sf.Id).ToArray();

        }

    }
}
