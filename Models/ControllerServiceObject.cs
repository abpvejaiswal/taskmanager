using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for WebServiceObject
/// </summary>


public class GeneralData
{
    public string MESSAGE { get; set; }
    public string ORIGINAL_ERROR { get; set; }
    public Boolean ERROR_STATUS { get; set; }
    //public int STATUS { get; set; }
    public Boolean RECORDS { get; set; }
}

public class GeneralDataGetPickupRequestData
{
    public string MESSAGE { get; set; }
    public string ORIGINAL_ERROR { get; set; }
    public Boolean ERROR_STATUS { get; set; }
    //public int STATUS { get; set; }
    public Boolean RECORDS { get; set; }
    public List<GetPickupRequestData> GetPickupRequestData { get; set; }

}


public class GetPickupRequestData
{
    public string id { get; set; }
    public string clientid { get; set; }
    public string Name { get; set; }
    public string Mobile { get; set; }
    public string Address { get; set; }
    public string Title { get; set; }
    public string Date { get; set; }
    public string Time { get; set; }
    public string Description { get; set; }
    public string STATUS_ID { get; set; }
    public string AssignEmp { get; set; }
    public string AssignDate { get; set; }
    public string rate { get; set; }
    public string AmcDate { get; set; }
    public string AmcAmt { get; set; }
    public string TotalComplain { get; set; }
    public string LastComplainDate { get; set; }
    public string TotalBusiness { get; set; }


}
public class GeneralDataGetEnquiryDataData
{
    public string MESSAGE { get; set; }
    public string ORIGINAL_ERROR { get; set; }
    public Boolean ERROR_STATUS { get; set; }
    //public int STATUS { get; set; }
    public Boolean RECORDS { get; set; }
    public List<EnquiryData> GetEnquiryData { get; set; }

}


public class EnquiryData
{
    public string eid { get; set; }
    public string cid { get; set; }
    public string clientname { get; set; }
    public string mobile { get; set; }
    public string zone { get; set; }
    public string email { get; set; }
    public string address { get; set; }
    public string contact_person { get; set; }
    public string valueoflead { get; set; }
    public string reference { get; set; }
    public string sourceoflead { get; set; }
    public string bank { get; set; }
    public string state { get; set; }
    public string city { get; set; }
    public string tax { get; set; }
    public string subtotal { get; set; }
    public string total { get; set; }
    public string is_show { get; set; }
    public List<EnquiryProductData> GetEnquiryProductData { get; set; }

}
public class EnquiryProductData
{
    public string eid { get; set; }
    public string itemname { get; set; }
    public string unit { get; set; }
    public string qty { get; set; }
    public string unit_price { get; set; }
    public string subtotal { get; set; }

}

public class GeneralDataGetProductData
{
    public string MESSAGE { get; set; }
    public string ORIGINAL_ERROR { get; set; }
    public Boolean ERROR_STATUS { get; set; }
    //public int STATUS { get; set; }
    public Boolean RECORDS { get; set; }
    public List<ProductData> GetOrderData { get; set; }

}


public class ProductData
{

    public string clientname { get; set; }
    public string date { get; set; }
    public string time { get; set; }
    public string totalamount { get; set; }
    public string STATUS_ID { get; set; }
}

public class GeneralDataSingleComplain
{
    public string MESSAGE { get; set; }
    public string ORIGINAL_ERROR { get; set; }
    public Boolean ERROR_STATUS { get; set; }
    //public int STATUS { get; set; }
    public Boolean RECORDS { get; set; }
    public List<SingleComplain> GetPickupRequestData { get; set; }

}


public class SingleComplain
{
    public string id { get; set; }
    public string clientid { get; set; }
    public string Name { get; set; }
    public string Title { get; set; }
    public string Date { get; set; }
    public string Time { get; set; }
    public string Description { get; set; }
    public string STATUS_ID { get; set; }




}
public class GeneralDataAllProduct
{
    public string MESSAGE { get; set; }
    public string ORIGINAL_ERROR { get; set; }
    public Boolean ERROR_STATUS { get; set; }
    //public int STATUS { get; set; }
    public Boolean RECORDS { get; set; }
    public List<AllProduct> getallproduct { get; set; }

}
public class AllProduct
{
    public string id { get; set; }
    public string Name { get; set; }
    public string Watt { get; set; }
}
public class GeneralDataClientData
{
    public string MESSAGE { get; set; }
    public string ORIGINAL_ERROR { get; set; }
    public Boolean ERROR_STATUS { get; set; }
    //public int STATUS { get; set; }
    public Boolean RECORDS { get; set; }
    public List<ClientData> getclient { get; set; }

}


