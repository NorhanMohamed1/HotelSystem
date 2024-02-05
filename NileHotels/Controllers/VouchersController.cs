using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NileHotels.Data;
using NileHotels.Models;
using System.Diagnostics.Contracts;
using System.Runtime.Intrinsics.Arm;
using System.Security.Claims;

namespace NileHotels.Controllers
{
    public class VouchersController : Controller
    {
        readonly ApplicationDbContext _context;
        public VouchersController(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Dashboard ()
        {
            int id = 0;

            if (TempData.ContainsKey("TempHotelId"))
            {
                id = (int)TempData.Peek("TempHotelId");
            }

            // Number of all Rooms 
            List<Room> allRooms = _context.Rooms.Where(i => i.HotelId == id).ToList();
            int allRoomsLength =allRooms.Count();
             ViewBag.allRooms = allRoomsLength;

            // Available Rooms 
            List<Room> availableRooms = _context.Rooms.Where(r => r.RoomStatus.NameEn == "Avilable").Where(i => i.HotelId == id).ToList();
            int availableRoomsLength = availableRooms.Count(); 
            ViewBag.availableRooms = availableRoomsLength;

            // Reserved Rooms 
            List<Room> reservedRooms = _context.Rooms.Where(r => r.RoomStatus.NameEn == "Reserved").Where(i => i.HotelId == id).ToList();
            int reservedRoomsLength = reservedRooms.Count();
            ViewBag.reservedRooms = reservedRoomsLength;

            // Off Service Rooms 
            List<Room> OffServiceRooms = _context.Rooms.Where(r => r.RoomStatus.NameEn == "Off Service" || r.RoomStatus.NameEn == "Under maintenance").Where(i => i.HotelId == id).ToList();
            int OffServiceRoomsLength = OffServiceRooms.Count();
            ViewBag.OffServiceRooms = OffServiceRoomsLength;


            // Total Number of Daily Contracts 
            List<Contracts> Contracts = _context.Contractss.Where(c => c.CheckInTime.Date == DateTime.Today).Where(i => i.HotelId == id).ToList();
            int ContractLength = Contracts.Count(); 
            ViewBag.allContract = ContractLength;

            // Total Value of Daily Contracts
            var totalPrice = Contracts.Sum(t => t.TotalPrice);
           
            ViewBag.ContracttotalPrice = totalPrice;

            //Number of Clients
            List<Customer> Customers = _context.Customers.Where(i => i.HotelId == id).ToList();
            int CustomerLength = Customers.Count();
            ViewBag.allClients = CustomerLength;


            // Number of Employees
            List<Employee> Employees = _context.Employees.Where(i => i.HotelId == id).ToList();
            int EmployeesLength = Employees.Count();
            ViewBag.allEmployees = EmployeesLength;











            return View(); 
        }
        //**************************************** Contract ****************************************

        //Show Contract
        public IActionResult Contract(int? room)
        {
            //List<Contracts> Contractss = _context.Contractss.ToList();
            //ViewData["Contracts"] = Contractss;
            if (room == null)
                return RedirectToAction("Index", "Home");
            var rom = _context.Rooms.Find(room);
            if (rom == null)
                return RedirectToAction("Index", "Home");
            rom.Hotel = _context.Hotels.Find(rom.HotelId);
            rom.RoomType = _context.RoomType.Find(rom.RoomTypeId);
            ViewData["Room"] = rom;

           
            return View(new Contracts());
        }

        //Update Contract
        public IActionResult UpdateContract(Contracts NewContracts)
        {
            // current user
            var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            
            int routevalue = NewContracts.RoomId;
            
            if (NewContracts.Id == 0)
            {
                // insert New Contracts
                NewContracts.InsertedBy = userid;
                NewContracts.InsertedDate = DateTime.Now;
                _context.Contractss.Add(NewContracts);
                _context.SaveChanges();
                // find room and make it Reserved
                var OldRoom = _context.Rooms.Find(NewContracts.RoomId);
                if (OldRoom != null)
                {
                    OldRoom.RoomStatusId = 8;
                    
                    _context.Entry(OldRoom).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    _context.SaveChanges();
                }

                // insert New RoomRecord
                RoomRecords RoomRecord = new RoomRecords();
                //RoomRecord.RoomId = NewContracts.RoomId;
                RoomRecord.ContractId = NewContracts.Id;
                RoomRecord.CheckInTime = NewContracts.CheckInTime;
                RoomRecord.CheckOut = NewContracts.CheckOut;
                RoomRecord.Duration = NewContracts.Duration;
                RoomRecord.InsertedBy = userid;
                RoomRecord.InsertedDate = DateTime.Now;
                _context.RoomRecords.Add(RoomRecord);
                _context.SaveChanges();
                 

            }
           
            else
            {
                // Update 
                var OldContracts = _context.Contractss.Find(NewContracts.Id);
                var OldRoomRecord = _context.RoomRecords.Where(a => a.ContractId == NewContracts.Id
                /*&& a.RoomId == NewContracts.RoomId*/).FirstOrDefault(); ;

                if (OldContracts != null )
                {
                    //update Room Record
                    if (OldRoomRecord != null)
                    {
                        OldRoomRecord.CheckInTime = NewContracts.CheckInTime;
                        OldRoomRecord.CheckOut = NewContracts.CheckOut;
                        OldRoomRecord.Duration = NewContracts.Duration;
                        OldRoomRecord.UpdatedBy = userid;
                        OldRoomRecord.UpdatedDate = DateTime.Now;
                        _context.Entry(OldRoomRecord).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        _context.SaveChanges();

                       

                    }
                    // insert new RoomRecord
                    else
                    {
                        // find new & old rooms and change status
                        var OldRoom = _context.Rooms.Find(OldContracts.RoomId);
                        var NewRoom = _context.Rooms.Find(NewContracts.RoomId);
                        if (NewRoom != null && OldRoom != null)
                        {
                            OldRoom.RoomStatusId = 10;

                            _context.Entry(OldRoom).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                            _context.SaveChanges();

                            NewRoom.RoomStatusId = 8;

                            _context.Entry(NewRoom).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                            _context.SaveChanges();
                        }
                        RoomRecords RoomRecord = new RoomRecords();
                        //RoomRecord.RoomId = NewContracts.RoomId;
                        RoomRecord.ContractId = NewContracts.Id;
                        RoomRecord.CheckInTime = NewContracts.CheckInTime;
                        RoomRecord.CheckOut = NewContracts.CheckOut;
                        RoomRecord.Duration = NewContracts.Duration;
                        RoomRecord.InsertedBy = userid;
                        RoomRecord.InsertedDate = DateTime.Now;
                        _context.RoomRecords.Add(RoomRecord);
                        _context.SaveChanges();
                    }
                    OldContracts.CheckInTime = NewContracts.CheckInTime;
                    OldContracts.CheckOut = NewContracts.CheckOut;
                    OldContracts.PurposeVisitId = NewContracts.PurposeVisitId;
                    OldContracts.Duration = NewContracts.Duration;
                    OldContracts.UnitPrice = NewContracts.UnitPrice;

                    OldContracts.NetPrice = NewContracts.NetPrice;
                    OldContracts.CountofPerson = NewContracts.CountofPerson;

                    OldContracts.TotalVat = NewContracts.TotalVat;
                    OldContracts.TotalPrice = NewContracts.TotalPrice;

                    OldContracts.RoomId = NewContracts.RoomId;
                    OldContracts.PurposeVisitId = OldContracts.PurposeVisitId;

                    OldContracts.UpdatedBy = userid;
                    OldContracts.UpdatedDate = DateTime.Now;
                    _context.Entry(OldContracts).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    _context.SaveChanges();

                     
                }
            }
            return RedirectToAction("AllContracts");
        }

        //Get Contracts
        public JsonResult GetContract(int? id)
        {
            var Contractss = _context.Contractss.Find(id);
            return Json(Contractss);
        }

        //Delete Contracts
        public IActionResult DeleteContract(Contracts NewContracts)
        {
            // current user
            var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var OldContracts = _context.Contractss.Find(NewContracts.Id);
            if (OldContracts != null)
            {
                OldContracts.DeletedBy = userid;
                OldContracts.DeletedDate = DateTime.Now;

                _context.Entry(OldContracts).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
            }

            return RedirectToAction("AllContracts");

        }

        //Show All Contracts
        public IActionResult AllContracts()
        {
            List<Contracts> AllContractss = _context.Contractss.ToList();
            ViewData["AllContracts"] = AllContractss;
            
            return View(new Contracts());
        }

        //GetAllContractsInHotel
        public IActionResult GetAllContractsInHotel()
        {

            int hotelid = 0;
            if (TempData.ContainsKey("TempHotelId"))
            {
                hotelid = (int)TempData.Peek("TempHotelId");
            }
            var Contracts = (from c in _context.Contractss
                          
                         where c.HotelId == hotelid && c.DeletedBy == null && c.IsHospitalityContract == false
                         select new
                         {
                             c.Id,
                             dateCheckInTime =  c.CheckInTime.ToString(),
                             checkOutstr =  c.CheckOut.ToString(),
                             checkOut = c.CheckOut.Date,
                             c.Duration,
                            
                             c.TotalPrice,
                            
                             c.CountofPerson,
                             c.Room.RoomNo,
                             c.Customer.FirstName,
                             c.Customer.LastName
                         }).ToList();

          
            return Json(Contracts);

        }

        //Get All Hospitality Contracts InHotel
        public IActionResult GetAllHospitalityContractsInHotel()
        {

            int hotelid = 0;
            if (TempData.ContainsKey("TempHotelId"))
            {
                hotelid = (int)TempData.Peek("TempHotelId");
            }
            var Contracts = (from c in _context.Contractss
                             join cu in _context.Customers on c.CustomerId equals cu.Id
                             join r in _context.Rooms on c.RoomId equals r.Id
                             where c.HotelId == hotelid && c.DeletedBy == null && c.IsHospitalityContract == true
                             select new
                             {
                                 c.Id,
                                 dateCheckInTime = c.CheckInTime.ToString(),
                                 checkOut = c.CheckOut.ToString(),
                                 c.Duration,
                                 c.TotalPrice,
                                 c.CountofPerson,
                                 r.RoomNo,
                                 cu.FirstName,
                                 cu.LastName
                             }).ToList();


            //var Rooms = _context.Rooms.Where(c => c.HotelId == id).Where(a => a.DeletedBy == null);
            return Json(Contracts);

        }


        //SearchContractsInHotel

        public IActionResult SearchContracts(string id , DateTime dateENTRY, DateTime dateEXIT)
        {

            int hotelid = 0;
            if (TempData.ContainsKey("TempHotelId"))
            {
                hotelid = (int)TempData.Peek("TempHotelId");
            }
            #region
           
            var Contracts = (from c in _context.Contractss
                             join cu in _context.Customers on c.CustomerId equals cu.Id
                             join r in _context.Rooms on c.RoomId equals r.Id
                             where c.HotelId == hotelid && c.DeletedBy == null && c.IsHospitalityContract == false
                             select new
                             {
                                 contractid=c.Id,
                                 dateCheckInTime = c.CheckInTime,
                                 c.CheckOut,
                                 c.Duration,
                                 c.TotalPrice,
                                 c.CountofPerson,
                                 r.RoomNo,
                                 cu.FirstName,
                                 cu.LastName,
                                 cu.IdValue
                             }).ToList();
            #endregion
            var searchContract = Contracts.Where(cu => cu.IdValue == id || cu.CheckOut.Date == dateEXIT.Date || cu.dateCheckInTime.Date == dateENTRY.Date) ;
             return Json(searchContract);

        }


        //**************************************** ContractInvoice ****************************************

        public IActionResult ContractInvoice(int? contract)
        {

            if (contract == null)
                return RedirectToAction("Index", "Home");
            var cont = _context.Contractss.Find(contract);
            if (cont == null)
                return RedirectToAction("Asset", "Settings");
            cont.Hotel = _context.Hotels.Find(cont.HotelId);
            cont.Room = _context.Rooms.Find(cont.RoomId);
            cont.Customer = _context.Customers.Find(cont.CustomerId);

            ViewData["Contract"] = cont;


            return View(new ContractInvoice());
        }






        //**************************************** ContractRecepitVoucher  ****************************************

        //View ContractRecepitVoucher   
        public IActionResult ContractRecepitVoucher(int? contract)
        {

            if (contract == null)
                return RedirectToAction("Index", "Home");
            var cont = _context.Contractss.Find(contract);
            if (cont == null)
                return RedirectToAction("Asset", "Settings");
            cont.Hotel = _context.Hotels.Find(cont.HotelId);
            cont.Room = _context.Rooms.Find(cont.RoomId);
            cont.Customer = _context.Customers.Find(cont.CustomerId);

            ViewData["Contract"] = cont;
            return View(new ContractRecepitVoucher());

        }



        //Update ContractRecepitVoucher  
        public IActionResult UpdateContractRecepitVoucher(ContractRecepitVoucher NewContractRecepitVoucher)
        {
            // current user
            var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            

            if (NewContractRecepitVoucher.Id == 0)
            {
                NewContractRecepitVoucher.InsertedBy = userid;
                NewContractRecepitVoucher.InsertedDate = DateTime.Now;
                _context.ContractRecepitVouchers.Add(NewContractRecepitVoucher);
                _context.SaveChanges();
            }
            else
            {
                var OldContractRecepitVoucher = _context.ContractRecepitVouchers.Find(NewContractRecepitVoucher.Id);
                if (OldContractRecepitVoucher != null)
                {
                    OldContractRecepitVoucher.Amount = NewContractRecepitVoucher.Amount;
                    OldContractRecepitVoucher.Description = NewContractRecepitVoucher.Description;

                    OldContractRecepitVoucher.PaymentDate = NewContractRecepitVoucher.PaymentDate;
                    OldContractRecepitVoucher.Isprocess = NewContractRecepitVoucher.Isprocess;

                    OldContractRecepitVoucher.PaymentNature = NewContractRecepitVoucher.PaymentNature;
                    OldContractRecepitVoucher.PaymentTypeId = NewContractRecepitVoucher.PaymentTypeId;

                    OldContractRecepitVoucher.UpdatedBy = userid;
                    OldContractRecepitVoucher.UpdatedDate = DateTime.Now;

                    _context.Entry(OldContractRecepitVoucher).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    _context.SaveChanges();
                }
            }
            return RedirectToAction("AllContracts", "Vouchers");
        }


        //Search ContractRecepitVoucher 

        public IActionResult SearchRecepitVoucher( DateTime startDate, DateTime endDate)
        {

            int hotelid = 0;
            if (TempData.ContainsKey("TempHotelId"))
            {
                hotelid = (int)TempData.Peek("TempHotelId");
            }
            #region

            var Contracts = (from c in _context.ContractRecepitVouchers
                             join cont in _context.Contractss on c.ContractId equals cont.Id
                             where c.HotelId == hotelid && c.DeletedBy == null
                             where c.PaymentDate.Date >= startDate
                             where c.PaymentDate.Date <= endDate.Date
                             select new
                             {
                                 c.Id,
                                 customername = cont.Customer.FirstName,
                                 customerlastname = cont.Customer.LastName,

                                 roomNo = cont.Room.RoomNo,
                                 totalPrice = cont.TotalPrice,
                                 paymentType = c.PaymentType.NameEn,
                                 paymentNature = c.PaymentNature,
                                 amount = c.Amount,
                                 paymentDate = c.PaymentDate.ToString(),

                             }).ToList();
            #endregion
             return Json(Contracts);

        }





        //Update ContractPaymentVoucher  
        public IActionResult UpdateContractPaymentVoucher(ContractPaymentVoucher NewContractPaymentVoucher)
        {
            // current user
            var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);


            if (NewContractPaymentVoucher.Id == 0)
            {
                NewContractPaymentVoucher.InsertedBy = userid;
                NewContractPaymentVoucher.InsertedDate = DateTime.Now;
                _context.ContractPaymentVouchers.Add(NewContractPaymentVoucher);
                _context.SaveChanges();
            }
            else
            {
                var OldContractPaymentVoucher = _context.ContractPaymentVouchers.Find(NewContractPaymentVoucher.Id);
                if (OldContractPaymentVoucher != null)
                {
                    OldContractPaymentVoucher.Amount = NewContractPaymentVoucher.Amount;
                    OldContractPaymentVoucher.Description = NewContractPaymentVoucher.Description;

                    OldContractPaymentVoucher.PaymentDate = NewContractPaymentVoucher.PaymentDate;
                    OldContractPaymentVoucher.Isprocess = NewContractPaymentVoucher.Isprocess;

                    OldContractPaymentVoucher.PaymentNature = NewContractPaymentVoucher.PaymentNature;
                    OldContractPaymentVoucher.PaymentTypeId = NewContractPaymentVoucher.PaymentTypeId;

                    OldContractPaymentVoucher.UpdatedBy = userid;
                    OldContractPaymentVoucher.UpdatedDate = DateTime.Now;

                    _context.Entry(OldContractPaymentVoucher).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    _context.SaveChanges();
                }
            }
            return RedirectToAction("AllContracts", "Vouchers");
        }


















