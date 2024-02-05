using NileHotels.Data;
using NileHotels.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Globalization;
using Microsoft.AspNetCore.Http;
using System.Diagnostics.Contracts;

namespace HotelManagmentSystem.Controllers
{
    public class SettingsController : Controller
    {
        readonly ApplicationDbContext _context;
        public SettingsController(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }

        public IActionResult Index()
        {
            return View("Index");
        }

         
        public IActionResult QueryTest(int HotelId)
        {
            // Set session data
             TempData["TempHotelId"] = HotelId;
            TempData.Keep("HotelId");
          
            return Content("Data Saved");
        }
        public IActionResult QueryTest1( )
        {
            if (TempData.ContainsKey("TempHotelId"))
            {
                return Content("Data Saved");
            }

            return Content("Data don'Saved");
        }
       



        //**************************************** Asset ****************************************

        //Show Asset
        public IActionResult Asset()
        {

            List<Asset> Assets = _context.Assets.ToList();
            ViewData["Assets"] = Assets;
            return View(new Asset());

        }

        //Update Asset
        public IActionResult UpdateAsset(Asset NewAsset)
        {
            // current user
            var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            
            if (NewAsset.Id == 0)
            {
                NewAsset.InsertedBy = userid;
                NewAsset.InsertedDate = DateTime.Now;
                _context.Assets.Add(NewAsset);
                _context.SaveChanges();
            }
            else
            {
                var OldAsset = _context.Assets.Find(NewAsset.Id);
                if (OldAsset != null)
                {
                    OldAsset.NameAr = NewAsset.NameAr;
                    OldAsset.NameEn = NewAsset.NameEn;
                    OldAsset.SerialNo = NewAsset.SerialNo;
                    OldAsset.Decription = NewAsset.Decription;

                    OldAsset.NaturelofAsset = NewAsset.NaturelofAsset;
                    OldAsset.Price = NewAsset.Price;
                    OldAsset.SerialNo = NewAsset.SerialNo;
                    OldAsset.Decription = NewAsset.Decription;

                    OldAsset.HotelId = NewAsset.HotelId;
                    OldAsset.AssetTypeId = NewAsset.AssetTypeId;
                    OldAsset.UnitTypeId = NewAsset.UnitTypeId;

                    OldAsset.UpdatedBy = userid;
                    OldAsset.UpdatedDate = DateTime.Now;

                    _context.Entry(OldAsset).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    _context.SaveChanges();
                }
            }
            return RedirectToAction("Asset");
        }

        //Get Asset
        public JsonResult GetAsset(int? id)
        {
            var Assets = _context.Assets.Find(id);
            return Json(Assets);
        }

        //Delete Asset
        public IActionResult DeleteAsset(Asset NewAsset)
        {
            // current user
            var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var OldAsset = _context.Assets.Find(NewAsset.Id);
            if (OldAsset != null)
            {
                OldAsset.DeletedBy = userid;
                OldAsset.DeletedDate = DateTime.Now;

                _context.Entry(OldAsset).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
            }

            return RedirectToAction("Asset");

        }

        //GetAllAsset in hotel select list
        public IActionResult GetAllAsset()
        {

            int id = 0;
            if (TempData.ContainsKey("TempHotelId"))
            {
                id = (int)TempData.Peek("TempHotelId");
            }

            var Assets = (from r in _context.Assets

                          where r.DeletedBy == null && r.HotelId == id
                          select new
                          {
                              r.Id,
                              name = r.NameEn,
                          }).ToList();


            if (CultureInfo.CurrentCulture.Name.StartsWith("ar"))
            {
                Assets = (from r in _context.Assets

                          where r.DeletedBy == null && r.HotelId == id
                          select new
                          {
                              r.Id,
                              name = r.NameAr,
                          }).ToList();

            }
        
            return Json(Assets);

        }
         
        //GetAllAssetInHotel 
        public IActionResult GetAllAssetInHotel()
        {
            int id = 0;

            if (TempData.ContainsKey("TempHotelId"))
            {
                id = (int)TempData.Peek("TempHotelId");
            }
            //var Assets = _context.Assets.Where(c => c.HotelId == id).Where(a => a.DeletedBy == null);

            var Assets = (from ass in _context.Assets
                          join s in _context.StoreAssets on ass.Id equals  s.AssetId into storeAssets
                          from s in storeAssets.DefaultIfEmpty()
                          where ass.HotelId == id && ass.DeletedBy == null
                          select new
                          {
                              ass.Id,
                              ass.SerialNo,
                              assetName = ass.NameEn,
                              ass.NaturelofAsset,
                              ass.Price,
                              ass.Decription,
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
                              ass.Id,
                              ass.SerialNo,
                              assetName = ass.NameAr,
                              ass.NaturelofAsset,
                              ass.Price,
                              ass.Decription,
                              assetStatus = s == null ? "" : s.AssetStatusType.NameAr,
                              storename = s == null ? "" : s.Store.NameAr,
                              intailQty = s == null ? 0 :  s.IntailQty,
                              currentQty = s == null ? 0 : s.CurrentQty,
                              
                          }).ToList();

            } 

            return Json(Assets);

        }

        //GetAllAssetInRoom
        public IActionResult GetAllAssetInRoom(int id)
        {

            //var RoomAssets = _context.RoomAssets.Where(c => c.RoomId == id).Where(a => a.DeletedBy == null);
            //return Json(RoomAssets);

            var RoomAssets = (from ras in _context.RoomAssets
                              join ass in _context.Assets on ras.AssetId equals ass.Id
                              join ast in _context.AssetTypes on ras.AssetTypeId equals ast.Id
                              where ras.RoomId == id && ras.DeletedBy == null
                              select new
                              {
                                  ras.Id,
                                  ras.Qty,
                                  assetName = ass.NameEn,
                                  assetId = ass.Id,
                                  assettypeName = ast.NameEn
                              }).ToList();



            if (CultureInfo.CurrentCulture.Name.StartsWith("ar"))
            {
                RoomAssets = (from ras in _context.RoomAssets
                              join ass in _context.Assets on ras.AssetId equals ass.Id
                              join ast in _context.AssetTypes on ras.AssetTypeId equals ast.Id
                              where ras.RoomId == id && ras.DeletedBy == null
                              select new
                              {
                                  ras.Id,
                                  ras.Qty,
                                  assetName = ass.NameAr,
                                  assetId = ass.Id,
                                  assettypeName = ast.NameAr
                              }).ToList();

            } 
            return Json(RoomAssets);
        }

        //GetAllAssetInStore
        public IActionResult GetAllAssetInStore(int id)
        {
            //var StoreAssets = _context.StoreAssets.Where(c => c.StoreId == id).Where(a => a.DeletedBy == null);
            //return Json(StoreAssets);
            var StoreAssets = (from sa in _context.StoreAssets
                               join ass in _context.Assets on sa.AssetId equals ass.Id
                               join ast in _context.AssetStatusTypes on sa.AssetStatusTypeId equals ast.Id
                               where sa.StoreId == id && sa.DeletedBy == null
                               select new
                               {
                                   sa.Id,
                                   sa.IntailQty,
                                   sa.CurrentQty,
                                   assetName = ass.NameEn,
                                   assetId = ass.Id,
                                   ass.Price,
                                   assetStatus = ast.NameEn
                               }).ToList();




            if (CultureInfo.CurrentCulture.Name.StartsWith("ar"))
            {
                StoreAssets = (from sa in _context.StoreAssets
                               join ass in _context.Assets on sa.AssetId equals ass.Id
                               join ast in _context.AssetStatusTypes on sa.AssetStatusTypeId equals ast.Id
                               where sa.StoreId == id && sa.DeletedBy == null
                               select new
                               {
                                   sa.Id,
                                   sa.IntailQty,
                                   sa.CurrentQty,
                                   assetName = ass.NameAr,
                                   assetId = ass.Id,
                                   ass.Price,
                                   assetStatus = ast.NameAr
                               }).ToList();

            }



            return Json(StoreAssets);
        }

        //GetAllAssetInStore
        public IActionResult GetAllAssetByAssetType(int id)
        {
             
            var StoreAssets = (from ass in _context.Assets 
                               join ast in _context.AssetTypes on ass.AssetTypeId equals ast.Id
                               where ast.Id == id  && ass.DeletedBy == null
                               select new
                               {
                                   ass.Id, 
                                   assetName = ass.NameEn,
                                   assetId = ass.Id,
                                   ass.Price,
                                   assetStatus = ast.NameEn
                               }).ToList();




            if (CultureInfo.CurrentCulture.Name.StartsWith("ar"))
            {
                StoreAssets = (from ass in _context.Assets
                               join ast in _context.AssetTypes on ass.AssetTypeId equals ast.Id
                               where ast.Id == id && ass.DeletedBy == null
                               select new
                               {
                                   ass.Id,
                                   assetName = ass.NameAr,
                                   assetId = ass.Id,
                                   ass.Price,
                                   assetStatus = ast.NameAr
                               }).ToList();
           

            }
              
            return Json(StoreAssets);
        }

        //GetAllAssetInfo
        public IActionResult GetAllAssetInfo(int id)
        {
            var abc = (from ass in _context.Assets
                       join sa in _context.StoreAssets on ass.Id equals sa.AssetId
                       where ass.Id == id && sa.DeletedBy == null
                       select new
                       {
                           sa.Id,
                           sa.IntailQty,
                           sa.CurrentQty,
                           assetName = ass.NameAr,
                           assetId = ass.Id,
                           ass.Price
                       }).ToList();


            return Json(abc);
        }




        //**************************************** AssetStatusType ****************************************

        //Show AssetStatusType
        public IActionResult AssetStatus()
        {
            List<AssetStatusType> AssetStatus = _context.AssetStatusTypes.Where(a => a.DeletedBy == null).ToList();
            ViewData["AssetStatusType"] = AssetStatus;
            return View(new AssetStatusType());
        }

        //Update AssetStatusType
        public IActionResult UpdateAssetStatusType(AssetStatusType NewAssetStatusType)
        {
            // current user
            var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (NewAssetStatusType.Id == 0)
            {
                NewAssetStatusType.InsertedBy = userid;
                NewAssetStatusType.InsertedDate = DateTime.Now;
                _context.AssetStatusTypes.Add(NewAssetStatusType);
                _context.SaveChanges();
            }
            else
            {
                var OldAssetStatusType = _context.AssetStatusTypes.Find(NewAssetStatusType.Id);
                if (OldAssetStatusType != null)
                {
                    OldAssetStatusType.NameAr = NewAssetStatusType.NameAr;
                    OldAssetStatusType.NameEn = NewAssetStatusType.NameEn;

                    OldAssetStatusType.UpdatedBy = userid;
                    OldAssetStatusType.UpdatedDate = DateTime.Now;

                    _context.Entry(OldAssetStatusType).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    _context.SaveChanges();
                }
            }
            return RedirectToAction("AssetStatus");
        }

        //Get AssetStatusType
        public JsonResult GetAssetStatusType(int? id)
        {
            var AssetStatus = _context.AssetStatusTypes.Find(id);
            return Json(AssetStatus);
        }