public class ClientData
{
    public string id { get; set; }
    public string mobile { get; set; }
    public string email { get; set; }
    public string address { get; set; }
    public string valueoflead { get; set; }
    public string refe { get; set; }
    public string source { get; set; }
}


public class InsertQuotationSolution
{
    public string pid { get; set; }
    public string Unit { get; set; }
    public string Rate { get; set; }
    public string Qty { get; set; }
    public string Amount { get; set; }

}
public class InsertEnquiry
{
    public string CLIENT_ID { get; set; }
    public string CLIENTNAME { get; set; }
    public string MOBILE { get; set; }
    public string EMAIL { get; set; }
    public string C_PERSON { get; set; }
    public string ADDRESS { get; set; }
    public string LEAD { get; set; }
    public string REF { get; set; }
    public string REFMOB { get; set; }
    public string SOURCE { get; set; }
    public string BANK { get; set; }

}

public class GeneralDataSearch
{
    public string MESSAGE { get; set; }
    public string ORIGINAL_ERROR { get; set; }
    public Boolean ERROR_STATUS { get; set; }
    //public int STATUS { get; set; }
    public Boolean RECORDS { get; set; }
    public List<SearchUserData> getuserdata { get; set; }
    public List<SearchComplainData> getcomplaindata { get; set; }
    public List<SearchQuotationData> getquotationdata { get; set; }
    public List<SearchOrderData> getorderdata { get; set; }

}


public class SearchUserData
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Mobile { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
    public string Image { get; set; }
    public string AmcDate { get; set; }
    public string AmcAmt { get; set; }
    public string TotalComplain { get; set; }
    public string LastComplainDate { get; set; }
    public string TotalBusiness { get; set; }
}
public class SearchComplainData
{
    public string Id { get; set; }
    public string Title { get; set; }
    public string Desc { get; set; }
    public string Date { get; set; }
    public string Empname { get; set; }
    public string Status { get; set; }
    public string StatusNo { get; set; }
}
public class SearchQuotationData
{
    public string Id { get; set; }
    public string Title { get; set; }
    public string Desc { get; set; }
    public string Date { get; set; }
    public string Status { get; set; }
    public string StatusNo { get; set; }
}
public class SearchOrderData
{
    public string Id { get; set; }
    public string Productname { get; set; }
    public string Qty { get; set; }
    public string Amt { get; set; }
    public string Date { get; set; }
}

public class GeneralDataSingleComplainPageData
{
    public string MESSAGE { get; set; }
    public string ORIGINAL_ERROR { get; set; }
    public Boolean ERROR_STATUS { get; set; }
    //public int STATUS { get; set; }
    public Boolean RECORDS { get; set; }
    public List<SingleComplainPageData> getcomplaindata { get; set; }
    public List<ComplainSolutiuon> getsolutiondata { get; set; }

}


public class SingleComplainPageData
{
    public string ClientName { get; set; }
    public string ServiceTitle { get; set; }
    public string ComplainDate { get; set; }
    public string Description { get; set; }
    public string TotalAmt { get; set; }
    public string PaidAmt { get; set; }
    public string AssignDate { get; set; }
    public string AssignEmp { get; set; }
}
public class ComplainSolutiuon
{
    public string Solution { get; set; }
    public string Photo { get; set; }
    public string Date { get; set; }
    public string PaidAmt { get; set; }
    public string PaymentMode { get; set; }
}

public class GeneralDataSingleQuotationPageData
{
    public string MESSAGE { get; set; }
    public string ORIGINAL_ERROR { get; set; }
    public Boolean ERROR_STATUS { get; set; }
    //public int STATUS { get; set; }
    public Boolean RECORDS { get; set; }
    public List<SingleQuotationPageData> getquotationdata { get; set; }
    public List<QuotationSolutiuon> getsolutiondata { get; set; }

}


public class SingleQuotationPageData
{
    public string ClientName { get; set; }
    public string ServiceTitle { get; set; }
    public string ComplainDate { get; set; }
    public string Description { get; set; }
    public string SolutionPdf { get; set; }
}
public class QuotationSolutiuon
{
    public string ProductName { get; set; }
    public string Unit { get; set; }
    public string Rate { get; set; }
    public string Amount { get; set; }
}
public class GeneralDataMenusData
{
    public string MESSAGE { get; set; }
    public string ORIGINAL_ERROR { get; set; }
    public Boolean ERROR_STATUS { get; set; }
    //public int STATUS { get; set; }
    public Boolean RECORDS { get; set; }