        //**************************************** Service ****************************************

        //Show Service
        public IActionResult Services(int? contract=0)
        {
          

            if (contract == null)
                return RedirectToAction("Index", "Home");
            var cont = _context.Contractss.Find(contract);
            //if (cont == null)
            //    return RedirectToAction("Index", "Home");
            int hotelid = 0;
            
            if (cont != null)
            {
                cont.Hotel = _context.Hotels.Find(cont.HotelId);
                cont.Room = _context.Rooms.Find(cont.RoomId);
                cont.Customer = _context.Customers.Find(cont.CustomerId);

                ViewData["Contract"] = cont;
            }  
             

            return View();

        }

        //Update Service
        public IActionResult UpdateService( ContractServices NewService)
        {
            int hotelid = 0;
            if (TempData.ContainsKey("TempHotelId"))
            {
                hotelid = (int)TempData.Peek("TempHotelId");
            }
            // current user
            var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            int routevalue =  NewService.ContractId;
            if (NewService.Id == 0)
            {
                NewService.InsertedBy = userid;
                NewService.InsertedDate = DateTime.Now;

                // insert service
                Service ServiceVoucher = new Service();

                ServiceVoucher.Date = NewService.Date;
                ServiceVoucher.NetPrice = NewService.NetPrice;
                ServiceVoucher.Vat = NewService.Vat;
                ServiceVoucher.Total = NewService.Total;
                ServiceVoucher.IsCredit = NewService.IsCredit;

                ServiceVoucher.InsertedBy = userid;
                ServiceVoucher.InsertedDate = DateTime.Now;

                ServiceVoucher.PaymentTypeId = 2;//NewService.PaymentTypeId;
                ServiceVoucher.HotelId = hotelid;
                ServiceVoucher.CustomerId = 74;//NewService.CustomerId;
                ServiceVoucher.StoreId = NewService.StoreId;
                ServiceVoucher.ContractId = 87;// NewService.ContractId;//87;

                _context.Services.Add(ServiceVoucher);
                _context.SaveChanges();

                int ServiceVoucherId = ServiceVoucher.Id;
               
                for(int i=0; i< NewService.Qty.Length ; i++ )
                {
                    ServiceItem ServiceItems = new ServiceItem();
                    ServiceItems.Qty = NewService.Qty[i];
                    ServiceItems.UnitPrice = NewService.UnitPrice[i];
                    ServiceItems.TotalPrice = NewService.TotalPrice[i];
                    ServiceItems.ServiceId = ServiceVoucherId;

                    ServiceItems.InsertedBy = userid;
                    ServiceItems.InsertedDate = DateTime.Now;

                    ServiceItems.AssetId = NewService.AssetId[i];

                    _context.ServiceItems.Add(ServiceItems);
                    _context.SaveChanges();
                }
               

              

            }
            else
            {
                var OldService = _context.Services.Find(NewService.Id);
                if (OldService != null)
                {

                    OldService.Date = NewService.Date;
                    OldService.NetPrice = NewService.NetPrice;

                    OldService.Vat = NewService.Vat;
                    OldService.Total = NewService.Total;

                    OldService.IsCredit = NewService.IsCredit;

                    OldService.PaymentTypeId = NewService.PaymentTypeId;
                    OldService.HotelId = NewService.HotelId;
                    OldService.CustomerId = NewService.CustomerId;

                    OldService.StoreId = NewService.StoreId;
                    OldService.ContractId = NewService.ContractId;

                    OldService.UpdatedBy = userid;
                    OldService.UpdatedDate = DateTime.Now;
                    _context.Entry(OldService).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    _context.SaveChanges();
                }
            }
            return RedirectToAction("Services", "Vouchers", new { contract = routevalue });
        }

