using Microsoft.AspNetCore.Mvc;

using NileHotels.Data;
using NileHotels.Models;
using System.Security.Claims;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Globalization;
using Microsoft.AspNetCore.Http;
using System.Diagnostics.Contracts;
using AspNetCore.Reporting;
using System.Runtime.Intrinsics.Arm;

namespace NileHotels.Controllers
{
    public class ReportsController : Controller
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        readonly ApplicationDbContext _context;
        //ApplicationDbContext _context;
        public ReportsController(IWebHostEnvironment webHostEnvironment, ApplicationDbContext applicationDbContext)
        {
            this.webHostEnvironment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            _context = applicationDbContext;
        }

        

        public IActionResult Index()
        {
            return View();
        }

        // Clients Reports
        public IActionResult ClientsReport()
        { 
            return View();
        }


        // Employee Reports
        public IActionResult EmployeesReport()
        { 
            return View();
        }

        //Furniture Report
        public IActionResult FurnitureReport()
        {
            return View();
        }

        //Room Report
        public IActionResult RoomReport()
        {
            return View();
        }

        //Total room income Report  
        public IActionResult TotalroomincomeReport()
        {
            return View();
        }

        // 
        public IActionResult Searchroomincome(DateTime startDate, DateTime endDate)
        {

            int hotelid = 0;
            if (TempData.ContainsKey("TempHotelId"))
            {
                hotelid = (int)TempData.Peek("TempHotelId");
            }
            #region 
            var results = (from c in _context.Contractss
                           where c.HotelId == hotelid
                           where c.CheckInTime.Date >= startDate || c.CheckInTime.Date <= endDate.Date
                           group c by c.RoomId into g

                           select new
                           {
                               RoomId = g.First().Room.RoomNo,
                               RoomType = g.First().Room.RoomType.NameEn,
                               TotalPrice = g.Sum(c => c.TotalPrice),
                           }).OrderBy(group => group.RoomId); 
            #endregion

            return Json(results); 

        }


        public IActionResult GetTotalroomincome()
        {

            int id = 0;

            if (TempData.ContainsKey("TempHotelId"))
            {
                id = (int)TempData.Peek("TempHotelId");
            } 
            var lan = CultureInfo.CurrentCulture.Name.StartsWith("ar");

            var results = (from c in _context.Contractss
                          where c.HotelId == id
                          
                          group c by c.RoomId into g
                         
                          select new  
                          {
                              RoomId = g.First().Room.RoomNo,
                              RoomType = lan ? g.First().Room.RoomType.NameAr : g.First().Room.RoomType.NameEn,
                              TotalPrice = g.Sum(c => c.TotalPrice),
                          }).OrderBy (group => group.RoomId);

             
            return Json(results);
        }
        

        //Room Price without Breakfast Report
        public IActionResult RoomPriceWithoutBreakfast()
        {
            return View();
        }
        
        //Room Price with Breakfast Report
        public IActionResult RoomPriceWithBreakfast()
        {
            return View();
        }

        //Rent Contracts Report
        public IActionResult ContractsReport()
        {
            int hotelid = 0;
            if (TempData.ContainsKey("TempHotelId"))
            {
                hotelid = (int)TempData.Peek("TempHotelId");
            }

            // Number of all  Contracts
            List<Contracts> allContracts = _context.Contractss.Where(i => i.HotelId == hotelid).Where(i => i.IsHospitalityContract == false).ToList();
            int allContractsLength = allContracts.Count();
            ViewBag.allContracts = allContractsLength;

            ViewBag.TotalValue = (from num in _context.Contractss
                                  where num.HotelId == hotelid 
                                  select num.TotalPrice).Sum(); 

            return View();
        }

        // Hospitality Contracts 
        public IActionResult HospitalityContractsReport()
        {
            int hotelid = 0;
            if (TempData.ContainsKey("TempHotelId"))
            {
                hotelid = (int)TempData.Peek("TempHotelId");
            }

            // Number of all  Contracts
            List<Contracts> allContracts = _context.Contractss.Where(i => i.HotelId == hotelid).Where(i => i.IsHospitalityContract == true).ToList();
            int allContractsLength = allContracts.Count();
            ViewBag.allHospitalityContracts = allContractsLength;

            return View();
        }

        // Reciept Vouchers Report
        public IActionResult RecieptVouchersReport()
        {

            int hotelid = 0;
            if (TempData.ContainsKey("TempHotelId"))
            {
                hotelid = (int)TempData.Peek("TempHotelId");
            }

            // Number of all Recepit Vouchers
            List<ContractRecepitVoucher> allRecepitVouchers = _context.ContractRecepitVouchers.Where(i => i.HotelId == hotelid).ToList();
            int allRecepitVouchersLength = allRecepitVouchers.Count();
            ViewBag.allRecepitVouchers = allRecepitVouchersLength;

            ViewBag.RecepitVouchers  = (from num in _context.ContractRecepitVouchers
                                        where num.HotelId == hotelid
                                        select num.Amount).Sum();
            ViewBag.RemainingValue = (from num in _context.ContractRecepitVouchers
                                      where num.HotelId == hotelid
                                      select num.TotalRemainingValue).Sum();



            ////List<ContractRecepitVoucher> AllContractss = _context.ContractRecepitVouchers.ToList();
            ////List<Room> AllContractss = _context.Rooms.Where(r => r.RoomStatus.NameEn == "Avilable").Where(i => i.HotelId == hotelid).ToList();
            //List<ContractRecepitVoucher> AllContractss = _context.ContractRecepitVouchers.Where(i => i.HotelId == 1).ToList();

            //ViewData["AllContractrs"] = AllContractss;

            return View();
 



        }