    public List<MenusData> Data { get; set; }
}
public class MenusData
{
    public int id { get; set; }
    public string serviceid { get; set; }
    public string title { get; set; }
    public string symbol { get; set; }
}

public class GeneralDataEmployeeData
{
    public string MESSAGE { get; set; }
    public string ORIGINAL_ERROR { get; set; }
    public Boolean ERROR_STATUS { get; set; }
    //public int STATUS { get; set; }
    public Boolean RECORDS { get; set; }

    public List<EmployeeData> Data { get; set; }
}
public class EmployeeData
{
    public string complainid { get; set; }
    public string clientname { get; set; }
    public string complaindesc { get; set; }
    public string assigndate { get; set; }
    public string status { get; set; }
    public string statusname { get; set; }
}

public class GeneralDataSearchmobile
{
    public string MESSAGE { get; set; }
    public string ORIGINAL_ERROR { get; set; }
    public Boolean ERROR_STATUS { get; set; }
    //public int STATUS { get; set; }
    public Boolean RECORDS { get; set; }

    public string Data { get; set; }
}
public class InsertQuotation
{
    public string EREF { get; set; }
    public string EDATE { get; set; }
    public string QREF { get; set; }
    public string QDATE { get; set; }
    public string DTERM { get; set; }
    public string DSCHEDULE { get; set; }
    public string TAXES { get; set; }
    public string FREIGHT { get; set; }
    public string DISPATCH { get; set; }
    public string STERM { get; set; }
    public string PTERM { get; set; }

}

public class InsertProforma
{
    public string PERSON { get; set; }
    public string PERSON_NO { get; set; }
    public string EREF { get; set; }
    public string EDATE { get; set; }
    public string PREF { get; set; }
    public string PDATE { get; set; }
    public string DTERM { get; set; }
    public string DSCHEDULE { get; set; }
    public string TAXES { get; set; }
    public string FREIGHT { get; set; }
    public string DISPATCH { get; set; }
    public string SPECIAL_TERM { get; set; }
    public string PURCHASE_TERM { get; set; }
    public string GSTNO { get; set; }

}
public class InsertOrder
{
    public string PNO { get; set; }
    public string PONO { get; set; }
    public string OANO { get; set; }
    public string INSPECT { get; set; }
    public string INSURANCE { get; set; }
    public string DISPATCH { get; set; }
    public string TRASPORTER { get; set; }
    public string PREPARE_BY { get; set; }
    public string APPROVE_BY { get; set; }

}

public class GeneralDataGetQuotationDataData
{
    public string MESSAGE { get; set; }
    public string ORIGINAL_ERROR { get; set; }
    public Boolean ERROR_STATUS { get; set; }
    //public int STATUS { get; set; }
    public Boolean RECORDS { get; set; }
    public List<QuotationData> GetQuotationData { get; set; }

}


public class QuotationData
{
    public string qid { get; set; }
    public string cid { get; set; }
    public string clientname { get; set; }
    public string clientaddress { get; set; }
    public string e_refe { get; set; }
    public string e_date { get; set; }
    public string q_refe { get; set; }
    public string q_date { get; set; }
    public string delivery_term { get; set; }
    public string d_schedule { get; set; }
    public string taxes { get; set; }
    public string freight { get; set; }
    public string mode_dispatch { get; set; }
    public string s_term { get; set; }
    public string p_term { get; set; }
    public string bank { get; set; }
    public string freight_changes { get; set; }
    public string tax { get; set; }
    public string taxamt { get; set; }
    public string subtotal { get; set; }
    public string total { get; set; }
    public string is_show { get; set; }
    public string approval_status { get; set; }
    public string statusname { get; set; }
    public string Comment { get; set; }
    public string revise_status { get; set; }
    public List<QuotationProductData> GetQuotationProductData { get; set; }

}
public class QuotationProductData
{
    public string eid { get; set; }
    public string itemname { get; set; }
    public string unit { get; set; }
    public string qty { get; set; }
    public string unit_price { get; set; }
    public string subtotal { get; set; }

}

public class GeneralDataGetProformaDataData
{
    public string MESSAGE { get; set; }
    public string ORIGINAL_ERROR { get; set; }
    public Boolean ERROR_STATUS { get; set; }
    //public int STATUS { get; set; }
    public Boolean RECORDS { get; set; }
    public List<ProformaData> GetProformaData { get; set; }

}


