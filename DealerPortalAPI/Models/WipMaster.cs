using System;
using System.Collections.Generic;

namespace DealerPortalAPI.Models
{
    public partial class WipMaster
    {
        public WipMaster()
        {
            SorMaster = new HashSet<SorMaster>();
        }

        public string Job { get; set; }
        public string JobDescription { get; set; }
        public string JobClassification { get; set; }
        public string JobType { get; set; }
        public string MasterJob { get; set; }
        public decimal Priority { get; set; }
        public string StockCode { get; set; }
        public string StockDescription { get; set; }
        public string Warehouse { get; set; }
        public string Customer { get; set; }
        public string CustomerName { get; set; }
        public DateTime? JobTenderDate { get; set; }
        public DateTime? JobDeliveryDate { get; set; }
        public DateTime? JobStartDate { get; set; }
        public DateTime? ActCompleteDate { get; set; }
        public string Complete { get; set; }
        public string SeqCheckReq { get; set; }
        public string DateCalcMethod { get; set; }
        public decimal ExpLabour { get; set; }
        public decimal ExpMaterial { get; set; }
        public decimal QtyToMake { get; set; }
        public decimal QtyManufactured { get; set; }
        public string Source { get; set; }
        public string EstSourceNum { get; set; }
        public decimal NextDetailLine { get; set; }
        public decimal PctCompleteFlag { get; set; }
        public string PrtFactDoc1 { get; set; }
        public string PrtFactDoc2 { get; set; }
        public string PrtFactDoc3 { get; set; }
        public string PrtFactDoc4 { get; set; }
        public decimal SellingPrice { get; set; }
        public decimal AddLabPct { get; set; }
        public decimal AddMatPct { get; set; }
        public decimal ProfitPct { get; set; }
        public string SalesOrder { get; set; }
        public decimal MaterialBilled { get; set; }
        public decimal LabourBilled { get; set; }
        public decimal NextOpForAll { get; set; }
        public decimal HighestOpPosted { get; set; }
        public decimal TotalQtyScrapped { get; set; }
        public string ConfirmedFlag { get; set; }
        public string HoldFlag { get; set; }
        public string JobCreatedStruc { get; set; }
        public string LstOrderCreated { get; set; }
        public string TraceableType { get; set; }
        public decimal NxtLinePartBook { get; set; }
        public string Route { get; set; }
        public string WipCtlGlCode { get; set; }
        public decimal Decimals { get; set; }
        public decimal SalesOrderLine { get; set; }
        public decimal MatCostToDate1 { get; set; }
        public decimal MatCostToDate2 { get; set; }
        public decimal MatCostToDate3 { get; set; }
        public decimal LabCostToDate1 { get; set; }
        public decimal LabCostToDate2 { get; set; }
        public decimal LabCostToDate3 { get; set; }
        public decimal HrsBookToDate1 { get; set; }
        public decimal HrsBookToDate2 { get; set; }
        public decimal HrsBookToDate3 { get; set; }
        public decimal MatValueIssues1 { get; set; }
        public decimal MatValueIssues2 { get; set; }
        public decimal MatValueIssues3 { get; set; }
        public decimal LabValueIssues1 { get; set; }
        public decimal LabValueIssues2 { get; set; }
        public decimal LabValueIssues3 { get; set; }
        public decimal NarrationNum { get; set; }
        public string ReqPlnFlag { get; set; }
        public DateTime? DateJobLstUpd { get; set; }
        public decimal TimeJobLstUpd { get; set; }
        public string HierarchyFlag { get; set; }
        public decimal NextLineHier { get; set; }
        public string EstTrailLoad { get; set; }
        public string OrdEntSource { get; set; }
        public string Version { get; set; }
        public string Release { get; set; }
        public string AllocationLine { get; set; }
        public string PurgeJob { get; set; }
        public string HierarchyJob { get; set; }
        public string MrpFromJob { get; set; }
        public string MrpToJob { get; set; }
        public DateTime? OrigDueDate { get; set; }
        public string GrossFlg { get; set; }
        public decimal GrossQty { get; set; }
        public decimal ExpLabCurrent { get; set; }
        public decimal ExpMatCurrent { get; set; }
        public string ReservedLotSerFlag { get; set; }
        public string NotionalPart { get; set; }
        public string CoProductCostMet { get; set; }
        public string CoProductCostVal { get; set; }
        public string CoProductType { get; set; }
        public string CapexCode { get; set; }
        public decimal CapexLine { get; set; }
        public string UomFlag { get; set; }
        public decimal ConvFactUom { get; set; }
        public string ConvMulDiv { get; set; }
        public string ScheduleFlag { get; set; }
        public DateTime? SchStartDate { get; set; }
        public decimal SchStartTime { get; set; }
        public DateTime? SchEndDate { get; set; }
        public decimal SchEndTime { get; set; }
        public decimal QtyToMakeEnt { get; set; }
        public decimal QtyManufacturedEnt { get; set; }
        public decimal TotQtyScrappedEnt { get; set; }
        public decimal GrossQtyEnt { get; set; }
        public string ProductCode { get; set; }
        public string LibraryCode { get; set; }
        public byte[] TimeStamp { get; set; }

        public virtual ArCustomer CustomerNavigation { get; set; }
        public virtual SorDetail SalesOrder1 { get; set; }
        public virtual SorMaster SalesOrderNavigation { get; set; }
        public virtual ICollection<SorMaster> SorMaster { get; set; }
    }
}