        //Delete AssetStatusType
        public IActionResult DeleteAssetStatusType(AssetStatusType NewAssetStatusType)
        {
            // current user
            var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var OldAssetStatusType = _context.AssetStatusTypes.Find(NewAssetStatusType.Id);
            if (OldAssetStatusType != null)
            {
                OldAssetStatusType.DeletedBy = userid;
                OldAssetStatusType.DeletedDate = DateTime.Now;

                _context.Entry(OldAssetStatusType).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
            }

            return RedirectToAction("AssetStatusType");

        }

       
        //GetAllAssetStatus
        public IActionResult GetAllAssetStatus()
        {
            //var AssetStatuss = _context.AssetStatusTypes;
            var AssetStatuss = (from r in _context.AssetStatusTypes

                                where r.DeletedBy == null
                                select new
                                {
                                    r.Id,
                                    name = r.NameEn,
                                }).ToList();


            if (CultureInfo.CurrentCulture.Name.StartsWith("ar"))
            {
                AssetStatuss = (from r in _context.AssetStatusTypes

                                where r.DeletedBy == null
                                select new
                                {
                                    r.Id,
                                    name = r.NameAr,
                                }).ToList();
            }

            return Json(AssetStatuss);

        }


        //**************************************** AssetType ****************************************

        //Show AssetType
        public IActionResult AssetType()
        {
            List<AssetType> AssetType = _context.AssetTypes.Where(a => a.DeletedBy == null).ToList();
            ViewData["AssetTypes"] = AssetType;
            return View(new AssetType());
        }

        //Update AssetType
        public IActionResult UpdateAssetType(AssetType NewAssetTypes)
        {
            // current user
            var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (NewAssetTypes.Id == 0)
            {
                NewAssetTypes.InsertedBy = userid;
                NewAssetTypes.InsertedDate = DateTime.Now;
                _context.AssetTypes.Add(NewAssetTypes);
                _context.SaveChanges();
            }
            else
            {
                var OldAssetType = _context.AssetTypes.Find(NewAssetTypes.Id);
                if (OldAssetType != null)
                {
                    OldAssetType.NameAr = NewAssetTypes.NameAr;
                    OldAssetType.NameEn = NewAssetTypes.NameEn;
                    OldAssetType.UpdatedBy = userid;
                    OldAssetType.UpdatedDate = DateTime.Now;
                    _context.Entry(OldAssetType).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    _context.SaveChanges();
                }
            }
            return RedirectToAction("AssetType");
        }

        //Get AssetType
        public JsonResult GetAssetType(int? id)
        {
            var AssetTypes = _context.AssetTypes.Find(id);
            return Json(AssetTypes);
        }

        //Delete AssetType
        public IActionResult DeleteAssetType(AssetType NewAssetType)
        {
            // current user
            var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var OldAssetType = _context.AssetTypes.Find(NewAssetType.Id);
            if (OldAssetType != null)
            {
                OldAssetType.DeletedBy = userid;
                OldAssetType.DeletedDate = DateTime.Now;

                _context.Entry(OldAssetType).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
            }

            return RedirectToAction("AssetType");

        }

        //GetAllAssetType
        public IActionResult GetAllAssetType()
        {

            var AssetTypes = (from r in _context.AssetTypes

                              where r.DeletedBy == null
                              select new
                              {
                                  r.Id,
                                  name = r.NameEn,
                              }).ToList();


            if (CultureInfo.CurrentCulture.Name.StartsWith("ar"))
            {
                AssetTypes = (from r in _context.AssetTypes

                              where r.DeletedBy == null
                              select new
                              {
                                  r.Id,
                                  name = r.NameAr,
                              }).ToList();

            }


            return Json(AssetTypes);

        }



        // **************************************** City ****************************************

        //Show City
        public IActionResult City()
        {
            List<Country> Citys = _context.Country.Where(c => c.ParentId != 0).ToList();
            ViewData["Citys"] = Citys;
            return View(new Country());
        }