public class ProformaData
{
    public string qid { get; set; }
    public string cid { get; set; }
    public string clientname { get; set; }
    public string e_refe { get; set; }
    public string e_date { get; set; }
    public string p_refe { get; set; }
    public string p_date { get; set; }
    public string delivery_term { get; set; }
    public string d_schedule { get; set; }
    public string taxes { get; set; }
    public string freight { get; set; }
    public string mode_dispatch { get; set; }
    public string bank { get; set; }
    public string tax { get; set; }
    public string subtotal { get; set; }
    public string total { get; set; }

    public List<QuotationProductData> GetProformaProductData { get; set; }

}
public class Insertorderitem
{
    public string pid { get; set; }
    public string Qty { get; set; }
    public string Date { get; set; }

}
public class InsertSpecialInstruction
{

    public string INSTRUCTION_TEXT { get; set; }

}

public class GeneralDataOrderDataData
{
    public string MESSAGE { get; set; }
    public string ORIGINAL_ERROR { get; set; }
    public Boolean ERROR_STATUS { get; set; }
    //public int STATUS { get; set; }
    public Boolean RECORDS { get; set; }
    public List<OrderData> GetOrderData { get; set; }

}


public class OrderData
{
    public string orderid { get; set; }
    public string clientname { get; set; }
    public string customer_address { get; set; }
    public string delivery_address { get; set; }
    public string proforma_no { get; set; }
    public string proforma_date { get; set; }
    public string perchase_no { get; set; }
    public string perchase_date { get; set; }
    public string order_no { get; set; }
    public string order_date { get; set; }
    public string inspection_by { get; set; }
    public string insurance_by { get; set; }
    public string mode_of_dispatch { get; set; }
    public string transporter { get; set; }
    public List<OrderItemData> GetOrderItemData { get; set; }
    public List<SpecialInstructionData> GetSpecialInstructionData { get; set; }

}
public class OrderItemData
{
    public string itemname { get; set; }
    public string quantity { get; set; }
    public string delivery_date { get; set; }

}
public class SpecialInstructionData
{
    public string text { get; set; }

}

public class GeneralDataGetEnquiryItemData
{
    public string MESSAGE { get; set; }
    public string ORIGINAL_ERROR { get; set; }
    public Boolean ERROR_STATUS { get; set; }
    //public int STATUS { get; set; }
    public Boolean RECORDS { get; set; }
    public List<GetEnquiryItem> GetEnquiryData { get; set; }
    public List<DeliveryAddress> GetAddressData { get; set; }
    public List<ClientAddress> GetClientAddressData { get; set; }
    public List<GetSingleQuotationData> GetQuotationData { get; set; }
}


public class GetEnquiryItem
{
    public string tax { get; set; }
    public string subtotal { get; set; }
    public string total { get; set; }
    public string itemid { get; set; }
    public string itemname { get; set; }
    public string unit { get; set; }
    public string qty { get; set; }
    public string unit_price { get; set; }
    public string subtotal_price { get; set; }

}
public class GetSingleQuotationData
{
    public string D_Term { get; set; }
    public string D_Schedule { get; set; }
    public string Taxes { get; set; }
    public string Insurance { get; set; }
    public string Mode_Dispatch { get; set; }
    public string S_Term { get; set; }
    public string P_Term { get; set; }

}
public class INSERTDISPATCHNOTEDATA
{

    public string SALE_ORDER_NO { get; set; }
    public string DELIVERY_NO { get; set; }
    public string ORDER_ACCEPTANCE_NO { get; set; }
    public string DISPATCH_NO { get; set; }
    public string TRASPORTER { get; set; }
    public string CNNO { get; set; }
    public string DISPATCH_TERM { get; set; }
    public string DISPATCH_THROUGH { get; set; }
    public string VAHICLE_NO { get; set; }
    public string INTERNAL_INSPECTION_BY { get; set; }
    public string TP_INSPECTION_BY { get; set; }
    public string PREPARE_BY { get; set; }
    public string APPROVE_BY { get; set; }

}