        //GetAllRecepitVouchersInHotel
        public IActionResult GetAllRecepitVouchersInHotel()
        {

            int hotelid = 0;
            if (TempData.ContainsKey("TempHotelId"))
            {
                hotelid = (int)TempData.Peek("TempHotelId");
            }
            var Contracts = (from c in _context.ContractRecepitVouchers
                             join cont in _context.Contractss on c.ContractId equals cont.Id
                             where c.HotelId == hotelid && c.DeletedBy == null
                             select new
                             {
                                 c.Id,
                                 customername = cont.Customer.FirstName,
                                 customerlastname = cont.Customer.LastName,

                                 roomNo = cont.Room.RoomNo,
                                 totalPrice=  cont.TotalPrice,
                                 paymentType = c.PaymentType.NameEn,
                                 paymentNature=c.PaymentNature,
                                 amount=c.Amount,
                                 paymentDate = c.PaymentDate.ToString(),
                                 
                             }).ToList();

            if (CultureInfo.CurrentCulture.Name.StartsWith("ar"))
            {
                Contracts = (from c in _context.ContractRecepitVouchers
                             join cont in _context.Contractss on c.ContractId equals cont.Id
                             where c.HotelId == hotelid && c.DeletedBy == null
                             select new
                             {
                                 c.Id,
                                 customername = cont.Customer.FirstName,
                                 customerlastname = cont.Customer.LastName,

                                 roomNo = cont.Room.RoomNo,
                                 totalPrice = cont.TotalPrice,
                                 paymentType = c.PaymentType.NameAr,
                                 paymentNature = c.PaymentNature ,
                                 amount = c.Amount,
                                 paymentDate = c.PaymentDate.ToString(),

                             }).ToList();
            }
            //var Rooms = _context.Rooms.Where(c => c.HotelId == id).Where(a => a.DeletedBy == null);
            return Json(Contracts);

        }


        // Employee handover data

        public IActionResult Employeehandoverdata()
        { 
            return View(); 
        }

        public IActionResult GetEmployeehandoverdata()
        {

            int hotelid = 0;
            if (TempData.ContainsKey("TempHotelId"))
            {
                hotelid = (int)TempData.Peek("TempHotelId");
            }

            var lan = CultureInfo.CurrentCulture.Name.StartsWith("ar");
            #region

            var Contracts = (from c in _context.ContractRecepitVouchers
                             join cont in _context.Contractss on c.ContractId equals cont.Id
                             join user in _context.Users on c.InsertedBy equals user.Id
                             where c.HotelId == hotelid && c.DeletedBy == null && c.PaymentDate.Date == DateTime.Today.Date
                             select new
                             {
                                 c.Id,
                                 customername = cont.Customer.FirstName,
                                 customerlastname = cont.Customer.LastName,
                                 username = user.UserName,
                                 roomNo = cont.Room.RoomNo,
                                 totalPrice = cont.TotalPrice,
                                 paymentType = lan? c.PaymentType.NameAr : c.PaymentType.NameEn,
                                 paymentNature = c.PaymentNature,
                                 amount = c.Amount,
                                 paymentDate = c.PaymentDate.ToString(),

                             }).ToList();
            #endregion
           
            //var Rooms = _context.Rooms.Where(c => c.HotelId == id).Where(a => a.DeletedBy == null);
            return Json(Contracts);

        }

        //Search ContractRecepitVoucher 

        public IActionResult SearchRecepitVoucher(DateTime startDate, DateTime endDate)
        {

            int hotelid = 0;
            if (TempData.ContainsKey("TempHotelId"))
            {
                hotelid = (int)TempData.Peek("TempHotelId");
            }
            #region
            var lan = CultureInfo.CurrentCulture.Name.StartsWith("ar");
            var Contracts = (from c in _context.ContractRecepitVouchers
                             join cont in _context.Contractss on c.ContractId equals cont.Id
                             join user in _context.Users on c.InsertedBy equals user.Id
                             where c.HotelId == hotelid && c.DeletedBy == null
                             where c.PaymentDate  >= startDate
                             where c.PaymentDate  <= endDate 
                             select new
                             {
                                 c.Id,
                                 customername = cont.Customer.FirstName,
                                 customerlastname = cont.Customer.LastName,
                                 username = user.UserName,
                                 roomNo = cont.Room.RoomNo,
                                 totalPrice = cont.TotalPrice,
                                 paymentType = lan? c.PaymentType.NameAr : c.PaymentType.NameEn,
                                 paymentNature = c.PaymentNature,
                                 amount = c.Amount,
                                 paymentDate = c.PaymentDate.ToString(),

                             }).ToList();
            #endregion
            return Json(Contracts);

        }







        //  Services Report
        public IActionResult ServicesReport()
        {

            int hotelid = 0;
            if (TempData.ContainsKey("TempHotelId"))
            {
                hotelid = (int)TempData.Peek("TempHotelId");
            }

            // Number of all Recepit Vouchers
            List<ContractRecepitVoucher> allRecepitVouchers = _context.ContractRecepitVouchers.Where(i => i.HotelId == hotelid).ToList();
            int allRecepitVouchersLength = allRecepitVouchers.Count();
            ViewBag.allRecepitVouchers = allRecepitVouchersLength;

            ViewBag.RecepitVouchers = (from num in _context.ContractRecepitVouchers
                                       where num.HotelId == hotelid
                                       select num.Amount).Sum();
            ViewBag.RemainingValue = (from num in _context.ContractRecepitVouchers
                                      where num.HotelId == hotelid
                                      select num.TotalRemainingValue).Sum();
             

            return View();  
        }

        //Get All Services InHotel
        public IActionResult GetAllServicesInHotel()
        { 
            int hotelid = 0;
            if (TempData.ContainsKey("TempHotelId"))
            {
                hotelid = (int)TempData.Peek("TempHotelId");
            }
            var Services = (from s in _context.Services
                            where s.HotelId == hotelid && s.DeletedBy == null
                             select new
                             {
                                 s.Id,
                                 customername = s.Customer.FirstName,
                                 customerlastname = s.Customer.LastName,
                                 netPrice = s.NetPrice,
                                 vat = s.Vat,
                                 total = s.Total,
                                 iscredit = s.IsCredit,
                                 contractid = s.ContractId,
                                 orderedDate = s.Date.ToString(),

                             }).ToList();

         return Json(Services);

        }