        //Update City
        public IActionResult UpdateCity(Country NewCity)
        {
            // current user
            var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (NewCity.Id == 0)
            {
                NewCity.InsertedBy = userid;
                NewCity.InsertedDate = DateTime.Now;
                _context.Country.Add(NewCity);
                _context.SaveChanges();
            }
            else
            {
                var OldCity = _context.Country.Find(NewCity.Id);
                if (OldCity != null)
                {
                    OldCity.NameAr = NewCity.NameAr;
                    OldCity.NameEn = NewCity.NameEn;
                    OldCity.ParentId = NewCity.ParentId;
                    OldCity.UpdatedBy = userid;
                    OldCity.UpdatedDate = DateTime.Now;
                    _context.Entry(OldCity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    _context.SaveChanges();
                }
            }
            return RedirectToAction("City");
        }

        //Get City
        public JsonResult GetCity(int? id)
        {
            var Citys = _context.Country.Find(id);
            return Json(Citys);
        }

        //Delete city
        public IActionResult DeleteCity(Country NewCity)
        {
            // current user
            var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var OldCity = _context.Country.Find(NewCity.Id);
            if (OldCity != null)
            {
                OldCity.DeletedBy = userid;
                OldCity.DeletedDate = DateTime.Now;

                _context.Entry(OldCity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
            }

            return RedirectToAction("City");

        }


        //GetCityOnly
        public IActionResult GetCitiesOnly()
        {
            //var Citys = _context.Country.Where(c => c.ParentId != 0).Where(a => a.DeletedBy == null);

            var Citys = (from t in _context.Country

                         where t.ParentId != 0 && t.DeletedBy == null
                         select new
                         {
                             t.Id,
                             name = t.NameEn,
                         }).ToList();


            if (CultureInfo.CurrentCulture.Name.StartsWith("ar"))
            {
                Citys = (from t in _context.Country

                         where t.ParentId != 0 && t.DeletedBy == null
                         select new
                         {
                             t.Id,
                             name = t.NameAr,
                         }).ToList();

            }


            return Json(Citys);

        }


        //GetAllCountry
        public IActionResult GetAllCountry()
        {
            //var Citys = _context.Country.Where(c => c.ParentId == 0).Where(a => a.DeletedBy == null);
            var Countries = (from t in _context.Country

                             where t.ParentId == 0 && t.DeletedBy == null
                             select new
                             {
                                 t.Id,
                                 name = t.NameEn,
                             }).ToList();


            if (CultureInfo.CurrentCulture.Name.StartsWith("ar"))
            {
                Countries = (from t in _context.Country

                             where t.ParentId == 0 && t.DeletedBy == null
                             select new
                             {
                                 t.Id,
                                 name = t.NameAr,
                             }).ToList();

            }

            return Json(Countries);

        }

        public IActionResult GetCountryCities(int id)
        {
            var Citys = _context.Country.Where(c => c.ParentId == id).Where(a => a.DeletedBy == null);
            return Json(Citys);

        }


        //**************************************** Company **************************************** 

        //Show Company 
        public IActionResult Company()
        {
            
           
            return View(new Company());
        }

        //GetAllCompany
        public IActionResult GetAllCompany()
        {

            var lan = CultureInfo.CurrentCulture.Name.StartsWith("ar");

            var Companys = (from c in _context.Company

                            where c.DeletedBy == null
                            select new
                            {
                                c.Id,
                                name = lan ? c.NameAr : c.NameEn,
                                fullAddress = lan ? c.FullAddressAr : c.FullAddressEn,
                                vatNo = c.VatNo,
                                city = lan ? c.Country.NameAr : c.Country.NameEn
                            }).ToList();
              
            return Json(Companys);

        }


        //Update Company 
        public IActionResult UpdateCompany(Company NewCompany)
        {
            // current user
            var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (NewCompany.Id == 0)
            {
                NewCompany.InsertedBy = userid;
                NewCompany.InsertedDate = DateTime.Now;
                _context.Company.Add(NewCompany);
                _context.SaveChanges();
            }
            else
            {
                var OldCompany = _context.Company.Find(NewCompany.Id);
                if (OldCompany != null)
                {
                    OldCompany.NameAr = NewCompany.NameAr;
                    OldCompany.NameEn = NewCompany.NameEn;


                    OldCompany.FullAddressAr = NewCompany.FullAddressAr;
                    OldCompany.FullAddressEn = NewCompany.FullAddressEn;

                    OldCompany.BuildingNo = NewCompany.BuildingNo;
                    OldCompany.ZipeCode = NewCompany.ZipeCode;
                    OldCompany.VatNo = NewCompany.VatNo;

                    OldCompany.CountryId = NewCompany.CountryId;

                    OldCompany.UpdatedBy = userid;
                    OldCompany.UpdatedDate = DateTime.Now;

                    _context.Entry(OldCompany).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    _context.SaveChanges();
                }
            }
            return RedirectToAction("Company");
        }

        // Update Company Contact
        public IActionResult UpdateCompanyContact(CompanyContact NewCompanyContact)
        {
            // current user
            var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);


            if (NewCompanyContact.Id == 0)
            {
                NewCompanyContact.InsertedBy = userid;
                NewCompanyContact.InsertedDate = DateTime.Now;
                _context.CompanyContact.Add(NewCompanyContact);
                _context.SaveChanges();
            }
            else
            {
                var OldCompanyContact = _context.CompanyContact.Find(NewCompanyContact.Id);
                if (OldCompanyContact != null)
                {
                    OldCompanyContact.Value = NewCompanyContact.Value;
                    OldCompanyContact.Description = NewCompanyContact.Description;

                    OldCompanyContact.CompanyId = NewCompanyContact.CompanyId;
                    OldCompanyContact.ContactTypeId = NewCompanyContact.ContactTypeId;

                    _context.Entry(OldCompanyContact).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    _context.SaveChanges();
                }
            }
            return RedirectToAction("Company");
        }
         
        //Get Company 
        public JsonResult GetCompany(int? id)
        {
            var Companys = _context.Company.Find(id);
            return Json(Companys);
        }

        //Delete Company
        public IActionResult DeleteCompany(Company NewCompany)
        {
            // current user
            var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var OldCompany = _context.Company.Find(NewCompany.Id);
            if (OldCompany != null)
            {
                OldCompany.DeletedBy = userid;
                OldCompany.DeletedDate = DateTime.Now;

                _context.Entry(OldCompany).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
            }

            return RedirectToAction("Company");

        }

        //GetAllCompanycontact
        public IActionResult GetAllCompanycontact(int id)
        {
            var abc = (from c in _context.Company

                       join companycontact in _context.CompanyContact on c.Id equals companycontact.CompanyId
                       join contactType in _context.ContactType on companycontact.ContactTypeId equals contactType.Id

                       where c.Id == id && c.DeletedBy == null
                       select new
                       {
                           c.Id,
                           companycontactid = companycontact.Id,


                           contactvalue = companycontact.Value,
                           contactdescription = companycontact.Description,
                           contacttypenam = contactType.NameAr,

                       }).ToList();

            return Json(abc);


        }




        //**************************************** Country ****************************************

        //Show Country
        public IActionResult Country()
        {
            List<Country> Countrys = _context.Country.Where(c => c.ParentId == 0).Where(a => a.DeletedBy == null).ToList();
            ViewData["Countrys"] = Countrys;
            return View(new Country());
        }
        //Update Country
        public IActionResult UpdateCountry(Country NewCountry)
        {
            // current user
            var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (NewCountry.Id == 0)
            {
                NewCountry.InsertedBy = userid;
                NewCountry.InsertedDate = DateTime.Now;
                _context.Country.Add(NewCountry);
                _context.SaveChanges();
            }
            else
            {
                var OldCountry = _context.Country.Find(NewCountry.Id);
                if (OldCountry != null)
                {
                    OldCountry.NameAr = NewCountry.NameAr;
                    OldCountry.NameEn = NewCountry.NameEn;
                    OldCountry.UpdatedBy = userid;
                    OldCountry.UpdatedDate = DateTime.Now;
                    _context.Entry(OldCountry).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    _context.SaveChanges();
                }
            }
            return RedirectToAction("Country");
        }
        //Get Country
        public JsonResult GetCountry(int? id)
        {
            var Countrys = _context.Country.Find(id);
            return Json(Countrys);
        }

        //Delete Country
        public IActionResult DeleteCountry(Country NewCountry)
        {
            // current user
            var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var OldCountry = _context.Country.Find(NewCountry.Id);
            if (OldCountry != null)
            {
                OldCountry.DeletedBy = userid;
                OldCountry.DeletedDate = DateTime.Now;

                _context.Entry(OldCountry).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
            }

            return RedirectToAction("Country");

        }




        //**************************************** ContactType ****************************************

        //Show ContactType
        public IActionResult ContactType()
        {
            List<ContactType> ContactTypes = _context.ContactType.Where(a => a.DeletedBy == null).ToList();
            ViewData["ContactTypes"] = ContactTypes;
            return View(new ContactType());
        }

        //Update ContactType
        public IActionResult UpdateContactType(ContactType NewContactType)
        {
            // current user
            var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (NewContactType.Id == 0)
            {
                NewContactType.InsertedBy = userid;
                NewContactType.InsertedDate = DateTime.Now;
                _context.ContactType.Add(NewContactType);
                _context.SaveChanges();
            }
            else
            {
                var OldContactType = _context.ContactType.Find(NewContactType.Id);
                if (OldContactType != null)
                {
                    OldContactType.NameAr = NewContactType.NameAr;
                    OldContactType.NameEn = NewContactType.NameEn;
                    OldContactType.UpdatedBy = userid;
                    OldContactType.UpdatedDate = DateTime.Now;
                    _context.Entry(OldContactType).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    _context.SaveChanges();
                }
            }
            return RedirectToAction("ContactType");
        }

        //Get ContactType
        public JsonResult GetContactType(int? id)
        {
            var ContactTypes = _context.ContactType.Find(id);
            return Json(ContactTypes);
        }

        //Delete ContactType
        public IActionResult DeleteContactType(ContactType NewContactType)
        {
            // current user
            var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var OldContactType = _context.ContactType.Find(NewContactType.Id);
            if (OldContactType != null)
            {
                OldContactType.DeletedBy = userid;
                OldContactType.DeletedDate = DateTime.Now;

                _context.Entry(OldContactType).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
            }

            return RedirectToAction("ContactType");

        }

        //GetAllContactType
        public IActionResult GetAllContactType()
        {
            //var ContactTypes = _context.ContactType.Where(a => a.DeletedBy == null);
            var ContactTypes = (from t in _context.ContactType

                                where   t.DeletedBy == null
                             select new
                             {
                                 t.Id,
                                 name = t.NameEn,
                             }).ToList();


            if (CultureInfo.CurrentCulture.Name.StartsWith("ar"))
            {
                ContactTypes = (from t in _context.ContactType

                                where t.DeletedBy == null
                                select new
                                {
                                    t.Id,
                                    name = t.NameAr,
                                }).ToList();
            }
            return Json(ContactTypes);

        }


        //**************************************** Currencies ****************************************

        //Show Currencies
        public IActionResult Currencies()
        {
            List<Curncy> Curncy = _context.Curncy.Where(a => a.DeletedBy == null).ToList();
            ViewData["Currenices"] = Curncy;
            return View(new Curncy());
        }

        //Update Currency
        public IActionResult UpdateCurrency(Curncy NewCurncy)
        {
            // current user
            var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (NewCurncy.Id == 0)
            {
                NewCurncy.InsertedBy = userid;
                NewCurncy.InsertedDate = DateTime.Now;
                _context.Curncy.Add(NewCurncy);
                _context.SaveChanges();
            }
            else
            {
                var oldCurncy = _context.Curncy.Find(NewCurncy.Id);
                if (oldCurncy != null)
                {
                    oldCurncy.NameAr = NewCurncy.NameAr;
                    oldCurncy.NameEn = NewCurncy.NameEn;
                    oldCurncy.UpdatedBy = userid;
                    oldCurncy.UpdatedDate = DateTime.Now;
                    _context.Entry(oldCurncy).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    _context.SaveChanges();
                }
            }
            return RedirectToAction("Currencies");
        }

        //Get Currency
        public JsonResult GetCurrency(int? id)
        {
            var Curncy = _context.Curncy.Find(id);
            return Json(Curncy);
        }

        // Delete Currency
        public IActionResult DeleteCurrency(Curncy NewCurrency)
        {
            // current user
            var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var OldCurrency = _context.Curncy.Find(NewCurrency.Id);
            if (OldCurrency != null)
            {
                OldCurrency.DeletedBy = userid;
                OldCurrency.DeletedDate = DateTime.Now;

                _context.Entry(OldCurrency).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
            }

            return RedirectToAction("Currencies");

        }

        //GetAllCurrency
        public IActionResult GetAllCurrency()
        {
            //var Curncy = _context.Curncy.Where(a => a.DeletedBy == null);

            var Curncies = (from t in _context.Curncy

                            where  t.DeletedBy == null
                             select new
                             {
                                 t.Id,
                                 name = t.NameEn,
                             }).ToList();


            if (CultureInfo.CurrentCulture.Name.StartsWith("ar"))
            {
                Curncies = (from t in _context.Curncy

                            where t.DeletedBy == null
                            select new
                            {
                                t.Id,
                                name = t.NameAr,
                            }).ToList();

            }
            return Json(Curncies);

        }


        //**************************************** Customer ****************************************

        //Show Customer
        public IActionResult Customer()
        {
            List<Customer> Customers = _context.Customers.ToList();
            ViewData["Customers"] = Customers;
            return View(new Customer());
        }

        //Update Customer
        public IActionResult UpdateCustomer(Customer NewCustomer)
        {
            // current user
            var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (NewCustomer.Id == 0)
            {
                NewCustomer.InsertedBy = userid;
                NewCustomer.InsertedDate = DateTime.Now;
                _context.Customers.Add(NewCustomer);
                _context.SaveChanges();
            }
            else
            {
                var OldCustomer = _context.Customers.Find(NewCustomer.Id);
                if (OldCustomer != null)
                {
                    OldCustomer.FirstName = NewCustomer.FirstName;
                    OldCustomer.LastName = NewCustomer.LastName;

                    OldCustomer.IsShare = NewCustomer.IsShare;
                    OldCustomer.IdValue = NewCustomer.IdValue;
                    OldCustomer.CountryId = NewCustomer.CountryId;
                    OldCustomer.IdTypeId = NewCustomer.IdTypeId;
                    OldCustomer.UpdatedBy = userid;
                    OldCustomer.UpdatedDate = DateTime.Now;
                    _context.Entry(OldCustomer).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    _context.SaveChanges();
                }
            }
            return RedirectToAction("Customer");
        }
        //Get Customer
        public JsonResult GetCustomer(int? id)
        {
            var Customers = _context.Customers.Find(id);
            return Json(Customers);
        }

        // Delete Customer
        public IActionResult DeleteCustomer(Customer NewCustomer)
        {
            // current user
            var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var OldCustomer = _context.Customers.Find(NewCustomer.Id);
            if (OldCustomer != null)
            {
                OldCustomer.DeletedBy = userid;
                OldCustomer.DeletedDate = DateTime.Now;

                _context.Entry(OldCustomer).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
            }

            return RedirectToAction("Customer");

        }

        //Get customer by id value 
        public IActionResult GetCustomerbyId(string id , string idtype,string name )
        {

            var abc = (from c in _context.Customers 
                         where (c.IdValue == id ) || (c.IdValue == id && c.IdType.NameEn == idtype)  
                       //&& e.DeletedBy == null
                       select new
                       {
                           c.Id,
                           c.FirstName,
                           c.LastName,
                           c.IsShare,
                           c.IsCompony,
                           c.IdValue,
                           c.HotelId,
                           c.CountryId,
                           c.IdTypeId,
                           idType = c.IdType.NameEn,
                           CountryName = c.Country.NameEn,
                           hotelname = c.Hotel.NameEn

                       }).ToList();


            if (CultureInfo.CurrentCulture.Name.StartsWith("ar"))
            {
                abc = (from c in _context.Customers 
                       where (c.IdValue == id ) || (c.IdValue == id && c.IdType.NameEn == idtype)
                       //&& e.DeletedBy == null
                       select new
                       {
                           c.Id,
                           c.FirstName,
                           c.LastName,
                           c.IsShare,
                           c.IsCompony,
                           c.IdValue,
                           c.HotelId,
                           c.CountryId,
                           c.IdTypeId,
                           idType = c.IdType.NameAr,
                           CountryName = c.Country.NameAr,
                           hotelname = c.Hotel.NameAr

                       }).ToList();
            }


            if (abc.Count > 0)
            {
                return Json(abc.FirstOrDefault());
            }
            else
            {
                return Json(false);
            }

        }

        //Get customer In HotelIdValue
        public IActionResult GetAllCustomerInHotel()
        {
            //var Customers = _context.Customers.Where(c => c.HotelId == id).Where(a => a.DeletedBy == null);
            //return Json(Customers);

            int id = 0;
            if (TempData.ContainsKey("TempHotelId"))
            {
                id = (int)TempData.Peek("TempHotelId");
            }


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
                                 countryName = c.Country.NameEn,
                                 idType=c.IdType.NameEn
                             }).ToList();