public class GeneralDataGETDISPATCHNOTE
{
    public string MESSAGE { get; set; }
    public string ORIGINAL_ERROR { get; set; }
    public Boolean ERROR_STATUS { get; set; }
    //public int STATUS { get; set; }
    public Boolean RECORDS { get; set; }
    public List<GETDISPATCHNOTE> GetDispatchData { get; set; }

}
public class GETDISPATCHNOTE
{
    public string DNID { get; set; }
    public string CLIENT_ID { get; set; }
    public string CLIENT_NAME { get; set; }
    public string DELIVERY_ADDRESS { get; set; }
    public string SALE_ORDER_NO { get; set; }
    public string SALE_ORDER_DATE { get; set; }
    public string DELIVERY_NO { get; set; }
    public string DELIVERY_DATE { get; set; }
    public string ORDER_ACCEPTANCE_NO { get; set; }
    public string ORDER_ACCEPTANCE_DATE { get; set; }
    public string DISPATCH_NO { get; set; }
    public string DISPATCH_DATE { get; set; }
    public string TRASPORTER { get; set; }
    public string CNNO { get; set; }
    public string DISPATCH_TERM { get; set; }
    public string DISPATCH_THROUGH { get; set; }
    public string VAHICLE_NO { get; set; }
    public string INTERNAL_INSPECTION_BY { get; set; }
    public string TP_INSPECTION_BY { get; set; }
    public List<GetDispatchItemData> GetDispatchItemData { get; set; }
    public List<InsertPackageInstruction> GetpackageData { get; set; }
    public List<InsertSpecialInstructiondispatch> GetspecialinsData { get; set; }
    public List<InsertRemark> GetremarkData { get; set; }
}
public class GetDispatchItemData
{
    public string itemname { get; set; }
    public string quantity { get; set; }
    public string delivery_date { get; set; }
    public string ProductRemark { get; set; }

}
public class Insertdispathnoteitem
{
    public string pid { get; set; }
    public string Qty { get; set; }
    public string Date { get; set; }
    public string ProductRemark { get; set; }

}

public class InsertPackageInstruction
{

    public string PACKING_INSTRUCTION { get; set; }

}
public class InsertRemark
{

    public string REMARK { get; set; }

}
public class InsertSpecialInstructiondispatch
{

    public string SPECIAL_INSTRUCTION { get; set; }

}
public class Insertdeliveryaddress
{
    public string ADDRESS { get; set; }
    public string MOBILE { get; set; }
    public string EMAIL { get; set; }

}
public class GeneralDataDeliveryAddress
{
    public string MESSAGE { get; set; }
    public string ORIGINAL_ERROR { get; set; }
    public Boolean ERROR_STATUS { get; set; }
    //public int STATUS { get; set; }
    public Boolean RECORDS { get; set; }
    public List<DeliveryAddress> GetAddress { get; set; }

}
public class DeliveryAddress
{
    public string ID { get; set; }
    public string Address { get; set; }

}
public class ClientAddress
{
    public string ID { get; set; }
    public string Address { get; set; }

}
public class GeneralDataPurchaseOrder
{
    public string MESSAGE { get; set; }
    public string ORIGINAL_ERROR { get; set; }
    public Boolean ERROR_STATUS { get; set; }
    //public int STATUS { get; set; }
    public Boolean RECORDS { get; set; }
    public List<PurchaseOrder> GetPurchaseOrderData { get; set; }

}
public class PurchaseOrder
{
    public string ID { get; set; }
    public string Client { get; set; }
    public string Date { get; set; }
    public string FilePath { get; set; }

}

public class GeneralDataHistoryData
{
    public string MESSAGE { get; set; }
    public string ORIGINAL_ERROR { get; set; }
    public Boolean ERROR_STATUS { get; set; }
    //public int STATUS { get; set; }
    public Boolean RECORDS { get; set; }
    public List<HistoryData> GetHistoryStatus { get; set; }

}
public class HistoryData
{
    public string QuotationStatus { get; set; }
    public string OrderAcceptanceStatus { get; set; }
    public string PurchaseOrderStatus { get; set; }
    public string ProformaInvoice { get; set; }
    public string DispatchNote { get; set; }
    public string Payment { get; set; }

}

public class GeneralDataCityData
{
    public string MESSAGE { get; set; }
    public string ORIGINAL_ERROR { get; set; }
    public Boolean ERROR_STATUS { get; set; }
    //public int STATUS { get; set; }
    public Boolean RECORDS { get; set; }
    public List<CityData> GetCityData { get; set; }

}
public class CityData
{
    public string ID { get; set; }
    public string CityName { get; set; }

}
public class GeneralDataPaymentData
{
    public string MESSAGE { get; set; }
    public string ORIGINAL_ERROR { get; set; }
    public Boolean ERROR_STATUS { get; set; }
    //public int STATUS { get; set; }
    public Boolean RECORDS { get; set; }
    public List<PaymentData> GetPaymentData { get; set; }

}
public class PaymentData
{
    public string ID { get; set; }
    public string ClientName { get; set; }
    public string Mode_Of_Payment { get; set; }
    public string BankName { get; set; }
    public string Cheque_no { get; set; }
    public string Date_of_Received { get; set; }
    public string Amount { get; set; }
    public string Payment_mode { get; set; }
    public string Created_Date { get; set; }

}