        public IActionResult SearchServices(DateTime startDate, DateTime endDate)
        {

            int hotelid = 0;
            if (TempData.ContainsKey("TempHotelId"))
            {
                hotelid = (int)TempData.Peek("TempHotelId");
            }
            #region

            var Contracts = (from s in _context.Services
                             
                             where s.HotelId == hotelid && s.DeletedBy == null
                             where s.Date.Date >= startDate
                             where s.Date.Date <= endDate.Date
                             select new
                             {
                                 s.Id,
                                 customername = s.Customer.FirstName,
                                 customerlastname = s.Customer.LastName,
                                 netPrice = s.NetPrice,
                                 vat = s.Vat,
                                 total = s.Total,
                                 iscredit = s.IsCredit,
                                 contractid = s.ContractId,
                                 orderedDate = s.Date.ToString(),

                             }).ToList();
            #endregion
            return Json(Contracts);

        }


        //**************************************** Purchases ****************************************

        //  Purchases Report
        public IActionResult PurchasesReport()
        {  
            return View();
        }

        //Get All Purchases InHotel
        public IActionResult GetAllSPurchasesInHotel()
        {
            int hotelid = 0;
            if (TempData.ContainsKey("TempHotelId"))
            {
                hotelid = (int)TempData.Peek("TempHotelId");
            }
            var lan = CultureInfo.CurrentCulture.Name.StartsWith("ar");
            var Purchases = (from p in _context.Purchases
                            where p.HotelId == hotelid && p.DeletedBy == null
                            select new
                            {
                                p.Id,
                                vendorname = lan ? p.Vendor.NameAr : p.Vendor.NameEn,
                                purchaseDate = p.PurchaseDate.Date.ToString(),
                                netPrice = p.NetPrice,
                                vat = p.Vat,
                                total = p.TotalPrice,
                                   
                            }).ToList();

            return Json(Purchases);

        }

        public IActionResult SearchPurchases(DateTime startDate, DateTime endDate)
        {

            int hotelid = 0;
            if (TempData.ContainsKey("TempHotelId"))
            {
                hotelid = (int)TempData.Peek("TempHotelId");
            }
            #region
            var lan = CultureInfo.CurrentCulture.Name.StartsWith("ar");
            var Purchases = (from p in _context.Purchases
                             where p.HotelId == hotelid && p.DeletedBy == null
                             where p.PurchaseDate.Date >= startDate
                             where p.PurchaseDate.Date <= endDate.Date
                             select new
                             {
                                 p.Id,
                                 vendorname = lan ? p.Vendor.NameAr : p.Vendor.NameEn,
                                 purchaseDate = p.PurchaseDate.Date.ToString(),
                                 netPrice = p.NetPrice,
                                 vat = p.Vat,
                                 total = p.TotalPrice,

                             }).ToList();

         
            #endregion
            return Json(Purchases);

        }

        //**************************************** PurchasesItems ****************************************

        public IActionResult PurchasesItemsReport()
        {
            return View();
        }

        //Get All Purchases InHotel
        public IActionResult GetAllSPurchasesItemsInHotel()
        {
            int hotelid = 0;
            if (TempData.ContainsKey("TempHotelId"))
            {
                hotelid = (int)TempData.Peek("TempHotelId");
            }
            var lan = CultureInfo.CurrentCulture.Name.StartsWith("ar");
            var Purchases = (from p in _context.PurchaseItems
                             where  p.DeletedBy == null
                             select new
                             {
                                 p.Id,
                                 assetname = lan ? p.Asset.NameAr: p.Asset.NameEn,
                                 purchaseDate = p.InsertedDate.Date.ToString(),
                                 purchaseId = p.PurchaseId,
                                 quantity = p.Quantity,
                                 unitPrice = p.UnitPrice,
                                 total = p.TotalPrice,

                             }).ToList();

            return Json(Purchases);

        }





        //**************************************** print report pdf ****************************************

