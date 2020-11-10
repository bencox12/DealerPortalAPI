using System;
using System.Collections.Generic;

namespace DealerPortalAPI.Models
{
    public partial class SorDetail
    {
        public SorDetail()
        {
            WipMaster = new HashSet<WipMaster>();
        }

        public string SalesOrder { get; set; }
        public decimal SalesOrderLine { get; set; }
        public string LineType { get; set; }
        public string MstockCode { get; set; }
        public string MstockDes { get; set; }
        public string Mwarehouse { get; set; }
        public string Mbin { get; set; }
        public decimal MorderQty { get; set; }
        public decimal MshipQty { get; set; }
        public decimal MbackOrderQty { get; set; }
        public decimal MunitCost { get; set; }
        public string MbomFlag { get; set; }
        public string MparentKitType { get; set; }
        public decimal MqtyPer { get; set; }
        public decimal MscrapPercentage { get; set; }
        public string MprintComponent { get; set; }
        public string McomponentSeq { get; set; }
        public string MqtyChangesFlag { get; set; }
        public string MoptionalFlag { get; set; }
        public decimal Mdecimals { get; set; }
        public string MorderUom { get; set; }
        public decimal MstockQtyToShp { get; set; }
        public string MstockingUom { get; set; }
        public decimal MconvFactOrdUm { get; set; }
        public string MmulDivPrcFct { get; set; }
        public decimal Mprice { get; set; }
        public string MpriceUom { get; set; }
        public string McommissionCode { get; set; }
        public decimal MdiscPct1 { get; set; }
        public decimal MdiscPct2 { get; set; }
        public decimal MdiscPct3 { get; set; }
        public string MdiscValFlag { get; set; }
        public decimal MdiscValue { get; set; }
        public string MproductClass { get; set; }
        public string MtaxCode { get; set; }
        public DateTime? MlineShipDate { get; set; }
        public string MallocStatSched { get; set; }
        public string MfstTaxCode { get; set; }
        public decimal MstockUnitMass { get; set; }
        public decimal MstockUnitVol { get; set; }
        public string MpriceCode { get; set; }
        public decimal MconvFactAlloc { get; set; }
        public string MmulDivQtyFct { get; set; }
        public string MtraceableType { get; set; }
        public string MmpsFlag { get; set; }
        public string MpickingSlip { get; set; }
        public string MmovementReqd { get; set; }
        public string MserialMethod { get; set; }
        public string MzeroQtyCrNote { get; set; }
        public string MabcApplied { get; set; }
        public string MmpsGrossReqd { get; set; }
        public string Mcontract { get; set; }
        public string MbuyingGroup { get; set; }
        public string McusSupStkCode { get; set; }
        public decimal McusRetailPrice { get; set; }
        public string MtariffCode { get; set; }
        public DateTime? MlineReceiptDat { get; set; }
        public decimal MleadTime { get; set; }
        public decimal MtrfCostMult { get; set; }
        public string MsupplementaryUn { get; set; }
        public string MreviewFlag { get; set; }
        public string MreviewStatus { get; set; }
        public string MinvoicePrinted { get; set; }
        public string MdelNotePrinted { get; set; }
        public string MordAckPrinted { get; set; }
        public string MhierarchyJob { get; set; }
        public DateTime? McustRequestDat { get; set; }
        public string MlastDelNote { get; set; }
        public string MuserDef { get; set; }
        public decimal MqtyDispatched { get; set; }
        public string MdiscChanged { get; set; }
        public string McreditOrderNo { get; set; }
        public decimal McreditOrderLine { get; set; }
        public string MunitQuantity { get; set; }
        public decimal MconvFactUnitQ { get; set; }
        public string MaltUomUnitQ { get; set; }
        public decimal MdecimalsUnitQ { get; set; }
        public string MeccFlag { get; set; }
        public string Mversion { get; set; }
        public string Mrelease { get; set; }
        public DateTime? McommitDate { get; set; }
        public decimal QtyReserved { get; set; }
        public string Ncomment { get; set; }
        public decimal NcommentFromLin { get; set; }
        public decimal NmscChargeValue { get; set; }
        public string NmscProductCls { get; set; }
        public decimal NmscChargeCost { get; set; }
        public string NmscInvCharge { get; set; }
        public string NcommentType { get; set; }
        public string NmscTaxCode { get; set; }
        public string NmscFstCode { get; set; }
        public string NcommentTextTyp { get; set; }
        public decimal NmscChargeQty { get; set; }
        public string NsrvIncTotal { get; set; }
        public string NsrvSummary { get; set; }
        public string NsrvChargeType { get; set; }
        public decimal NsrvParentLine { get; set; }
        public decimal NsrvUnitPrice { get; set; }
        public decimal NsrvUnitCost { get; set; }
        public decimal NsrvQtyFactor { get; set; }
        public string NsrvApplyFactor { get; set; }
        public decimal NsrvDecimalRnd { get; set; }
        public string NsrvDecRndFlag { get; set; }
        public decimal NsrvMinValue { get; set; }
        public decimal NsrvMaxValue { get; set; }
        public string NsrvMulDiv { get; set; }
        public string NprtOnInv { get; set; }
        public string NprtOnDel { get; set; }
        public string NprtOnAck { get; set; }
        public string NtaxAmountFlag { get; set; }
        public string NdepRetFlagProj { get; set; }
        public string NretentionJob { get; set; }
        public decimal NsrvMinQuantity { get; set; }
        public string NchargeCode { get; set; }
        public string IncludeInMrp { get; set; }
        public string ProductCode { get; set; }
        public string LibraryCode { get; set; }
        public string MaterialAllocLine { get; set; }
        public decimal ScrapQuantity { get; set; }
        public string FixedQtyPerFlag { get; set; }
        public decimal FixedQtyPer { get; set; }
        public string MultiShipCode { get; set; }
        public string User1 { get; set; }
        public string CreditReason { get; set; }
        public DateTime? OrigShipDateAps { get; set; }
        public string TpmUsageFlag { get; set; }
        public string PromotionCode { get; set; }
        public decimal TpmSequence { get; set; }
        public decimal SalesOrderInitLine { get; set; }
        public decimal PreactorPriority { get; set; }
        public string SalesOrderDetStat { get; set; }
        public string SalesOrderResStat { get; set; }
        public decimal QtyReservedShip { get; set; }
        public byte[] TimeStamp { get; set; }

        public virtual SorMaster SalesOrderNavigation { get; set; }
        public virtual ICollection<WipMaster> WipMaster { get; set; }
    }
}