            if (CultureInfo.CurrentCulture.Name.StartsWith("ar"))
            {
                Customers = (from c in _context.Customers
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
                                 countryName = c.Country.NameAr,
                                 idType = c.IdType.NameAr
                             }).ToList();

            }

            return Json(Customers);
        }

        // GetAllCustomercontact
        public IActionResult GetAllCustomercontact(int id)
        {
            var abc = (from c in _context.Customers

                       join customercontact in _context.CustomerContacts on c.Id equals customercontact.CustomerId
                       join contactType in _context.ContactType on customercontact.ContactTypeId equals contactType.Id

                       where c.Id == id && c.DeletedBy == null
                       select new
                       {
                           c.Id,
                           customercontactid = customercontact.Id,
                           c.FirstName,
                           c.LastName,
                           c.HotelId,

                           contactvalue = customercontact.Value,
                           contactdescription = customercontact.Description,
                           contacttypenam = contactType.NameAr,

                       }).ToList();

            return Json(abc);


        }

        //**************************************** CustomerContact ****************************************

        //Show CustomerContact
        public IActionResult CustomerContact()
        {
            List<CustomerContact> CustomerContacts = _context.CustomerContacts.ToList();
            ViewData["CustomerContacts"] = CustomerContacts;
            return View(new CustomerContact());
        }

        //Update CustomerContact
        public IActionResult UpdateCustomerContact(CustomerContact NewCustomerContact)
        {
            // current user
            var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
           
               
                if (NewCustomerContact.Id == 0)
            {
                NewCustomerContact.InsertedBy = userid;
                NewCustomerContact.InsertedDate = DateTime.Now;
                _context.CustomerContacts.Add(NewCustomerContact);
                _context.SaveChanges();
            }
            else
            {
                var OldCustomerContact = _context.CustomerContacts.Find(NewCustomerContact.Id);
                if (OldCustomerContact != null)
                {
                    OldCustomerContact.Value = NewCustomerContact.Value;
                    OldCustomerContact.Description = NewCustomerContact.Description;

                    OldCustomerContact.CustomerId = NewCustomerContact.CustomerId;
                    OldCustomerContact.ContactTypeId = NewCustomerContact.ContactTypeId;

                    _context.Entry(OldCustomerContact).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    _context.SaveChanges();
                }
            }
            return RedirectToAction("Customer");
        }
        //Get CustomerContact
        public JsonResult GetCustomerContact(int? id)
        {
            var CustomerContacts = _context.CustomerContacts.Find(id);
            return Json(CustomerContacts);
        }

        // Delete CustomerContact
        public IActionResult DeleteCustomerContact(CustomerContact NewCustomerContact)
        {
            // current user
            var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var OldCustomerContact = _context.CustomerContacts.Find(NewCustomerContact.Id);
            if (OldCustomerContact != null)
            {
                OldCustomerContact.DeletedBy = userid;
                OldCustomerContact.DeletedDate = DateTime.Now;

                _context.Entry(OldCustomerContact).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
            }

            return RedirectToAction("CustomerContact");

        }



        //**************************************** Employee **************************************** 

        //Show Employee
        public IActionResult Employee()
        {
            List<Employee> Employees = _context.Employees.ToList();
            ViewData["Employees"] = Employees;
            return View(new Employee());
        }

        //Update Employee
        public IActionResult UpdateEmployee(Employee NewEmployee)
        {
            // current user
            var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (NewEmployee.Id == 0)
            {
                NewEmployee.InsertedBy = userid;
                NewEmployee.InsertedDate = DateTime.Now;
                _context.Employees.Add(NewEmployee);
                _context.SaveChanges();
            }
            else
            {
                var OldEmployee = _context.Employees.Find(NewEmployee.Id);
                if (OldEmployee != null)
                {
                    OldEmployee.NameAr = NewEmployee.NameAr;
                    OldEmployee.NameEn = NewEmployee.NameEn;

                    OldEmployee.BirthDate = NewEmployee.BirthDate;
                    OldEmployee.IdNumber = NewEmployee.IdNumber;

                    OldEmployee.HotelId = NewEmployee.HotelId;
                    OldEmployee.CountryId = NewEmployee.CountryId;
                    OldEmployee.IdTypeId = NewEmployee.IdTypeId;

                    OldEmployee.UpdatedBy = userid;
                    OldEmployee.UpdatedDate = DateTime.Now;

                    _context.Entry(OldEmployee).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    _context.SaveChanges();
                }
            }
            return RedirectToAction("Employee");
        }

        //Get Employee
        public JsonResult GetEmployee(int? id)
        {
            var Employees = _context.Employees.Find(id);
            return Json(Employees);
        }

        //Delete Employee
        public IActionResult DeleteEmployee(Employee NewEmployee)
        {
            // current user
            var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var OldEmployee = _context.Employees.Find(NewEmployee.Id);
            if (OldEmployee != null)
            {
                OldEmployee.DeletedBy = userid;
                OldEmployee.DeletedDate = DateTime.Now;

                _context.Entry(OldEmployee).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
            }

            return RedirectToAction("Employee");

        }

        public JsonResult GetAllEmployee()
        {
            var Employees = _context.Employees.Where(a => a.DeletedBy == null);
            return Json(Employees);
        }

        //GetAllEmployeeInHotel
        public IActionResult GetAllEmployeeInHotel()
        {
            //    var Employees = _context.Employees.Where(c => c.HotelId == id).Where(a => a.DeletedBy == null);
            //    return Json(Employees);

            int id = 0;

            if (TempData.ContainsKey("TempHotelId"))
            {
                id = (int)TempData.Peek("TempHotelId");
            }

            var Employees = (from e in _context.Employees

                             where e.HotelId == id && e.DeletedBy == null
                             select new
                             {
                                 e.Id,
                                 name = e.NameEn,
                                 birthDate = e.BirthDate.Date.ToString(),
                                 e.IdNumber,
                                 e.HotelId,
                                 e.CountryId,
                                 e.IdTypeId,
                                 idType = e.IdType.NameEn,
                                 countryName = e.Country.NameEn
                             }).ToList();


            if (CultureInfo.CurrentCulture.Name.StartsWith("ar"))
            {
                Employees = (from e in _context.Employees 
                             where e.HotelId == id && e.DeletedBy == null
                             select new
                             {
                                 e.Id,
                                 name = e.NameAr,
                                 birthDate = e.BirthDate.Date.ToString(),
                                 e.IdNumber,
                                 e.HotelId,
                                 e.CountryId,
                                 e.IdTypeId,
                                 idType= e.IdType.NameAr,
                                 countryName = e.Country.NameAr
                             }).ToList();
            }



            return Json(Employees);

        }

        //Get Employee by id value 
        public IActionResult GetEmployeebyId(int id, string idtype, string name)
        {

            var abc = (from e in _context.Employees
                       where (e.IdNumber == id) || (e.IdNumber == id && e.IdType.NameEn == idtype)
                       //&& e.DeletedBy == null
                       select new
                       {
                           e.Id,
                           name = e.NameEn,
                           e.IdNumber,
                           e.HotelId,
                           e.CountryId,
                           e.IdTypeId,
                           idType = e.IdType.NameEn,
                           CountryName = e.Country.NameEn,
                           hotelname = e.Hotel.NameEn,
                           birthDate = e.BirthDate.Date.ToString()
                       }).ToList();


            if (CultureInfo.CurrentCulture.Name.StartsWith("ar"))
            {
                abc = (from e in _context.Employees
                       where (e.IdNumber == id) || (e.IdNumber == id && e.IdType.NameEn == idtype)
                       //&& e.DeletedBy == null
                       select new
                       {
                           e.Id,
                           name = e.NameAr,
                           e.IdNumber,
                           e.HotelId,
                           e.CountryId,
                           e.IdTypeId,
                           idType = e.IdType.NameAr,
                           CountryName = e.Country.NameAr,
                           hotelname = e.Hotel.NameAr,
                           birthDate = e.BirthDate.Date.ToString()

                       }).ToList();
            }


            if (abc.Count > 0)
            {
                return Json(abc.FirstOrDefault());
            }
            else
            {
                return Json(false);
            }

        }


        //**************************************** Hotel **************************************** 

        //Show Hotel 
        public IActionResult Hotel()
        {
            List<Hotel> Hotels = _context.Hotels.Where(a => a.DeletedBy == null).ToList();
            ViewData["Hotels"] = Hotels;
            return View(new Hotel());
        }

        //Update Hotel 
        public IActionResult UpdateHotel(Hotel NewHotel)
        {
            // current user
            var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (NewHotel.Id == 0)
            {
                NewHotel.InsertedBy = userid;
                NewHotel.InsertedDate = DateTime.Now;
                _context.Hotels.Add(NewHotel);
                _context.SaveChanges();
            }
            else
            {
                var OldHotel = _context.Hotels.Find(NewHotel.Id);
                if (OldHotel != null)
                {
                    OldHotel.NameAr = NewHotel.NameAr;
                    OldHotel.NameEn = NewHotel.NameEn;

                    OldHotel.FloorNo = NewHotel.FloorNo;
                    OldHotel.RoomNo = NewHotel.RoomNo;

                    OldHotel.FullAddressAr = NewHotel.FullAddressAr;
                    OldHotel.FullAddressEn = NewHotel.FullAddressEn;

                    OldHotel.gps = NewHotel.gps;
                    OldHotel.BuildingNo = NewHotel.BuildingNo;

                    OldHotel.PostBox = NewHotel.PostBox;
                    OldHotel.ZipeCode = NewHotel.ZipeCode;

                    OldHotel.CheckInTime = NewHotel.CheckInTime;
                    OldHotel.CheckOut = NewHotel.CheckOut;

                    OldHotel.ActualCheckOut = NewHotel.ActualCheckOut;
                    OldHotel.VatNo = NewHotel.VatNo;

                    OldHotel.CR = NewHotel.CR;
                    OldHotel.Logo = NewHotel.Logo;
                    OldHotel.CountryId = NewHotel.CountryId;

                    OldHotel.UpdatedBy = userid;
                    OldHotel.UpdatedDate = DateTime.Now;

                    _context.Entry(OldHotel).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    _context.SaveChanges();
                }
            }
            return RedirectToAction("Hotel");
        }
         
        //Get Hotel 
       public JsonResult GetHotel()
        {
            int id = 0;
            

            if (TempData.ContainsKey("TempHotelId"))
            {
                
                id = (int)TempData.Peek("TempHotelId");
            }

            var Hotels = (from h in _context.Hotels

                          where h.Id == id //&& e.DeletedBy == null
                          select new
                          {
                              h.Id,
                              name = h.NameAr,
                          }).ToList();

            
            if (CultureInfo.CurrentCulture.Name.StartsWith("ar"))
            {
                Hotels = (from h in _context.Hotels

                          where h.Id == id //&& e.DeletedBy == null
                          select new
                          {
                              h.Id,
                              name = h.NameAr,
                          }).ToList();

            }
            else
            {
                Hotels = (from h in _context.Hotels

                          where h.Id == id //&& e.DeletedBy == null
                          select new
                          {
                              h.Id,
                              name = h.NameEn,
                          }).ToList();

            }



            return Json(Hotels);
        }

        
        public JsonResult GetHotelbyid(int? id)
        {
            var Hotels = _context.Hotels.Find(id);
            return Json(Hotels);
        }


        //Delete Hotel
        public IActionResult DeleteHotel(Hotel NewHotel)
        {
            // current user
            var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var OldHotel = _context.Hotels.Find(NewHotel.Id);
            if (OldHotel != null)
            {
                OldHotel.DeletedBy = userid;
                OldHotel.DeletedDate = DateTime.Now;

                _context.Entry(OldHotel).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
            }

            return RedirectToAction("Hotel");

        }

        // GetAllHotelcontact
        public IActionResult GetAllHotelcontact(int id)
        {
            var abc = (from h in _context.Hotels

                       join hotelcontact in _context.HotelContacts on h.Id equals hotelcontact.HotelId
                       join contactType in _context.ContactType on hotelcontact.ContactTypeId equals contactType.Id

                       where h.Id == id && h.DeletedBy == null
                       select new
                       {
                           h.Id,
                           hotelcontactid = hotelcontact.Id,
                           contactvalue = hotelcontact.Value,
                           contactdescription = hotelcontact.Description,
                           contacttypenam = contactType.NameAr,

                       }).ToList();

            return Json(abc);


        }

        //GetAllHotel 
        public IActionResult GetAllHotel()
        {
            var Hotels = (from h in _context.Hotels

                          where h.DeletedBy == null
                          select new
                          {
                              h.Id,
                              name = h.NameEn,
                          }).ToList();


            if (CultureInfo.CurrentCulture.Name.StartsWith("ar"))
            {
                Hotels = (from h in _context.Hotels

                          where h.DeletedBy == null
                          select new
                          {
                              h.Id,
                              name = h.NameAr,
                          }).ToList();

            }

            return Json(Hotels);

        }


        //**************************************** HotelContact **************************************** 

        //Show HotelContact
        public IActionResult HotelContact()
        {
            List<HotelContact> HotelContacts = _context.HotelContacts.ToList();
            ViewData["HotelContacts"] = HotelContacts;
            return View(new HotelContact());
        }

        //Update HotelContact
        public IActionResult UpdateHotelContact(HotelContact NewHotelContact)
        {
            // current user
            var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (NewHotelContact.Id == 0)
            {
                NewHotelContact.InsertedBy = userid;
                NewHotelContact.InsertedDate = DateTime.Now;
                _context.HotelContacts.Add(NewHotelContact);
                _context.SaveChanges();
            }
            else
            {
                var OldHotelContact = _context.HotelContacts.Find(NewHotelContact.Id);
                if (OldHotelContact != null)
                {
                    OldHotelContact.Value = NewHotelContact.Value;
                    OldHotelContact.Description = NewHotelContact.Description;

                    OldHotelContact.HotelId = NewHotelContact.HotelId;
                    OldHotelContact.ContactTypeId = NewHotelContact.ContactTypeId;

                    OldHotelContact.UpdatedBy = userid;
                    OldHotelContact.UpdatedDate = DateTime.Now;
                    _context.Entry(OldHotelContact).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    _context.SaveChanges();
                }
            }
            return RedirectToAction("Hotel");
        }

        //Get HotelContact
        public JsonResult GetHotelContact(int? id)
        {
            var HotelContacts = _context.HotelContacts.Find(id);
            return Json(HotelContacts);
        }




        //****************************************  IdType **************************************** 

        //Show IdType
        public IActionResult IdType()
        {
            List<IdType> IdTypes = _context.IdType.Where(a => a.DeletedBy == null).ToList();
            ViewData["IdTypes"] = IdTypes;
            return View(new IdType());
        }

        //Update IdType
        public IActionResult UpdateIdType(IdType NewIdType)
        {
            // current user
            var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (NewIdType.Id == 0)
            {
                NewIdType.InsertedBy = userid;
                NewIdType.InsertedDate = DateTime.Now;
                _context.IdType.Add(NewIdType);
                _context.SaveChanges();
            }
            else
            {
                var OldIdType = _context.IdType.Find(NewIdType.Id);
                if (OldIdType != null)
                {
                    OldIdType.NameAr = NewIdType.NameAr;
                    OldIdType.NameEn = NewIdType.NameEn;
                    OldIdType.UpdatedBy = userid;
                    OldIdType.UpdatedDate = DateTime.Now;
                    _context.Entry(OldIdType).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    _context.SaveChanges();
                }
            }
            return RedirectToAction("IdType");
        }

        //Get IdType
        public JsonResult GetIdType(int? id)
        {
            var IdTypes = _context.IdType.Find(id);
            return Json(IdTypes);
        }

        //Delete IdType
        public IActionResult DeleteIdType(IdType NewIdType)
        {
            // current user
            var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var OldIdType = _context.IdType.Find(NewIdType.Id);
            if (OldIdType != null)
            {
                OldIdType.DeletedBy = userid;
                OldIdType.DeletedDate = DateTime.Now;

                _context.Entry(OldIdType).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
            }

            return RedirectToAction("IdType");

        }

        //GetAllIdType
        public IActionResult GetAllIdType()
        {

            var IdTypes = (from t in _context.IdType

                           where t.DeletedBy == null
                           select new
                           {
                               t.Id,
                               name = t.NameEn,
                           }).ToList();


            if (CultureInfo.CurrentCulture.Name.StartsWith("ar"))
            {
                IdTypes = (from t in _context.IdType

                           where t.DeletedBy == null
                           select new
                           {
                               t.Id,
                               name = t.NameAr,
                           }).ToList();

            }

            return Json(IdTypes);

        }


        //**************************************** PaymentType ****************************************

        //Show PaymentType
        public IActionResult PaymentType()
        {
            List<PaymentType> PaymentTypes = _context.PaymentTypes.Where(a => a.DeletedBy == null).ToList();
            ViewData["PaymentTypes"] = PaymentTypes;
            return View(new PaymentType());
        }

        //Update PaymentType
        public IActionResult UpdatePaymentType(PaymentType NewPaymentType)
        {
            // current user
            var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (NewPaymentType.Id == 0)
            {
                NewPaymentType.InsertedBy = userid;
                NewPaymentType.InsertedDate = DateTime.Now;
                _context.PaymentTypes.Add(NewPaymentType);
                _context.SaveChanges();
            }
            else
            {
                var OldPaymentType = _context.PaymentTypes.Find(NewPaymentType.Id);
                if (OldPaymentType != null)
                {
                    OldPaymentType.NameAr = NewPaymentType.NameAr;
                    OldPaymentType.NameEn = NewPaymentType.NameEn;
                    OldPaymentType.UpdatedBy = userid;
                    OldPaymentType.UpdatedDate = DateTime.Now;
                    _context.Entry(OldPaymentType).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    _context.SaveChanges();
                }
            }
            return RedirectToAction("PaymentType");
        }

        //Get PaymentType
        public JsonResult GetPaymentType(int? id)
        {
            var PaymentTypes = _context.PaymentTypes.Find(id);
            return Json(PaymentTypes);
        }

        //Delete PaymentType
        public IActionResult DeletePaymentType(PaymentType NewPaymentType)
        {
            // current user
            var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var OldPaymentType = _context.PaymentTypes.Find(NewPaymentType.Id);
            if (OldPaymentType != null)
            {
                OldPaymentType.DeletedBy = userid;
                OldPaymentType.DeletedDate = DateTime.Now;

                _context.Entry(OldPaymentType).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
            }

            return RedirectToAction("PaymentType");

        }

        //GetAllPayment
        

        //GetAllPaymentType
        public IActionResult GetAllPaymentType()
        {
            var PaymentTypes = (from t in _context.PaymentTypes

                                where  t.DeletedBy == null
                             select new
                             {
                                 t.Id,
                                 name = t.NameEn,
                             }).ToList();


            if (CultureInfo.CurrentCulture.Name.StartsWith("ar"))
            {
                PaymentTypes = (from t in _context.PaymentTypes

                                where t.DeletedBy == null
                                select new
                                {
                                    t.Id,
                                    name = t.NameAr,
                                }).ToList();

            }
             
            return Json(PaymentTypes);

        }


        //**************************************** PurposeVisit ****************************************

        //Show PurposeVisit
        public IActionResult PurposeVisit()
        {
            List<PurposeVisit> PurposeVisits = _context.PurposeVisits.Where(a => a.DeletedBy == null).ToList();
            ViewData["PurposeVisits"] = PurposeVisits;
            return View(new PurposeVisit());
        }

        //Update PurposeVisit
        public IActionResult UpdatePurposeVisit(PurposeVisit NewPurposeVisit)
        {
            // current user
            var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (NewPurposeVisit.Id == 0)
            {
                NewPurposeVisit.InsertedBy = userid;
                NewPurposeVisit.InsertedDate = DateTime.Now;
                _context.PurposeVisits.Add(NewPurposeVisit);
                _context.SaveChanges();
            }
            else
            {
                var OldPurposeVisit = _context.PurposeVisits.Find(NewPurposeVisit.Id);
                if (OldPurposeVisit != null)
                {
                    OldPurposeVisit.NameAr = NewPurposeVisit.NameAr;
                    OldPurposeVisit.NameEn = NewPurposeVisit.NameEn;
                   
                    OldPurposeVisit.UpdatedBy = userid;
                    OldPurposeVisit.UpdatedDate = DateTime.Now;
                    _context.Entry(OldPurposeVisit).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    _context.SaveChanges();
                }
            }
            return RedirectToAction("PurposeVisit");
        }
        //Get PurposeVisit
        public JsonResult GetPurposeVisit(int? id)
        {
            var PurposeVisits = _context.PurposeVisits.Find(id);
            return Json(PurposeVisits);
        }

        //Delete PurposeVisit
        public IActionResult DeletePurposeVisit(PurposeVisit NewPurposeVisit)
        {
            // current user
            var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var OldPurposeVisit = _context.PurposeVisits.Find(NewPurposeVisit.Id);
            if (OldPurposeVisit != null)
            {
                OldPurposeVisit.DeletedBy = userid;
                OldPurposeVisit.DeletedDate = DateTime.Now;

                _context.Entry(OldPurposeVisit).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
            }

            return RedirectToAction("PurposeVisit");

        }

        //GetAll PurposeVisit
        public IActionResult GetAllPurposeVisit()
        {
            //var PurposeVisits = _context.PurposeVisits;

            var PurposeVisits = (from t in _context.PurposeVisits

                                 where  t.DeletedBy == null
                             select new
                             {
                                 t.Id,
                                 name = t.NameEn,
                             }).ToList();


            if (CultureInfo.CurrentCulture.Name.StartsWith("ar"))
            {
                PurposeVisits = (from t in _context.PurposeVisits

                                 where t.DeletedBy == null
                                 select new
                                 {
                                     t.Id,
                                     name = t.NameAr,
                                 }).ToList();

            }


            return Json(PurposeVisits);

        }

        //**************************************** Room ****************************************

        //Show Room
        public IActionResult Room()
        {
           
            List<Room> Rooms = _context.Rooms.ToList();
            ViewData["Rooms"] = Rooms;
            return View(new Room());
        }

        //Update Room
        public IActionResult UpdateRoom(Room NewRoom)
        {
            // current user
            var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (NewRoom.Id == 0)
            {
                NewRoom.InsertedBy = userid;
                NewRoom.InsertedDate = DateTime.Now;
                _context.Rooms.Add(NewRoom);
                _context.SaveChanges();
            }
            else
            {
                var OldRoom = _context.Rooms.Find(NewRoom.Id);
                if (OldRoom != null)
                {
                    OldRoom.RoomNo = NewRoom.RoomNo;
                    OldRoom.FloorNo = NewRoom.FloorNo;
                    OldRoom.NormalPrice = NewRoom.NormalPrice;
                    OldRoom.MinPrice = NewRoom.MinPrice;

                    OldRoom.SingleBedNo = NewRoom.SingleBedNo;
                    OldRoom.DoubleBedNo = NewRoom.DoubleBedNo;
                    OldRoom.WcNo = NewRoom.WcNo;

                    OldRoom.HotelId = NewRoom.HotelId;
                    OldRoom.RoomTypeId = NewRoom.RoomTypeId;
                    OldRoom.RoomStatusId = NewRoom.RoomStatusId;

                    OldRoom.UpdatedBy = userid;
                    OldRoom.UpdatedDate = DateTime.Now;

                    _context.Entry(OldRoom).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    _context.SaveChanges();
                }
            }
            return RedirectToAction("Room");
        }

        //Get Room
        public JsonResult GetRoom(int? id)
        {
            var Rooms = _context.Rooms.Find(id);
            return Json(Rooms);
        }

        //Delete Room 
        public IActionResult DeleteRoom(Room NewRoom)
        {
            // current user
            var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var OldRoom = _context.Rooms.Find(NewRoom.Id);
            if (OldRoom != null)
            {
                OldRoom.DeletedBy = userid;
                OldRoom.DeletedDate = DateTime.Now;

                _context.Entry(OldRoom).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
            }

            return RedirectToAction("Room");

        }

        //GetAllRoom Nomber
        public IActionResult GetAllRoomNo()
        {
            int id = 0;
            if (TempData.ContainsKey("TempHotelId"))
            {
                id = (int)TempData.Peek("TempHotelId");
            }
            var Rooms = _context.Rooms.Where(a => a.DeletedBy == null).Where(r => r.HotelId == id);
            return Json(Rooms);

        }
          
        //GetAllRoomInHotel
        public IActionResult GetAllRoomInHotel()
        {
            int id = 0;
            if (TempData.ContainsKey("TempHotelId"))
            {
                id = (int)TempData.Peek("TempHotelId");
            }
            var lan = CultureInfo.CurrentCulture.Name.StartsWith("ar");
            var Rooms = (from r in _context.Rooms  
                         join contr  in _context.Contractss 
                          on new { X1 = r.Id, X2 = 1 } equals new { X1 = contr.RoomId, X2 = contr.Status } into roomgroup
                         
                         from contr in roomgroup.DefaultIfEmpty()
                         where r.HotelId == id && r.DeletedBy == null
                         orderby r.RoomNo ascending
                          
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
                             status =lan ? r.RoomStatus.NameAr : r.RoomStatus.NameEn,
                             typename = lan ? r.RoomType.NameAr : r.RoomType.NameEn,
                             contractnumber = contr == null ? 0 :contr.Id,
                             totalPrice = contr == null ? 0 : contr.TotalPrice,
                             contractCheckInTime = contr == null ? "" : contr.CheckInTime.Date.ToString(),
                             contractCheckOut = contr == null ? "" : contr.CheckOut.Date.ToString(),
                             contractDuration = contr == null ? 0 : contr.Duration
                         }).ToList();


             
           
            //var Rooms = _context.Rooms.Where(c => c.HotelId == id).Where(a => a.DeletedBy == null);
            return Json(Rooms);

        }



        //**************************************** room scheme ****************************************
        public IActionResult Roomscheme()
        {
            
            List<Room> Rooms = _context.Rooms.ToList();
            ViewData["Roomschemes"] = Rooms;
            return View(new Room());
        }
        public IActionResult UpdateRoomscheme(Room NewRoom)
        {
            // current user
            var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (NewRoom.Id == 0)
            {
                NewRoom.InsertedBy = userid;
                NewRoom.InsertedDate = DateTime.Now;
                _context.Rooms.Add(NewRoom);
                _context.SaveChanges();
            }
            else
            {
                var OldRoom = _context.Rooms.Find(NewRoom.Id);
                if (OldRoom != null)
                { 
                    OldRoom.RoomStatusId = NewRoom.RoomStatusId;

                    OldRoom.UpdatedBy = userid;
                    OldRoom.UpdatedDate = DateTime.Now;

                    _context.Entry(OldRoom).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    _context.SaveChanges();
                }
            }
            return RedirectToAction("Roomscheme");
        }
        public IActionResult Roomschemea()
        {
            List<Room> Rooms = _context.Rooms.ToList();
            ViewData["Roomschemes"] = Rooms;
            return View(new Room());
        }


        //**************************************** RoomAsset ****************************************
        //Show RoomAsset
        public IActionResult RoomAsset()
        {
            List<RoomAsset> RoomAssets = _context.RoomAssets.ToList();
            ViewData["RoomAssets"] = RoomAssets;
            return View(new RoomAsset());
        }

        //Update RoomAsset
        public IActionResult UpdateRoomAsset(RoomAsset NewRoomAsset)
        {
            // current user
            var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (NewRoomAsset.Id == 0)
            {
                NewRoomAsset.InsertedBy = userid;
                NewRoomAsset.InsertedDate = DateTime.Now;
                _context.RoomAssets.Add(NewRoomAsset);
                _context.SaveChanges();
            }
            else
            {
                var OldRoomAsset = _context.RoomAssets.Find(NewRoomAsset.Id);
                if (OldRoomAsset != null)
                {
                    OldRoomAsset.Qty = NewRoomAsset.Qty;
                    OldRoomAsset.RoomId = NewRoomAsset.RoomId;
                    OldRoomAsset.AssetId = NewRoomAsset.AssetId;
                    OldRoomAsset.AssetTypeId = NewRoomAsset.AssetTypeId;
                    OldRoomAsset.UpdatedBy = userid;
                    OldRoomAsset.UpdatedDate = DateTime.Now;

                    _context.Entry(OldRoomAsset).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    _context.SaveChanges();
                }
            }
            return RedirectToAction("RoomAsset");
        }

        //Get RoomAsset
        public JsonResult GetRoomAsset(int? id)
        {
            var RoomAssets = _context.RoomAssets.Find(id);
            return Json(RoomAssets);
        }

        //Delete RoomAsset
        public IActionResult DeleteRoomAsset(RoomAsset NewRoomAsset)
        {
            // current user
            var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var OldRoomAsset = _context.RoomAssets.Find(NewRoomAsset.Id);
            if (OldRoomAsset != null)
            {
                OldRoomAsset.DeletedBy = userid;
                OldRoomAsset.DeletedDate = DateTime.Now;

                _context.Entry(OldRoomAsset).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
            }

            return RedirectToAction("RoomAsset");

        }




        //**************************************** RoomStatus ****************************************

        //Show RoomStatus
        public IActionResult RoomStatus()
        {
            List<RoomStatus> RoomStatuss = _context.RoomStatus.Where(a => a.DeletedBy == null).ToList();
            ViewData["RoomStatuss"] = RoomStatuss;
            return View(new RoomStatus());
        }

        //Update RoomStatus
        public IActionResult UpdateRoomStatus(RoomStatus NewRoomStatus)
        {
            // current user
            var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (NewRoomStatus.Id == 0)
            {
                NewRoomStatus.InsertedBy = userid;
                NewRoomStatus.InsertedDate = DateTime.Now;
               
                _context.RoomStatus.Add(NewRoomStatus);
                _context.SaveChanges();
            }
            else
            {
                var OldRoomStatus = _context.RoomStatus.Find(NewRoomStatus.Id);
                if (OldRoomStatus != null)
                {
                    OldRoomStatus.NameAr = NewRoomStatus.NameAr;
                    OldRoomStatus.NameEn = NewRoomStatus.NameEn;
                    OldRoomStatus.UpdatedBy = userid;
                    OldRoomStatus.UpdatedDate = DateTime.Now;
                    _context.Entry(OldRoomStatus).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    _context.SaveChanges();
                }
            }
            return RedirectToAction("RoomStatus");
        }

        //Get RoomStatus
        public JsonResult GetRoomStatus(int? id)
        {
            var RoomStatuss = _context.RoomStatus.Find(id);
            return Json(RoomStatuss);
        }

        //Delete RoomStatus
        public IActionResult DeleteRoomStatus(RoomStatus NewRoomStatus)
        {
            // current user
            var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var OldRoomStatus = _context.RoomStatus.Find(NewRoomStatus.Id);
            if (OldRoomStatus != null)
            {
                OldRoomStatus.DeletedBy = userid;
                OldRoomStatus.DeletedDate = DateTime.Now;

                _context.Entry(OldRoomStatus).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
            }

            return RedirectToAction("RoomStatus");

        }

        //GetAllRoomStatus
        public IActionResult GetAllRoomStatus()
        {

            var RoomStatus = (from r in _context.RoomStatus

                              where r.DeletedBy == null
                              select new
                              {
                                  r.Id,
                                  name = r.NameEn,
                              }).ToList();


            if (CultureInfo.CurrentCulture.Name.StartsWith("ar"))
            {
                RoomStatus = (from r in _context.RoomStatus

                              where r.DeletedBy == null
                              select new
                              {
                                  r.Id,
                                  name = r.NameAr,
                              }).ToList();

            }

            return Json(RoomStatus);

        }



        //**************************************** RoomType ****************************************

        //Show RoomType
        public IActionResult RoomType()
        {
            List<RoomType> RoomTypes = _context.RoomType.Where(a => a.DeletedBy == null).ToList();
            ViewData["RoomTypes"] = RoomTypes;
            return View(new RoomType());
        }

        //Update RoomType
        public IActionResult UpdateRoomType(RoomType NewRoomType)
        {
            // current user
            var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (NewRoomType.Id == 0)
            {
                NewRoomType.InsertedBy = userid;
                NewRoomType.InsertedDate = DateTime.Now;
                _context.RoomType.Add(NewRoomType);
                _context.SaveChanges();
            }
            else
            {
                var OldRoomType = _context.RoomType.Find(NewRoomType.Id);
                if (OldRoomType != null)
                {
                    OldRoomType.NameAr = NewRoomType.NameAr;
                    OldRoomType.NameEn = NewRoomType.NameEn;
                    OldRoomType.UpdatedBy = userid;
                    OldRoomType.UpdatedDate = DateTime.Now;
                    _context.Entry(OldRoomType).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    _context.SaveChanges();
                }
            }
            return RedirectToAction("RoomType");
        }

        //Get RoomType
        public JsonResult GetRoomType(int? id)
        {
            var RoomTypes = _context.RoomType.Find(id);
            return Json(RoomTypes);
        }

        //Delete RoomType
        public IActionResult DeleteRoomType(RoomType NewRoomType)
        {
            // current user
            var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var OldRoomType = _context.RoomType.Find(NewRoomType.Id);
            if (OldRoomType != null)
            {
                OldRoomType.DeletedBy = userid;
                OldRoomType.DeletedDate = DateTime.Now;

                _context.Entry(OldRoomType).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
            }

            return RedirectToAction("RoomType");

        }

        //GetAllRoomType
        public IActionResult GetAllRoomType()
        {

            var RoomTypes = (from r in _context.RoomType

                             where r.DeletedBy == null
                             select new
                             {
                                 r.Id,
                                 name = r.NameEn,
                             }).ToList();


            if (CultureInfo.CurrentCulture.Name.StartsWith("ar"))
            {
                RoomTypes = (from r in _context.RoomType

                             where r.DeletedBy == null
                             select new
                             {
                                 r.Id,
                                 name = r.NameAr,
                             }).ToList();

            }

            return Json(RoomTypes);

        }

        //**************************************** Store ****************************************

        //Show Store
        public IActionResult Store()
        {
            List<Store> Stores = _context.Stores.ToList();
            ViewData["Stores"] = Stores;
            return View(new Store());
        }

        //Update Store
        public IActionResult UpdateStore(Store NewStore)
        {
            // current user
            var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (NewStore.Id == 0)
            {
                NewStore.InsertedBy = userid;
                NewStore.InsertedDate = DateTime.Now;
                _context.Stores.Add(NewStore);
                _context.SaveChanges();
            }
            else
            {
                var OldStore = _context.Stores.Find(NewStore.Id);
                if (OldStore != null)
                {
                    OldStore.NameAr = NewStore.NameAr;
                    OldStore.NameEn = NewStore.NameEn;
                    OldStore.HotelId = NewStore.HotelId;
                    OldStore.UpdatedBy = userid;
                    OldStore.UpdatedDate = DateTime.Now;
                    _context.Entry(OldStore).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    _context.SaveChanges();
                }
            }
            return RedirectToAction("Store");
        }
        //Get Store
        public JsonResult GetStore(int? id)
        {
            var Stores = _context.Stores.Find(id);
            return Json(Stores);
        }

        //Delete Store
        public IActionResult DeleteStore(Store NewStore)
        {
            // current user
            var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var OldStore = _context.Stores.Find(NewStore.Id);
            if (OldStore != null)
            {
                OldStore.DeletedBy = userid;
                OldStore.DeletedDate = DateTime.Now;

                _context.Entry(OldStore).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
            }

            return RedirectToAction("Store");

        }

        

        //GetAllStoreInHotel 
        public IActionResult GetAllStoreInHotel()
        {
            //var Stores = _context.Stores.Where(c => c.HotelId == id).Where(a => a.DeletedBy == null);
            //return Json(Stores);

            int id = 0;
            if (TempData.ContainsKey("TempHotelId"))
            {
                id = (int)TempData.Peek("TempHotelId");
            }



            var Stores = (from s in _context.Stores

                          where s.HotelId == id && s.DeletedBy == null
                          select new
                          {
                              s.Id,
                              storename = s.NameEn
                          }).ToList();


            if (CultureInfo.CurrentCulture.Name.StartsWith("ar"))
            {
                Stores = (from s in _context.Stores

                          where s.HotelId == id && s.DeletedBy == null
                          select new
                          {
                              s.Id,
                              storename = s.NameAr
                          }).ToList();

            }
            return Json(Stores);
        }


        //GetAllStore
        public IActionResult GetAllStore()
        {
            var Stores = _context.Stores.Where(a => a.DeletedBy == null);
            return Json(Stores);

        }

        

        //**************************************** StoreAsset ****************************************

        //Show StoreAsset
        public IActionResult StoreAsset()
        {
            List<StoreAsset> StoreAssets = _context.StoreAssets.ToList();
            ViewData["StoreAssets"] = StoreAssets;
            return View(new StoreAsset());
        }

        //Update StoreAsset
        public IActionResult UpdateStoreAsset(StoreAsset NewStoreAsset)
        {
            // current user
            var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (NewStoreAsset.Id == 0)
            {
                NewStoreAsset.InsertedBy = userid;
                NewStoreAsset.InsertedDate = DateTime.Now;
                _context.StoreAssets.Add(NewStoreAsset);
                _context.SaveChanges();
            }
            else
            {
                var OldStoreAsset = _context.StoreAssets.Find(NewStoreAsset.Id);
                if (OldStoreAsset != null)
                {
                    OldStoreAsset.IntailQty = NewStoreAsset.IntailQty;
                    OldStoreAsset.CurrentQty = NewStoreAsset.CurrentQty;
                    OldStoreAsset.StoreId = NewStoreAsset.StoreId;
                    OldStoreAsset.AssetId = NewStoreAsset.AssetId;
                    OldStoreAsset.AssetStatusTypeId = NewStoreAsset.AssetStatusTypeId;

                    OldStoreAsset.UpdatedBy = userid;
                    OldStoreAsset.UpdatedDate = DateTime.Now;

                    _context.Entry(OldStoreAsset).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    _context.SaveChanges();
                }
            }
            return RedirectToAction("StoreAsset");
        }
        //Get StoreAsset
        public JsonResult GetStoreAsset(int? id)
        {
            var StoreAssets = _context.StoreAssets.Find(id);
            return Json(StoreAssets);
        }

        //Delete StoreAsset
        public IActionResult DeleteStoreAsset(StoreAsset NewStoreAsset)
        {
            // current user
            var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var OldStoreAsset = _context.StoreAssets.Find(NewStoreAsset.Id);
            if (OldStoreAsset != null)
            {
                OldStoreAsset.DeletedBy = userid;
                OldStoreAsset.DeletedDate = DateTime.Now;

                _context.Entry(OldStoreAsset).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
            }

            return RedirectToAction("StoreAsset");

        }




        //**************************************** StoreResponsable ****************************************

        //Show StoreResponsable
        public IActionResult StoreResponsable()
        {
            List<StoreResponsable> StoreResponsables = _context.StoreResponsables.ToList();
            ViewData["StoreResponsables"] = StoreResponsables;
            return View(new StoreResponsable());
        }

        //Update StoreResponsable
        public IActionResult UpdateStoreResponsable(StoreResponsable NewStoreResponsable)
        {
            // current user
            var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (NewStoreResponsable.Id == 0)
            {
                NewStoreResponsable.InsertedBy = userid;
                NewStoreResponsable.InsertedDate = DateTime.Now;
                _context.StoreResponsables.Add(NewStoreResponsable);
                _context.SaveChanges();
            }
            else
            {
                var OldStoreResponsable = _context.StoreResponsables.Find(NewStoreResponsable.Id);
                if (OldStoreResponsable != null)
                {
                    OldStoreResponsable.StartDate = NewStoreResponsable.StartDate;
                    OldStoreResponsable.EndDate = NewStoreResponsable.EndDate;
                    OldStoreResponsable.StoreId = NewStoreResponsable.StoreId;
                    OldStoreResponsable.EmployeeId = NewStoreResponsable.EmployeeId;

                    OldStoreResponsable.UpdatedBy = userid;
                    OldStoreResponsable.UpdatedDate = DateTime.Now;
                    _context.Entry(OldStoreResponsable).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    _context.SaveChanges();
                }
            }
            return RedirectToAction("StoreResponsable");
        }

        //Get StoreResponsable
        public JsonResult GetStoreResponsable(int? id)
        {
            var StoreResponsables = _context.StoreResponsables.Find(id);
            return Json(StoreResponsables);
        }

        //Delete StoreResponsable
        public IActionResult DeleteStoreResponsable(StoreResponsable NewStoreResponsable)
        {
            // current user
            var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var OldStoreResponsable = _context.StoreResponsables.Find(NewStoreResponsable.Id);
            if (OldStoreResponsable != null)
            {
                OldStoreResponsable.DeletedBy = userid;
                OldStoreResponsable.DeletedDate = DateTime.Now;

                _context.Entry(OldStoreResponsable).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
            }

            return RedirectToAction("StoreResponsable");

        }

        // get All StoreResponsable for selected employee
        public IActionResult GetAllStoreResponsable(int id)
        {
            //var StoreResponsables = _context.StoreResponsables.Where(c => c.EmployeeId == id).Where(a => a.DeletedBy == null);
            var StoreResponsables = (from a in _context.StoreResponsables
                                     join b in _context.Stores on a.StoreId equals b.Id
                                     join e in _context.Employees on a.EmployeeId equals e.Id
                                     where a.EmployeeId == id && a.DeletedBy == null
                                     select new
                                     {
                                         a.Id,
                                         a.EmployeeId,
                                         a.StoreId,
                                         a.StartDate,
                                         a.EndDate,
                                         employeename = e.NameEn,
                                         storename = b.NameEn


                                     }).ToList();
            if (CultureInfo.CurrentCulture.Name.StartsWith("ar"))
            {
                StoreResponsables = (from a in _context.StoreResponsables
                                     join b in _context.Stores on a.StoreId equals b.Id
                                     join e in _context.Employees on a.EmployeeId equals e.Id
                                     where a.EmployeeId == id && a.DeletedBy == null
                                     select new
                                     {
                                         a.Id,
                                         a.EmployeeId,
                                         a.StoreId,
                                         a.StartDate,
                                         a.EndDate,
                                         employeename = e.NameAr,
                                         storename = b.NameAr
                                     }).ToList();

            }
            return Json(StoreResponsables);

        }


        //**************************************** TaxType ****************************************

        //Show TaxType
        public IActionResult TaxType()
        {
            List<TaxType> TaxTypes = _context.TaxTypes.ToList();
            ViewData["TaxTypes"] = TaxTypes;
            return View(new TaxType());
        }

        //Update TaxType
        public IActionResult UpdateTaxType(TaxType NewTaxType)
        {
            // current user
            var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (NewTaxType.Id == 0)
            {
                NewTaxType.InsertedBy = userid;
                NewTaxType.InsertedDate = DateTime.Now;
                _context.TaxTypes.Add(NewTaxType);
                _context.SaveChanges();
            }
            else
            {
                var OldTaxType = _context.TaxTypes.Find(NewTaxType.Id);
                if (OldTaxType != null)
                {
                    OldTaxType.NameAr = NewTaxType.NameAr;
                    OldTaxType.NameEn = NewTaxType.NameEn;
                    OldTaxType.IsFixed = NewTaxType.IsFixed;
                    OldTaxType.ContractOnly = NewTaxType.ContractOnly;
                    OldTaxType.Value = NewTaxType.Value;
                    OldTaxType.HotelId = NewTaxType.HotelId;
                    OldTaxType.UpdatedBy = userid;
                    OldTaxType.UpdatedDate = DateTime.Now;
                    NewTaxType.InsertedDate = DateTime.Now;


                    _context.Entry(OldTaxType).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    _context.SaveChanges();
                }
            }
            return RedirectToAction("TaxType");
        }

        //Get TaxType
        public JsonResult GetTaxType(int? id)
        {
            var TaxTypes = _context.TaxTypes.Find(id);
            return Json(TaxTypes);
        }

        //Delete TaxType
        public IActionResult DeleteTaxType(TaxType NewTaxType)
        {
            // current user
            var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var OldTaxType = _context.TaxTypes.Find(NewTaxType.Id);
            if (OldTaxType != null)
            {
                OldTaxType.DeletedBy = userid;
                OldTaxType.DeletedDate = DateTime.Now;

                _context.Entry(OldTaxType).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
            }

            return RedirectToAction("TaxType");

        }

        // get All TaxType for contract
        public IActionResult GetAllTaxTypeForContract()
        {
            int id = 0;
            if (TempData.ContainsKey("TempHotelId"))
            {
                id = (int)TempData.Peek("TempHotelId");
            }
            var TaxTypes = _context.TaxTypes.Where(c => c.HotelId == id).Where(fc => fc.ContractOnly == true).Where(a => a.DeletedBy == null);
            return Json(TaxTypes);
        }

        // get All TaxType for invoice
        public IActionResult GetAllTaxTypeForinvoice()
        {
            int id = 0;
            if (TempData.ContainsKey("TempHotelId"))
            {
                id = (int)TempData.Peek("TempHotelId");
            }
            var TaxTypes = _context.TaxTypes.Where(c => c.HotelId == id).Where(fc => fc.IsFixed == false).Where(a => a.DeletedBy == null);
            return Json(TaxTypes);
        }

        //GetAllTaxTypeInHotel
        public IActionResult GetAllTaxTypeInHotel()
        {
            int id = 0;
            if (TempData.ContainsKey("TempHotelId"))
            {
                id = (int)TempData.Peek("TempHotelId");
            }
 
            var TaxTypes = (from t in _context.TaxTypes

                            where t.HotelId == id && t.DeletedBy == null
                             select new
                             {
                                 t.Id,
                                 name = t.NameEn,
                                 t.Value,
                                 t.IsFixed,
                                 t.ContractOnly
                             }).ToList();


            if (CultureInfo.CurrentCulture.Name.StartsWith("ar"))
            {
                TaxTypes = (from t in _context.TaxTypes

                            where t.HotelId == id && t.DeletedBy == null
                            select new
                            {
                                t.Id,
                                name = t.NameAr,
                                t.Value,
                                t.IsFixed,
                                t.ContractOnly
                            }).ToList();
            }



            return Json(TaxTypes); 
        }



        //**************************************** UnitType ****************************************

        //Show UnitType
        public IActionResult UnitType()
        {
            List<UnitType> UnitTypes = _context.UnitType.Where(a => a.DeletedBy == null).ToList();
            ViewData["UnitTypes"] = UnitTypes;
            return View(new UnitType());
        }

        //Update UnitType
        public IActionResult UpdateUnitType(UnitType NewUnitType)
        {
            // current user
            var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (NewUnitType.Id == 0)
            {
                
                NewUnitType.InsertedBy = userid;
                NewUnitType.InsertedDate = DateTime.Now;
                _context.UnitType.Add(NewUnitType);
                _context.SaveChanges();
            }
            else
            {
                var OldUnitType = _context.UnitType.Find(NewUnitType.Id);
                if (OldUnitType != null)
                {
                    OldUnitType.NameAr = NewUnitType.NameAr;
                    OldUnitType.NameEn = NewUnitType.NameEn;
                    OldUnitType.UpdatedBy = userid;
                    OldUnitType.UpdatedDate = DateTime.Now;
                    _context.Entry(OldUnitType).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    _context.SaveChanges();
                }
            }
            return RedirectToAction("UnitType");
        }
        //Get UnitType
        public JsonResult GetUnitType(int? id)
        {
            var UnitTypes = _context.UnitType.Find(id);
            return Json(UnitTypes);
        }

        // Delete UnitType
        public IActionResult DeleteUnitType(UnitType NewUnitType)
        {
            // current user
            var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var OldUnitType = _context.UnitType.Find(NewUnitType.Id);
            if (OldUnitType != null)
            {
                OldUnitType.DeletedBy = userid;
                OldUnitType.DeletedDate = DateTime.Now;

                _context.Entry(OldUnitType).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
            }

            return RedirectToAction("UnitType");

        }

        //GetAllUnitType
        public IActionResult GetAllUnitType()
        {
            //var UnitTypes = _context.UnitType;

            var UnitTypes = (from t in _context.UnitType

                             where   t.DeletedBy == null
                             select new
                             {
                                 t.Id,
                                 name = t.NameEn,
                             }).ToList();


            if (CultureInfo.CurrentCulture.Name.StartsWith("ar"))
            {
                UnitTypes = (from t in _context.UnitType

                             where t.DeletedBy == null
                             select new
                             {
                                 t.Id,
                                 name = t.NameAr,
                             }).ToList();
            }



            return Json(UnitTypes);

        }


        //**************************************** Vendor ****************************************

        //Show Vendor
        public IActionResult Vendor()
        {
            List<Vendor> Vendors = _context.Vendors.ToList();
            ViewData["Vendors"] = Vendors;
            return View(new Vendor());
        }

        //Update Vendor
        public IActionResult UpdateVendor(Vendor NewVendor)
        {
            // current user
            var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (NewVendor.Id == 0)
            {
                NewVendor.InsertedBy = userid;
                NewVendor.InsertedDate = DateTime.Now;
                _context.Vendors.Add(NewVendor);
                _context.SaveChanges();
            }
            else
            {
                var OldVendor = _context.Vendors.Find(NewVendor.Id);
                if (OldVendor != null)
                {
                    OldVendor.NameAr = NewVendor.NameAr;
                    OldVendor.NameEn = NewVendor.NameEn;

                    OldVendor.VatNo = NewVendor.VatNo;
                    OldVendor.AddressAr = NewVendor.AddressAr;

                    OldVendor.AddressEn = NewVendor.AddressEn;
                    OldVendor.ResponsableName = NewVendor.ResponsableName;
                    OldVendor.CityId = NewVendor.CityId;
                    OldVendor.UpdatedBy = userid;
                    OldVendor.UpdatedDate = DateTime.Now;
                    _context.Entry(OldVendor).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    _context.SaveChanges();
                }
            }
            return RedirectToAction("Vendor");
        }

        //Get Vendor
        public JsonResult GetVendor(int? id)
        {
            var Vendors = _context.Vendors.Find(id);
            return Json(Vendors);
        }
        public JsonResult GetVendorByName(string name )
        {
            var lan = CultureInfo.CurrentCulture.Name.StartsWith("ar");

            var Vendors = (from v in _context.Vendors

                           where (v.NameAr == name || v.NameEn == name) && v.DeletedBy == null
                            select new
                            {
                                v.Id,
                                name = lan ? v.NameAr : v.NameEn,
                                //fullAddress = lan ? v.FullAddressAr : v.FullAddressEn,
                                vatNo = v.VatNo,
                                
                            }).ToList();

             
            return Json(Vendors);
        }

        // Delete Vendor
        public IActionResult DeleteVendor(Vendor NewVendor)
        {
            // current user
            var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var OldVendor = _context.Vendors.Find(NewVendor.Id);
            if (OldVendor != null)
            {
                OldVendor.DeletedBy = userid;
                OldVendor.DeletedDate = DateTime.Now;

                _context.Entry(OldVendor).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
            }

            return RedirectToAction("Vendor");

        }

        // GetAllVendorcontact
        public IActionResult GetAllVendorcontact(string id)// namear
        {
            var abc = (from v in _context.Vendors
                       join ci in _context.Country on v.CityId equals ci.Id
                       join cou in _context.Country on ci.ParentId equals cou.Id
                       join vendorcontact in _context.VendorContacts on v.Id equals vendorcontact.VendorId
                       join contactType in _context.ContactType on vendorcontact.ContactTypeId equals contactType.Id

                       where v.NameAr == id && v.DeletedBy == null
                       select new
                       {
                           vendorcontact.Id,
                           v.NameAr,
                           v.NameEn,
                           v.HotelId,
                           v.CityId,

                           contactvalue = vendorcontact.Value,
                           contactdescription = vendorcontact.Description,
                           contacttypenam = contactType.NameAr,
                           countryName = cou.NameEn
                       }).ToList();

            return Json(abc);


        }

        public IActionResult GetAllVendorrcontact(int id)
        {
            var abc = (from v in _context.Vendors

                       join vendorcontact in _context.VendorContacts on v.Id equals vendorcontact.VendorId
                       join contactType in _context.ContactType on vendorcontact.ContactTypeId equals contactType.Id

                       where v.Id == id && v.DeletedBy == null
                       select new
                       {
                           v.Id,
                           customercontactid = vendorcontact.Id,

                           contactvalue = vendorcontact.Value,
                           contactdescription = vendorcontact.Description,
                           contacttypenam = contactType.NameAr,

                       }).ToList();

            return Json(abc);


        }

        //GetAllvendor
        public IActionResult GetAllvendor()
        {
            var Vendors = _context.Vendors;
            return Json(Vendors);

        }


        //GetAlVendorInHotel
        public IActionResult GetAllVendorInHotel()
        {
            //    var Employees = _context.Employees.Where(c => c.HotelId == id).Where(a => a.DeletedBy == null);
            //    return Json(Employees);

            int id = 0;
            if (TempData.ContainsKey("TempHotelId"))
            {
                id = (int)TempData.Peek("TempHotelId");
            }



            var Vendors = (from v in _context.Vendors

                           where v.HotelId == id && v.DeletedBy == null
                           select new
                           {
                               v.Id,
                               vendorname = v.NameEn,
                               v.NameEn,
                               v.VatNo,
                               vendorAddress = v.AddressEn,

                               v.ResponsableName,
                               v.HotelId,
                               v.CityId,

                               countryName = v.Country.NameEn
                           }).ToList();


            if (CultureInfo.CurrentCulture.Name.StartsWith("ar"))
            {
                Vendors = (from v in _context.Vendors

                           where v.HotelId == id && v.DeletedBy == null
                           select new
                           {
                               v.Id,
                               vendorname = v.NameAr,
                               v.NameEn,
                               v.VatNo,
                               vendorAddress = v.AddressAr,

                               v.ResponsableName,
                               v.HotelId,
                               v.CityId,

                               countryName = v.Country.NameAr
                           }).ToList();

            } 

            return Json(Vendors);

        }
         
        //**************************************** Vendor Contact ****************************************

        //Show VendorContact
        public IActionResult VendorContact()
        {
            List<VendorContact> VendorContacts = _context.VendorContacts.ToList();
            ViewData["VendorContacts"] = VendorContacts;
            return View(new VendorContact());
        }

        //Update VendorContact
        public IActionResult UpdateVendorContact(VendorContact NewVendorContact)
        {
            // current user
            var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (NewVendorContact.Id == 0)
            {
                NewVendorContact.InsertedBy = userid;
                NewVendorContact.InsertedDate = DateTime.Now;
                _context.VendorContacts.Add(NewVendorContact);
                _context.SaveChanges();
            }
            else
            {
                var OldVendorContact = _context.VendorContacts.Find(NewVendorContact.Id);
                if (OldVendorContact != null)
                {
                    OldVendorContact.Value = NewVendorContact.Value;
                    OldVendorContact.Description = NewVendorContact.Description;

                    OldVendorContact.VendorId = NewVendorContact.VendorId;
                    OldVendorContact.ContactTypeId = NewVendorContact.ContactTypeId;
                    OldVendorContact.UpdatedBy = userid;
                    OldVendorContact.UpdatedDate = DateTime.Now;
                    _context.Entry(OldVendorContact).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    _context.SaveChanges();
                }
            }
            return RedirectToAction("VendorContact");
        }
        //Get VendorContact
        public JsonResult GetVendorContact(int? id)
        {
            var VendorContacts = _context.VendorContacts.Find(id);
            return Json(VendorContacts);
        }


        // Delete VendorContact
        public IActionResult DeleteVendorContact(VendorContact NewVendorContact)
        {
            // current user
            var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var OldVendorContact = _context.VendorContacts.Find(NewVendorContact.Id);
            if (OldVendorContact != null)
            {
                OldVendorContact.DeletedBy = userid;
                OldVendorContact.DeletedDate = DateTime.Now;

                _context.Entry(OldVendorContact).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
            }

            return RedirectToAction("VendorContact");

        }
         

       

        //GetAllContract
        public IActionResult GetAllContract()
        {
            var Contracts = _context.Contractss.Where(a => a.DeletedBy == null);
            return Json(Contracts);

        }
         
        //GetAllCustomer
        public IActionResult GetAllCustomer()
        {
            var Customers = _context.Customers.Where(a => a.DeletedBy == null);
            return Json(Customers);

        }
     
      
         
        //GetAllService
        public IActionResult GetAllService()
        {
            var Services = _context.Services;
            return Json(Services);

        }
         
        // Get All Product InStore
        //public IActionResult GetAllProductInStore(int id)
        //{
        //    var abc = (from sa in _context.StoreAssets
        //               join ass in _context.Assets on sa.AssetId equals ass.Id
        //               where a.EmployeeId == id
        //               //&& e.DeletedBy == null
        //               select new { a.Id, a.EmployeeId, 
        //                   a.StoreId, a.StartDate, 
        //                   a.EndDate, b.NameAr, b.NameEn }).ToList();

        //    return Json(abc);

        //}






    }
}