        //Get Service
        public JsonResult GetService(int? id)
        {
            var Services = _context.Services.Find(id);
            return Json(Services);
        }

        //****************************************  ServiceItem **************************************** 

        //Show ServiceItem
        public IActionResult ServiceItem()
        {
            List<ServiceItem> ServiceItems = _context.ServiceItems.ToList();
            ViewData["ServiceItems"] = ServiceItems;
            return View(new ServiceItem());
        }

        //Update ServiceItem
        public IActionResult UpdateServiceItem(ServiceItem NewServiceItem)
        {
            // current user
            var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (NewServiceItem.Id == 0)
            {
                NewServiceItem.InsertedBy = userid;
                NewServiceItem.InsertedDate = DateTime.Now;
                _context.ServiceItems.Add(NewServiceItem);
                _context.SaveChanges();
            }
            else
            {
                var OldServiceItem = _context.ServiceItems.Find(NewServiceItem.Id);
                if (OldServiceItem != null)
                {
                    OldServiceItem.Qty = NewServiceItem.Qty;
                    OldServiceItem.UnitPrice = NewServiceItem.UnitPrice;

                    OldServiceItem.TotalPrice = NewServiceItem.TotalPrice;
                    OldServiceItem.ServiceId = NewServiceItem.ServiceId;

                    OldServiceItem.AssetId = NewServiceItem.AssetId;

                    OldServiceItem.UpdatedBy = userid;
                    OldServiceItem.UpdatedDate = DateTime.Now;

                    _context.Entry(OldServiceItem).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    _context.SaveChanges();
                }
            }
            return RedirectToAction("ServiceItem");
        }
        //Get ServiceItem
        public JsonResult GetServiceItem(int? id)
        {
            var ServiceItems = _context.ServiceItems.Find(id);
            return Json(ServiceItems);
        }