        // Clients Report 1
        public IActionResult PrintClientsReport()
        {
            string mimtype = "";
            int extension = 1;
            var path = $"{this.webHostEnvironment.WebRootPath}\\Reports\\ClientsReport.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();

            int id = 0;
            if (TempData.ContainsKey("TempHotelId"))
            {
                id = (int)TempData.Peek("TempHotelId");
            }
            var lan = CultureInfo.CurrentCulture.Name.StartsWith("ar");
            #region
            
            var Customers = (from c in _context.Customers

                             where c.HotelId == id && c.DeletedBy == null
                             select new
                             {
                                 c.Id,
                                 c.FirstName,
                                 c.LastName,
                                 c.HotelId,
                                 c.CountryId,
                                 c.IsShare,
                                 c.IsCompony,
                                 c.IdValue,
                                 countryName = lan ? c.Country.NameAr : c.Country.NameEn,
                                 idType = lan ? c.IdType.NameAr : c.IdType.NameEn
                             }).ToList();

            #endregion
 
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("ClientsDataSet", Customers);
            var result = localReport.Execute(renderType: RenderType.Pdf, extension, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }


        //  PrintContractsReport 2
        public IActionResult PrintContractsReport()
        {
            string mimtype = "";
            int extension = 1;
            var path = $"{this.webHostEnvironment.WebRootPath}\\Reports\\RentContractsReport.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();

            int id = 0;

            if (TempData.ContainsKey("TempHotelId"))
            {
                id = (int)TempData.Peek("TempHotelId");
            }
            var lan = CultureInfo.CurrentCulture.Name.StartsWith("ar");
            #region
            var Contracts = (from c in _context.Contractss

                             where c.HotelId == id && c.DeletedBy == null && c.IsHospitalityContract == false
                             select new
                             {
                                 c.Id,
                                 dateCheckInTime = c.CheckInTime.ToString(),
                                 checkOut = c.CheckOut.ToString(),
                                 c.Duration,
                                 c.TotalPrice,
                                 c.CountofPerson,
                                 RoomNo = c.Room.RoomNo,
                                 FirstName = c.Customer.FirstName,
                                 LastName = c.Customer.LastName
                             }).ToList();
            #endregion

            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("RentContractsDataSet", Contracts);
            var result = localReport.Execute(renderType: RenderType.Pdf, extension, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

        // Hospitality Contracts Report 5
        public IActionResult PrintHospitalityContractsReport()
        {
            string mimtype = "";
            int extension = 1;
            var path = $"{this.webHostEnvironment.WebRootPath}\\Reports\\HospitalityContractsReport.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();

            int id = 0;

            if (TempData.ContainsKey("TempHotelId"))
            {
                id = (int)TempData.Peek("TempHotelId");
            }
            var lan = CultureInfo.CurrentCulture.Name.StartsWith("ar");
            #region
            var Contracts = (from c in _context.Contractss

                             where c.HotelId == id && c.DeletedBy == null && c.IsHospitalityContract == true
                             select new
                             {
                                 c.Id,
                                 dateCheckInTime = c.CheckInTime.ToString(),
                                 checkOut = c.CheckOut.ToString(),
                                 c.Duration,
                                 c.TotalPrice,
                                 c.CountofPerson,
                                 RoomNo = c.Room.RoomNo,
                                 FirstName = c.Customer.FirstName,
                                 LastName = c.Customer.LastName
                             }).ToList();
            #endregion

            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("RentContractsDataSet", Contracts);
            var result = localReport.Execute(renderType: RenderType.Pdf, extension, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

        //  Print Reciept Vouchers Report 2
        public IActionResult PrintRecieptVouchersReport()
        {
            string mimtype = "";
            int extension = 1;
            var path = $"{this.webHostEnvironment.WebRootPath}\\Reports\\RecieptVouchersReport.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();

            int id = 0;

            if (TempData.ContainsKey("TempHotelId"))
            {
                id = (int)TempData.Peek("TempHotelId");
            }
            var lan = CultureInfo.CurrentCulture.Name.StartsWith("ar");
            #region
            var Contracts = (from c in _context.ContractRecepitVouchers
                             join cont in _context.Contractss on c.ContractId equals cont.Id
                             where c.HotelId == id  && c.DeletedBy == null 
                             select new
                             {
                                 c.Id,
                                 ContractNumber = cont.Id,
                                 FirstName = cont.Customer.FirstName,
                                 LastName = cont.Customer.LastName,

                                 RoomNo = cont.Room.RoomNo,
                                 TotalPrice = cont.TotalPrice,
                                 paymentType = lan ? c.PaymentType.NameAr : c.PaymentType.NameEn,
                                 paymentNature =   c.PaymentNature,
                                 amount = c.Amount,
                                 paymentDate = c.PaymentDate.ToString(),
                                 c.TotalRemainingValue
                             }).ToList();
            #endregion

            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("RentContractsDataSet", Contracts);
            var result = localReport.Execute(renderType: RenderType.Pdf, extension, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }




        //  PrintEmployeesReport 3
        public IActionResult PrintEmployeesReport()
        {
            string mimtype = "";
            int extension = 1;
            var path = $"{this.webHostEnvironment.WebRootPath}\\Reports\\EmployeesReport.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();

            int id = 0;

            if (TempData.ContainsKey("TempHotelId"))
            {
                id = (int)TempData.Peek("TempHotelId");
            } 
            var lan = CultureInfo.CurrentCulture.Name.StartsWith("ar");
            #region
            var Employees = (from e in _context.Employees

                             where e.HotelId == id && e.DeletedBy == null
                             select new
                             {
                                 e.Id,
                                 FirstName = lan ? e.NameAr : e.NameEn,
                                 birthDate = e.BirthDate.Date.ToString(),
                                 IdValue = e.IdNumber,
                                 e.HotelId,
                                 e.CountryId,
                                 e.IdTypeId,
                                 idType = lan ? e.IdType.NameAr :  e.IdType.NameEn,
                                 countryName =  lan ? e.Country.NameAr : e.Country.NameEn,
                             }).ToList();
             

            #endregion

            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("ClientsDataSet", Employees);
            var result = localReport.Execute(renderType: RenderType.Pdf, extension, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }
      
        // Asset Report 4
        public IActionResult PrintAsset()
        {
            string mimtype = "";
            int extension = 1;
            var path = $"{this.webHostEnvironment.WebRootPath}\\Reports\\FurnitureReport.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
 
            int id = 0;

            if (TempData.ContainsKey("TempHotelId"))
            {
                id = (int)TempData.Peek("TempHotelId");
            }
            //var Assets = _context.Assets.Where(c => c.HotelId == id).Where(a => a.DeletedBy == null);

            var Assets = (from ass in _context.Assets
                          join s in _context.StoreAssets on ass.Id equals s.AssetId into storeAssets
                          from s in storeAssets.DefaultIfEmpty()
                          where ass.HotelId == id && ass.DeletedBy == null
                          select new
                          {
                              Id = ass.Id,
                              serialNo =   ass.SerialNo,
                              assetName = ass.NameEn,
                              naturelofAsset = ass.NaturelofAsset,
                              price = ass.Price,
                              decription =  ass.Decription,
                              //store = ass.StoreAssets.ToList(),
                              assetStatus = s == null ? "" : s.AssetStatusType.NameEn,
                              storename = s == null ? "" : s.Store.NameEn,
                              intailQty = s == null ? 0 : s.IntailQty,
                              currentQty = s == null ? 0 : s.CurrentQty,
                          }).ToList();



            if (CultureInfo.CurrentCulture.Name.StartsWith("ar"))
            {
                Assets = (from ass in _context.Assets
                          join s in _context.StoreAssets on ass.Id equals s.AssetId into storeAssets
                          from s in storeAssets.DefaultIfEmpty()
                          where ass.HotelId == id && ass.DeletedBy == null
                          select new
                          {
                              Id = ass.Id,
                              serialNo = ass.SerialNo,
                              assetName = ass.NameAr,
                              naturelofAsset = ass.NaturelofAsset,
                              price =  ass.Price,
                              decription = ass.Decription,
                              assetStatus = s == null ? "" : s.AssetStatusType.NameAr,
                              storename = s == null ? "" : s.Store.NameAr,
                              intailQty = s == null ? 0 : s.IntailQty,
                              currentQty = s == null ? 0 : s.CurrentQty,

                          }).ToList();

            }
           
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("AssetsDataSet", Assets);
             var result = localReport.Execute(renderType: RenderType.Pdf, extension, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }
        
        //RoomPriceWithBreakfast.rdlc 7
        public IActionResult PrintRoomPriceWithBreakfast()
        {
            string mimtype = "";
            int extension = 1;
            var path = $"{this.webHostEnvironment.WebRootPath}\\Reports\\RoomPriceWithBreakfast.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();

            int id = 0;
            if (TempData.ContainsKey("TempHotelId"))
            {
                id = (int)TempData.Peek("TempHotelId");
            }
            #region
            var Rooms = (from r in _context.Rooms
                         join contr in _context.Contractss
                         //on new { r.Id, r.FloorNo } equals new { contract.RoomId, contract.Status }
                         //on r.Id equals contract.RoomId
                          on new { X1 = r.Id, X2 = 1 } equals new { X1 = contr.RoomId, X2 = contr.Status } into roomgroup

                         from contr in roomgroup.DefaultIfEmpty()
                         where r.HotelId == id && r.DeletedBy == null
                         orderby r.RoomNo ascending
                         //where rc.HotelId == id && r.DeletedBy == null

                         select new
                         {

                             r.Id,
                             r.RoomNo,
                             r.FloorNo,
                             r.NormalPrice,
                             r.MinPrice,
                             r.SingleBedNo,
                             r.DoubleBedNo,
                             r.WcNo,
                             r.HotelId,
                             r.RoomTypeId,
                             r.RoomStatusId,
                             r.PriceWithBreakfast,
                             status = r.RoomStatus.NameEn,
                             typename = r.RoomType.NameEn,
                             contractnumber = contr == null ? 0 : contr.Id,
                             totalPrice = contr == null ? 0 : contr.TotalPrice,
                             contractCheckInTime = contr == null ? "" : contr.CheckInTime.Date.ToString(),
                             contractCheckOut = contr == null ? "" : contr.CheckOut.Date.ToString(),
                             contractDuration = contr == null ? 0 : contr.Duration
                         }).ToList();

            #endregion
            if (CultureInfo.CurrentCulture.Name.StartsWith("ar"))
            {
                Rooms = (from r in _context.Rooms
                         join contr in _context.Contractss
                         //on new { r.Id, r.FloorNo } equals new { contract.RoomId, contract.Status }
                         //on r.Id equals contract.RoomId
                          on new { X1 = r.Id, X2 = 1 } equals new { X1 = contr.RoomId, X2 = contr.Status } into roomgroup

                         from contr in roomgroup.DefaultIfEmpty()
                         where r.HotelId == id && r.DeletedBy == null
                         select new
                         {

                             r.Id,
                             r.RoomNo,
                             r.FloorNo,
                             r.NormalPrice,
                             r.MinPrice,
                             r.SingleBedNo,
                             r.DoubleBedNo,
                             r.WcNo,
                             r.HotelId,
                             r.RoomTypeId,
                             r.RoomStatusId,
                             r.PriceWithBreakfast,
                             status = r.RoomStatus.NameAr,
                             typename = r.RoomType.NameAr,
                             contractnumber = contr == null ? 0 : contr.Id,
                             totalPrice = contr == null ? 0 : contr.TotalPrice,
                             contractCheckInTime = contr == null ? "" : contr.CheckInTime.Date.ToString(),
                             contractCheckOut = contr == null ? "" : contr.CheckOut.Date.ToString(),
                             contractDuration = contr == null ? 0 : contr.Duration


                         }).ToList();


            } 

            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("RoomsDataSet", Rooms);// name of dataset in report
            var result = localReport.Execute(renderType: RenderType.Pdf, extension, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }
       
        //RoomPriceWithoutBreakfast.rdlc 8
        public IActionResult PrintRoomPriceWithoutBreakfast()
        {
            string mimtype = "";
            int extension = 1;
            var path = $"{this.webHostEnvironment.WebRootPath}\\Reports\\RoomPriceWithoutBreakfast.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();

            int id = 0;
            if (TempData.ContainsKey("TempHotelId"))
            {
                id = (int)TempData.Peek("TempHotelId");
            }
            #region
            var Rooms = (from r in _context.Rooms
                         join contr in _context.Contractss
                         //on new { r.Id, r.FloorNo } equals new { contract.RoomId, contract.Status }
                         //on r.Id equals contract.RoomId
                          on new { X1 = r.Id, X2 = 1 } equals new { X1 = contr.RoomId, X2 = contr.Status } into roomgroup

                         from contr in roomgroup.DefaultIfEmpty()
                         where r.HotelId == id && r.DeletedBy == null
                         orderby r.RoomNo ascending
                         //where rc.HotelId == id && r.DeletedBy == null

                         select new
                         {

                             r.Id,
                             r.RoomNo,
                             r.FloorNo,
                             r.NormalPrice,
                             r.MinPrice,
                             r.SingleBedNo,
                             r.DoubleBedNo,
                             r.WcNo,
                             r.HotelId,
                             r.RoomTypeId,
                             r.RoomStatusId,
                             r.PriceWithBreakfast,
                             status = r.RoomStatus.NameEn,
                             typename = r.RoomType.NameEn,
                             contractnumber = contr == null ? 0 : contr.Id,
                             totalPrice = contr == null ? 0 : contr.TotalPrice,
                             contractCheckInTime = contr == null ? "" : contr.CheckInTime.Date.ToString(),
                             contractCheckOut = contr == null ? "" : contr.CheckOut.Date.ToString(),
                             contractDuration = contr == null ? 0 : contr.Duration
                         }).ToList();

            #endregion
            if (CultureInfo.CurrentCulture.Name.StartsWith("ar"))
            {
                Rooms = (from r in _context.Rooms
                         join contr in _context.Contractss
                         //on new { r.Id, r.FloorNo } equals new { contract.RoomId, contract.Status }
                         //on r.Id equals contract.RoomId
                          on new { X1 = r.Id, X2 = 1 } equals new { X1 = contr.RoomId, X2 = contr.Status } into roomgroup

                         from contr in roomgroup.DefaultIfEmpty()
                         where r.HotelId == id && r.DeletedBy == null
                         select new
                         {

                             r.Id,
                             r.RoomNo,
                             r.FloorNo,
                             r.NormalPrice,
                             r.MinPrice,
                             r.SingleBedNo,
                             r.DoubleBedNo,
                             r.WcNo,
                             r.HotelId,
                             r.RoomTypeId,
                             r.RoomStatusId,
                             r.PriceWithBreakfast,
                             status = r.RoomStatus.NameAr,
                             typename = r.RoomType.NameAr,
                             contractnumber = contr == null ? 0 : contr.Id,
                             totalPrice = contr == null ? 0 : contr.TotalPrice,
                             contractCheckInTime = contr == null ? "" : contr.CheckInTime.Date.ToString(),
                             contractCheckOut = contr == null ? "" : contr.CheckOut.Date.ToString(),
                             contractDuration = contr == null ? 0 : contr.Duration


                         }).ToList();


            }


            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("RoomsDataSet", Rooms);// name of dataset in report
            var result = localReport.Execute(renderType: RenderType.Pdf, extension, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }
        
        //Room Report 9
        public IActionResult PrintRoom()
        {
            string mimtype = "";
            int extension = 1;
            var path = $"{this.webHostEnvironment.WebRootPath}\\Reports\\Rooms.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();

            int id = 0;
            if (TempData.ContainsKey("TempHotelId"))
            {
                id = (int)TempData.Peek("TempHotelId");
            }
            #region
            var Rooms = (from r in _context.Rooms
                         join contr in _context.Contractss
                         //on new { r.Id, r.FloorNo } equals new { contract.RoomId, contract.Status }
                         //on r.Id equals contract.RoomId
                          on new { X1 = r.Id, X2 = 1 } equals new { X1 = contr.RoomId, X2 = contr.Status } into roomgroup

                         from contr in roomgroup.DefaultIfEmpty()
                         where r.HotelId == id && r.DeletedBy == null
                         orderby r.RoomNo ascending
                         //where rc.HotelId == id && r.DeletedBy == null

                         select new
                         {

                             r.Id,
                             r.RoomNo,
                             r.FloorNo,
                             r.NormalPrice,
                             r.MinPrice,
                             r.SingleBedNo,
                             r.DoubleBedNo,
                             r.WcNo,
                             r.HotelId,
                             r.RoomTypeId,
                             r.RoomStatusId,
                             r.PriceWithBreakfast,
                             status = r.RoomStatus.NameEn,
                             typename = r.RoomType.NameEn,
                             contractnumber = contr == null ? 0 : contr.Id,
                             totalPrice = contr == null ? 0 : contr.TotalPrice,
                             contractCheckInTime = contr == null ? "" : contr.CheckInTime.Date.ToString(),
                             contractCheckOut = contr == null ? "" : contr.CheckOut.Date.ToString(),
                             contractDuration = contr == null ? 0 : contr.Duration
                         }).ToList();

            #endregion
            if (CultureInfo.CurrentCulture.Name.StartsWith("ar"))
            {
                Rooms = (from r in _context.Rooms
                         join contr in _context.Contractss
                         //on new { r.Id, r.FloorNo } equals new { contract.RoomId, contract.Status }
                         //on r.Id equals contract.RoomId
                          on new { X1 = r.Id, X2 = 1 } equals new { X1 = contr.RoomId, X2 = contr.Status } into roomgroup

                         from contr in roomgroup.DefaultIfEmpty()
                         where r.HotelId == id && r.DeletedBy == null
                         select new
                         {

                             r.Id,
                             r.RoomNo,
                             r.FloorNo,
                             r.NormalPrice,
                             r.MinPrice,
                             r.SingleBedNo,
                             r.DoubleBedNo,
                             r.WcNo,
                             r.HotelId,
                             r.RoomTypeId,
                             r.RoomStatusId,
                             r.PriceWithBreakfast,
                             status = r.RoomStatus.NameAr,
                             typename = r.RoomType.NameAr,
                             contractnumber = contr == null ? 0 : contr.Id,
                             totalPrice = contr == null ? 0 : contr.TotalPrice,
                             contractCheckInTime = contr == null ? "" : contr.CheckInTime.Date.ToString(),
                             contractCheckOut = contr == null ? "" : contr.CheckOut.Date.ToString(),
                             contractDuration = contr == null ? 0 : contr.Duration


                         }).ToList();


            }


            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("RoomsDataSet", Rooms);// name of dataset in report
            var result = localReport.Execute(renderType: RenderType.Pdf, extension, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

        //Print Total Room Income
        public IActionResult PrintTotalroomincomeReport()
        {
            string mimtype = "";
            int extension = 1;
            var path = $"{this.webHostEnvironment.WebRootPath}\\Reports\\TotalRoomsIncome.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();

            int id = 0;
            if (TempData.ContainsKey("TempHotelId"))
            {
                id = (int)TempData.Peek("TempHotelId");
            }
            #region
            var lan = CultureInfo.CurrentCulture.Name.StartsWith("ar");

            var Rooms = (from c in _context.Contractss
                           where c.HotelId == id

                           group c by c.RoomId into g

                           select new
                           {
                               Id = g.First().Room.RoomNo,
                               typename =lan ? g.First().Room.RoomType.NameAr : g.First().Room.RoomType.NameEn,
                               totalPrice = g.Sum(c => c.TotalPrice),
                           }).OrderBy(group => group.Id);


            #endregion

            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("RoomsDataSet", Rooms);// name of dataset in report
            var result = localReport.Execute(renderType: RenderType.Pdf, extension, parameters, mimtype);
            return File(result.MainStream, "application/pdf");

        }
         
        //  Print Contract Invoice
        public IActionResult PrintContractInvoice(int contractnumber)
        {
            string mimtype = "";
            int extension = 1;
            var path = $"{this.webHostEnvironment.WebRootPath}\\Reports\\ContractInvoice.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();

            int id = 0;

            if (TempData.ContainsKey("TempHotelId"))
            {
                id = (int)TempData.Peek("TempHotelId");
            }
            var lan = CultureInfo.CurrentCulture.Name.StartsWith("ar");
            #region Contracts
            var currContract = _context.Contractss.Find(contractnumber);
            if (currContract != null)
            {
                currContract.Status = 0;
                _context.Entry(currContract).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
            }

            var Contracts = (from c in _context.Contractss
                              
                             where c.HotelId == id && c.DeletedBy == null && c.Id == contractnumber
                             select new
                             {
                                 c.Id, 
                                 ContractNumber = c.Id,
                                 date = DateTime.Now.ToString() ,
                                 dateCheckInTime = c.CheckInTime.ToString(),
                                 checkOut = c.CheckOut.ToString(),
                                 TotalPrice = c.TotalPrice,

                             }).ToList();
            #endregion

            #region RecepitVouchers
            var RecepitVouchers = (from c in _context.ContractRecepitVouchers
                             join cont in _context.Contractss on c.ContractId equals cont.Id
                             where c.HotelId == id && c.DeletedBy == null && c.ContractId == contractnumber
                                   select new
                             {
                                 c.Id,
                                 ContractNumber = cont.Id,
                                 date = DateTime.Now.ToString(),
                                 
                                 TotalPrice = cont.TotalPrice,
                                 paymentType = lan ? c.PaymentType.NameAr : c.PaymentType.NameEn,
                                 paymentNature = c.PaymentNature,
                                 amount = c.Amount,
                                 paymentDate = c.PaymentDate.ToString(),
                                 
                                 c.TotalRemainingValue
                             }).ToList();
            #endregion


            #region Hotel
            var Hotel = (from h in _context.Hotels
                             join hcont in _context.HotelContacts on h.Id equals hcont.HotelId
                             where h.Id == id /*&& h.DeletedBy == null */
                             select new
                             {
                                 h.Id,
                                 hotelName = lan ? h.NameAr : h.NameEn,
                                 hotelAddress = lan ? h.FullAddressAr : h.FullAddressEn,
                                 contactinfo = hcont.ContactType.NameEn == "E-mail" ? hcont.Value : hcont.Value,
                                 
                             }).ToList();
            #endregion

            #region Customers
            var CustomerId = _context.Contractss.Find(contractnumber).CustomerId;

            var Customers = (from c in _context.Customers 
                             join contt in _context.CustomerContacts on c.Id equals contt.CustomerId
                             where c.HotelId == id && c.Id == CustomerId
                             select new
                             {
                                 c.Id,
                                 c.FirstName,
                                 c.LastName,
                                 c.HotelId,
                                 c.CountryId,
                                 c.IsShare,
                                 c.IsCompony,
                                 c.IdValue,
                                 contt.Value,
                                 countryName = lan ? c.Country.NameAr : c.Country.NameEn,
                                 idType = lan ? c.IdType.NameAr : c.IdType.NameEn
                             }).ToList();

            #endregion

            #region Room
            var RoomId = _context.Contractss.Find(contractnumber).RoomId;
            var OldRoom = _context.Rooms.Find(RoomId);
            if (OldRoom != null)
            {
                OldRoom.RoomStatusId = 10;

                _context.Entry(OldRoom).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
            }
            var Rooms = (from r in _context.Rooms
                         
                         where r.HotelId == id && r.DeletedBy == null  && r.Id == RoomId
                         select new
                         {
                             r.Id,
                             r.RoomNo,
                             r.FloorNo,
                             r.NormalPrice,
                             r.MinPrice,
                             r.SingleBedNo,
                             r.DoubleBedNo,
                             r.WcNo,
                             r.HotelId,
                             r.RoomTypeId,
                             r.RoomStatusId,
                             r.PriceWithBreakfast,
                             status = r.RoomStatus.NameEn,
                             typename = r.RoomType.NameEn,
                              }).ToList();
            #endregion

            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("ClientsDataSet", Customers); 
            localReport.AddDataSource("ContractDataSet", Contracts);
            localReport.AddDataSource("HotelDataSet", Hotel); 
            localReport.AddDataSource("RoomsDataSet", Rooms);
            localReport.AddDataSource("RecepitVouchersDataSet", RecepitVouchers);

            var result = localReport.Execute(renderType: RenderType.Pdf, extension, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

        // n5
        public IActionResult PrintServicesReport()
        {
            string mimtype = "";
            int extension = 1;
            var path = $"{this.webHostEnvironment.WebRootPath}\\Reports\\ServicesReport.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();


            int hotelid = 0;
            if (TempData.ContainsKey("TempHotelId"))
            {
                hotelid = (int)TempData.Peek("TempHotelId");
            }
            #region
            var Services = (from s in _context.Services
                            where s.HotelId == hotelid && s.DeletedBy == null
                            select new
                            {
                                Id = s.Id,
                                customername = s.Customer.FirstName,
                                customerlastname = s.Customer.LastName,
                                netPrice = s.NetPrice,
                                vat = s.Vat,
                                total = s.Total,
                                iscredit = s.IsCredit,
                                contractid = s.ContractId,
                                orderedDate = s.Date.ToString(),

                            }).ToList();


           
            var lan = CultureInfo.CurrentCulture.Name.StartsWith("ar");
            
            
            #endregion

            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("ServicesDataSet", Services);
            var result = localReport.Execute(renderType: RenderType.Pdf, extension, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }


        public IActionResult PrintSearchServices(DateTime StartDate, DateTime EndDate)
        {

            string mimtype = "";
            int extension = 1;
            var path = $"{this.webHostEnvironment.WebRootPath}\\Reports\\ServicesReport.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();


            int hotelid = 0;
            if (TempData.ContainsKey("TempHotelId"))
            {
                hotelid = (int)TempData.Peek("TempHotelId");
            }

            #region
            var Services = (from s in _context.Services

                            where s.HotelId == hotelid && s.DeletedBy == null
                            where s.Date.Date >= StartDate
                            where s.Date.Date <= EndDate.Date
                            select new
                            {
                                s.Id,
                                customername = s.Customer.FirstName,
                                customerlastname = s.Customer.LastName,
                                netPrice = s.NetPrice,
                                vat = s.Vat,
                                total = s.Total,
                                iscredit = s.IsCredit,
                                contractid = s.ContractId,
                                orderedDate = s.Date.ToString(),

                            }).ToList();
            #endregion

            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("ServicesDataSet1", Services);
            var result = localReport.Execute(renderType: RenderType.Pdf, extension, parameters, mimtype);
            return File(result.MainStream, "application/pdf");


        }

        //******************************  Print Purchases ******************************
        public IActionResult PrintPurchasesinvoice(int purchaseId)
        {

            string mimtype = "";
            int extension = 1;
            var path = $"{this.webHostEnvironment.WebRootPath}\\Reports\\PurchasesinvoiceReport.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();


            int hotelid = 0;
            if (TempData.ContainsKey("TempHotelId"))
            {
                hotelid = (int)TempData.Peek("TempHotelId");
            }

            #region
            var PurchaseViewModel = (from p in _context.Purchases
                                     join pi in _context.PurchaseItems on p.Id equals pi.PurchaseId
                                     where p.HotelId == hotelid && p.Id == purchaseId
                                     select new
                                     {
                                         Id= p.Id,
                                         PurchaseDate = p.InsertedDate.Date,
                                         NetPrice = p.NetPrice, 
                                         Vat = p.Vat,
                                         Total = p.TotalPrice,
                                         Quantity = pi.Quantity,
                                         UnitPrice = pi.UnitPrice,
                                         TotalPrice = pi.TotalPrice,
                                         AssetId = pi.AssetId,
                                         HotelId = p.HotelId,
                                         VendorName = p.Vendor.NameEn,
                                         //StoreName = p.Store.NameEn,
                                         HotelName = p.Hotel.NameEn,
                                         AssetName = pi.Asset.NameEn
                                     }).ToList();
            #endregion

            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("PurchasesDataSet", PurchaseViewModel);
            var result = localReport.Execute(renderType: RenderType.Pdf, extension, parameters, mimtype);
            return File(result.MainStream, "application/pdf");


        }
        public IActionResult PrintAllPurchasesinvoice()
        {

            string mimtype = "";
            int extension = 1;
            var path = $"{this.webHostEnvironment.WebRootPath}\\Reports\\AllPurchasesinvoiceReport.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();


            int hotelid = 0;
            if (TempData.ContainsKey("TempHotelId"))
            {
                hotelid = (int)TempData.Peek("TempHotelId");
            }

            #region
            var PurchaseViewModel = (from p in _context.Purchases
                                     join pi in _context.PurchaseItems on p.Id equals pi.PurchaseId
                                     where p.HotelId == hotelid 
                                     select new
                                     {
                                         Id = p.Id,
                                         PurchaseDate = p.InsertedDate.Date,
                                         NetPrice = p.NetPrice,
                                         Vat = p.Vat,
                                         Total = p.TotalPrice,
                                         Quantity = pi.Quantity,
                                         UnitPrice = pi.UnitPrice,
                                         TotalPrice = pi.TotalPrice,
                                         AssetId = pi.AssetId,
                                         HotelId = p.HotelId,
                                         VendorName = p.Vendor.NameEn,
                                         //StoreName = p.Store.NameEn,
                                         HotelName = p.Hotel.NameEn,
                                         AssetName = pi.Asset.NameEn
                                     }).ToList();
            #endregion

            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("PurchasesDataSet", PurchaseViewModel);
            var result = localReport.Execute(renderType: RenderType.Pdf, extension, parameters, mimtype);
            return File(result.MainStream, "application/pdf"); 
        }

        public IActionResult PrintSearchPurchases(DateTime StartDate, DateTime EndDate)
        {

            string mimtype = "";
            int extension = 1;
            var path = $"{this.webHostEnvironment.WebRootPath}\\Reports\\AllPurchasesinvoiceReport.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();


            int hotelid = 0;
            if (TempData.ContainsKey("TempHotelId"))
            {
                hotelid = (int)TempData.Peek("TempHotelId");
            }

            #region
            var lan = CultureInfo.CurrentCulture.Name.StartsWith("ar");
            var Purchases = (from p in _context.Purchases
                             where p.HotelId == hotelid && p.DeletedBy == null
                             where p.PurchaseDate.Date >= StartDate
                             where p.PurchaseDate.Date <= EndDate.Date
                             select new
                             { 
                                  
                                 purchaseDate = p.PurchaseDate.Date.ToString(),
                                 netPrice = p.NetPrice,
                                 vat = p.Vat,
                                 total = p.TotalPrice,
                                 Id = p.Id,
                                 PurchaseDate = p.PurchaseDate.Date,
                                 NetPrice = p.NetPrice,
                                 Vat = p.Vat,
                                 Total = p.TotalPrice, 
                                 VendorName = lan ? p.Vendor.NameAr : p.Vendor.NameEn,
                                  
                                 HotelName = p.Hotel.NameEn,
                                 
                             }).ToList();
            #endregion

            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("PurchasesDataSet", Purchases);
            var result = localReport.Execute(renderType: RenderType.Pdf, extension, parameters, mimtype);
            return File(result.MainStream, "application/pdf");


        }


        //******************************  Print Purchases Items ******************************
        public IActionResult PrintAllPurchasesItems()
        { 
            string mimtype = "";
            int extension = 1;
            var path = $"{this.webHostEnvironment.WebRootPath}\\Reports\\AllPurchasesItemsReport.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();


            int hotelid = 0;
            if (TempData.ContainsKey("TempHotelId"))
            {
                hotelid = (int)TempData.Peek("TempHotelId");
            }
            var lan = CultureInfo.CurrentCulture.Name.StartsWith("ar");
            #region
            var PurchaseViewModel = (from p in _context.PurchaseItems
                                     where p.DeletedBy == null
                                     select new
                                     {
                                         p.Id,
                                         assetname = lan ? p.Asset.NameAr : p.Asset.NameEn,
                                         pDate = p.InsertedDate.Date.ToString(),
                                         purchaseId = p.PurchaseId,
                                         quantity = p.Quantity,
                                         unitPrice = p.UnitPrice,
                                         totalp = p.TotalPrice,

                                     }).ToList();
            #endregion

            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("PurchasesDataSet", PurchaseViewModel);
            var result = localReport.Execute(renderType: RenderType.Pdf, extension, parameters, mimtype);
            return File(result.MainStream, "application/pdf");


        }


        public IActionResult Print()
        {
            string mimtype = "";
            int extension = 1;
            var path = $"{this.webHostEnvironment.WebRootPath}\\Reports\\FurnitureReport.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            //parameters.Add("param1", "Welcome");

            LocalReport localReport = new LocalReport(path);
            var result = localReport.Execute(renderType: RenderType.Pdf, extension, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }








    }
}
