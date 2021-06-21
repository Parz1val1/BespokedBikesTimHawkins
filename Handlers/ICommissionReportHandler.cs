using System;
using System.Collections.Generic;
using BespokedBikesTimHawkins.Database.Models;

namespace BespokedBikesTimHawkins.Handlers
{
    public interface ICommissionReportHandler
    {
        /// <summary>
        /// Generates the CommissionReportEntities for the selected quarter and year
        /// </summary>
        /// <param name="quarter"> The quarter of the year to calculate </param>
        /// <param name="year"> The year to calculate </param>
        /// <returns> List of The Commission Reports for each salesperson </returns>
        IList<CommissionReportEntity> GenerateReports(string quarter, int year);
    }
}