        //**************************************** Purchases ****************************************

        //Show  
        public IActionResult Purchases( )
        {
             
            return View();
        }

        public IActionResult UpdatePurchases(PurchaseViewModel NewPurchase)
        {
            int hotelid = 0;
            if (TempData.ContainsKey("TempHotelId"))
            {
                hotelid = (int)TempData.Peek("TempHotelId");
            }
            // current user
            var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
           int PurchasesVoucherId = 0;
            if (NewPurchase.Id == 0)
            {
                NewPurchase.InsertedBy = userid;
                NewPurchase.InsertedDate = DateTime.Now;

                // insert service
                Purchase PurchasesVoucher = new Purchase();

                PurchasesVoucher.PurchaseDate = NewPurchase.PurchaseDate;
                PurchasesVoucher.NetPrice = NewPurchase.NetPrice;
                PurchasesVoucher.Vat = NewPurchase.Vat;
                PurchasesVoucher.TotalPrice = NewPurchase.Total;

                PurchasesVoucher.InsertedBy = userid;
                PurchasesVoucher.InsertedDate = DateTime.Now;


                PurchasesVoucher.HotelId = hotelid;
                PurchasesVoucher.VendorId = NewPurchase.VendorId;
                   
                _context.Purchases.Add(PurchasesVoucher);
                _context.SaveChanges();

                PurchasesVoucherId = PurchasesVoucher.Id;

                for (int i = 0; i < NewPurchase.Quantity.Length; i++)
                {
                    PurchaseItem PurchasesItems = new PurchaseItem();
                    PurchasesItems.Quantity = NewPurchase.Quantity[i];
                    PurchasesItems.UnitPrice = NewPurchase.UnitPrice[i];
                    PurchasesItems.TotalPrice = NewPurchase.TotalPrice[i];
                    PurchasesItems.PurchaseId = PurchasesVoucherId;

                    PurchasesItems.InsertedBy = userid;
                    PurchasesItems.InsertedDate = DateTime.Now;

                    PurchasesItems.AssetId = NewPurchase.AssetId[i];

                    _context.PurchaseItems.Add(PurchasesItems);
                    _context.SaveChanges();
                }
                // Return the purchaseId in the response
               
            }
            return Json(new { PurchasesVoucherId });
            //return RedirectToAction("Purchases", "Vouchers");
            //return RedirectToAction("PrintRoomPriceWithoutBreakfast", "Reports"); 
        }







    }
}
