// Please see documentation at https://docs.microsoft.com/net / core / client - side / bundling - and - minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

 

$(document).ready(function () {
    GetAllRoles();
    Getculture();
    GetAllHotel();
    GetSessionHotel();
    GetCompany();
    GetRooms();
    GetAllRoomNo();
    GetRoomSchema();
    GetAllRoomType();
    GetAllRoomStatus();
    SelectAllRoomInHotel();
    GetAllCurrency();
    getAssets();
    GetAllAsset();
    GetCitiesOnly();
    GetAllAssetType();
    GetAllAssetStatus();
    GetAllUnitType();
    GetAllTaxTypeForinvoice();
    GetVendor();
    GetAllContactType();

    GetEmployee();
    GetAllIdType();
    GetAllCountry();


    GetAllStoreInHotel();
    GetAllCustomerInHotel();
    SelectAllStoreInHotel();
    SelectAllEmployeeInHotel();

    GetAllPaymentTypes();
    GetAllPurposeVisit();

    SetMinDate();
    GetAllContractsInHotel();
    GetAllTaxTypeInHotel();
    GetAllTaxForContract();

    SearchIdType();
    ContractsReport();
    HospitalityContractsReport();
    CustomerReports();
    EmployeeReports();
    AssetReports();
    RoomPriceWithoutBreakfastReport();
    RoomPriceWithBreakfastReport();
    RoomReport();
    TotalroomincomeReport();
    RecepitVouchersReport();
    Employeehandoverdata();
    ServicesReport();
    PurchaseItemsReport();
    PurchaseReport();
});

var loginhotelid = 0;
var culture = "";

function myFunction() {
    document.getElementById("htmltag").setAttribute("lang", "ar");
    document.getElementById("htmltag").setAttribute("dir", "rtl");
    alert("heel");
}

function Getculture() {
     
    culture = $("#culture").val();
    if (culture == "ar-SA") {
        $('.htmltag').attr('lang', 'ar');
        $('.htmltag').attr('dir', 'rtl');
    }
    else {
        $('.htmltag').attr('lang', 'en');
        $('.htmltag').attr('dir', 'ltr');
    }
    
}



function GetAllHotel() {

    if (culture == "ar-SA") {
        var ss = "<option value=0>اختار الفندق</option>";
    }
    else { var ss = "<option value=0>select Hotel</option>"; }
    
    $.get("/Settings/GetAllHotel", function (data) {
        $.each(data, function (i, j) {
            ss = ss + "<option value=" + j.id + ">" + j.name + "</option>";
        });
        $("#loginhotelid").html(ss);
        $("#hotelId").html(ss); 
        $("#hotelIdd").html(ss); 
        
    });
}
 
function GetSessionHotel() {

    if (culture == "ar-SA") {
        var ss = "<option value=0>اختار الفندق</option>";
    }
    else { var ss = "<option value=0>select Hotel</option>"; } 
   
    $.get("/Settings/GetHotel", function (data) {
        ////console.log(data); 
        var Sessionhotelid = "";
        $.each(data, function (i, j) {
            ss = ss + "<option selected class='text-center' value=" + j.id + ">" + j.name + "</option>";
        });
        $("#Sessionhotelid").html(ss); 
        $("#Shotelid").html(ss);
        Sessionhotelid = $("#Sessionhotelid").val();
       /* alert(Sessionhotelid);*/
        $("#hotel").val(Sessionhotelid);
        $("#customerhotelId").val(Sessionhotelid);
        $("#vendorhotelId").val(Sessionhotelid);
        $("#hotelId").val(Sessionhotelid);
       
        //alert("hid")
        //alert($("#hotelId").val());
    });
}
function GetAllRoomType() {
   
    if (culture == "ar-SA") {
        var ss = "<option value=0>اختار نوع الغرفة</option>";
    }
    else { var ss = "<option value=0>select Room Type</option>"; }




    $.get("/Settings/GetAllRoomType", function (data) {
        $.each(data, function (i, j) {
            ss = ss + "<option value=" + j.id + ">" + j.name + "</option>";
        });
        $("#roomTypeId").html(ss);
        $("#roomTypeIdd").html(ss);

    });
} 
function GetAllRoomStatus() {
    
    if (culture == "ar-SA") {
        var ss = "<option value=0>اختار حالة الغرفة</option>";
    }
    else { var ss = "<option value=0>select Room Status</option>"; }


    $.get("/Settings/GetAllRoomStatus", function (data) {
        $.each(data, function (i, j) {
            ss = ss + "<option value=" + j.id + ">" + j.name + "</option>";
        });
        $("#roomStatusId").html(ss);
        $("#roomStatusIdd").html(ss);

    });
}


function GetAllRoomNo() {
    
    if (culture == "ar-SA") {
        var ss = "<option value=0>اختار رقم الغرفة</option>";
    }
    else { var ss = "<option value=0>select Room Number</option>"; }


    $.get("/Settings/GetAllRoomNo", function (data) {
        $.each(data, function (i, j) {
            ss = ss + "<option value=" + j.id + ">" + j.roomNo + "</option>";
        });
        $("#roomid").html(ss);
        $("#roomId").html(ss);
        $("#roomIdd").html(ss);


    });
}


function GetAllPaymentTypes() {
    
    if (culture == "ar-SA") {
        var ss = "<option value=0> ----اختر---- </option>";
    }
    else { var ss = "<option value=0> ----Select---- </option>"; }

    $.get("/Settings/GetAllPaymentType", function (data) {
        $.each(data, function (i, j) {
            ss = ss + "<option value=" + j.id + ">" + j.name + "</option>";
        });
        $("#paymentTypeId").html(ss);
        $("#paymentVoucherpaymentTypeId").html(ss);

    });
}

function GetAllCurrency() {

    if (culture == "ar-SA") {
        var ss = "<option value=0> ----اختر---- </option>";
    }
    else { var ss = "<option value=0> ----Select---- </option>"; }
    $.get("/Settings/GetAllCurrency", function (data) {
        $.each(data, function (i, j) {
            ss = ss + "<option value=" + j.id + ">" + j.name + "</option>";
        });
        $("#currencyIdRecepit").html(ss); 
        $("#currencyIdVoucher").html(ss);

    });
}














function GetAllPurposeVisit() {
    
    if (culture == "ar-SA") {
        var ss = "<option value=0> اسباب الزيارة</option>";
    }
    else { var ss = "<option value=0> select Purpose Visit</option>"; }

    $.get("/Settings/GetAllPurposeVisit", function (data) {
        ////console.log(data)
        $.each(data, function (i, j) {
            ss = ss + "<option value=" + j.id + ">" + j.name + "</option>";
        });

        $("#purposeVisitId").html(ss);

    });
}

function GetAllAsset() {

    
    if (culture == "ar-SA") {
        var ss = "<option value=0>الاصول</option>";
    }
    else { var ss = "<option value=0>select Asset</option>"; }




    $.get("/Settings/GetAllAsset", function (data) {
        $.each(data, function (i, j) {
            ss = ss + "<option value=" + j.id + ">" + j.name + "</option>";
        });
        $("#assetId").html(ss);
        $("#assetIdd").html(ss);

    });
}

function GetAllAssetType() {
    
    if (culture == "ar-SA") {
        var ss = "<option value=0>اختار نوع المنتج </option>";
    }
    else { var ss = "<option value=0> select Product Type </option>"; } 
    $.get("/Settings/GetAllAssetType", function (data) {
        $.each(data, function (i, j) {
            ss = ss + "<option value=" + j.id + ">" + j.name + "</option>";
        });
        $("#assetTypeId").html(ss);
        $("#assetTypeIdd").html(ss);

    });
}

function GetAllAssetStatus() {
    if (culture == "ar-SA") {
        var ss = "<option value=0>اختار حالة الاصول </option>";
    }
    else { var ss = "<option value=0> select Asset Status</option>"; }

    
    $.get("/Settings/GetAllAssetStatus", function (data) {
        $.each(data, function (i, j) {
            ss = ss + "<option value=" + j.id + ">" + j.name + "</option>";
        });
        $("#assetStatusTypeId").html(ss);
        $("#assetStatusTypeIdd").html(ss);

    });
}

function GetAllUnitType() {
     if (culture == "ar-SA") {
        var ss = "<option value=0>الوحدات </option>";
    }
    else { var ss = "<option value=0> select Unit Type</option>"; }

    $.get("/Settings/GetAllUnitType", function (data) {
        $.each(data, function (i, j) {
            ss = ss + "<option value=" + j.id + ">" + j.name + "</option>";
        });
        $("#unitTypeId").html(ss);
        $("#unitTypeIdd").html(ss);

    });
}


function GetCitiesOnly() {
    
    if (culture == "ar-SA") {
        var ss = "<option value=0>المدن  </option>";
    }
    else { var ss = "<option value=0>select City </option>"; }

    $.get("/Settings/GetCitiesOnly", function (data) {
        $.each(data, function (i, j) {
            ss = ss + "<option value=" + j.id + ">" + j.name + "</option>";
        });
        $("#cityId").html(ss);
        $("#cityIdd").html(ss);
        
    });
}

function GetAllContactType() {
    if (culture == "ar-SA") {
        var ss = "<option value=0>  اختر </option>";
    }
    else { var ss = "<option value=0>select</option>"; }

    
    $.get("/Settings/GetAllContactType", function (data) {
        $.each(data, function (i, j) {
            ss = ss + "<option value=" + j.id + ">" + j.name + "</option>";
        });
        $("#contactTypeId").html(ss);

    });
}

function GetAllIdType() {
    
    if (culture == "ar-SA") {
        var ss = "<option value=0>  نوع الهوية </option>";
    }
    else { var ss = "<option value=0>select Id Type</option>"; }


    $.get("/Settings/GetAllIdType", function (data) {
        $.each(data, function (i, j) {
            ss = ss + "<option value=" + j.id + ">" + j.name + "</option>";
        });
        $("#idTypeId").html(ss);
        $("#idTypeIdd").html(ss);
    });
}

function GetAllCountry() {
    if (culture == "ar-SA") {
        var ss = "<option value=0>  اختر دولة </option>";
    }
    else {
        var ss = "<option value=0> select Country </option>";
 }


    $.get("/Settings/GetAllCountry", function (data) {
        $.each(data, function (i, j) {
            ss = ss + "<option value=" + j.id + ">" + j.name + "</option>";
        });
        $("#countryId").html(ss);
        $("#countryIdd").html(ss);
        $("#countryid").html(ss);
        $("#parentId").html(ss);
        $("#parentIdd").html(ss);
    });
}
 






// ************************************* index view *************************************

$('#loginhotelid').change(function () {
    // set the window's location property to the value of the option the user has selected


    loginhotelid = this.value;


    var jsonData = {

        HotelId: loginhotelid,

    }

    $.post("/Settings/QueryTest", jsonData, function (res) {

        //alert("This action has been saved !");
        window.location.assign("/Vouchers/Dashboard");

    });



});

// ************************************* Asset view *************************************

function getAssets() { 
    var ss = "";
    $.get("/Settings/GetAllAssetInHotel", function (data) {
        ////console.log(data);
        $.each(data, function (i, j) {
            ss = ss + "<tr>";
            ss = ss + "<td class='align-middle text-center text-sm'>" + (i + 1) + "</td>";
            ss = ss + "<td class='align-middle text-center text-sm'>" + j.serialNo + "</td>";
            ss = ss + "<td class='align-middle text-center text-sm'>" + j.assetName + "</td>";
             ss = ss + "<td class='align-middle text-center text-sm'>" + j.naturelofAsset + "</td>";
            ss = ss + "<td class='align-middle text-center text-sm'>" + j.price + "</td>";
            ss = ss + "<td class='align-middle text-center text-sm'>" + j.decription + "</td>";
            ss = ss + "<td class='align-middle text-center text-sm'><button   id='EditForm'    data-bs-toggle='modal' data-bs-target='#EditModal'    class='card-link btn text-center w-30 mx-2 mx-2 edit' onclick='EditFormAsset(" + j.id + ")'><i class='fa-solid fa-pen' aria-hidden='true'></i></button></td>";
            ss = ss + "<td class='float-end me-4'><button   id='DeleteForm'  data-bs-toggle='modal' data-bs-target='#DeleteModal'  class='btn btn-link text-danger text-gradient px-3 mb-0' onclick='DeleteFormAsset(" + j.id + ")'><i class='fa-regular fa-trash-can me-2' aria-hidden='true'></i></button></td>";

            ss = ss + "</tr>";

        });
        $("#tbodyAssets").html(ss);
    });

}
function EditFormAsset(id) {
    $.ajax({
        type: "POST",
        url: "/Settings/GetAsset",
        data: { id: id },
        success: function (Asset) {
            ////console.log(Asset);

            $("#namear").val(Asset.nameAr);
            $("#nameen").val(Asset.nameEn);
            $("#id").val(Asset.id)
            $("#serialNo").val(Asset.serialNo)
            $("#decription").val(Asset.decription);
            $("#naturelofAsset").val(Asset.naturelofAsset);
            $("#price").val(Asset.price);
            $("#assetTypeId").val(Asset.assetTypeId);
            $("#unitTypeId").val(Asset.unitTypeId);
            $("#hotelId").val(Asset.hotelId);


        }
    })


}



function DeleteFormAsset(id) {
    $.ajax({
        type: "POST",
        url: "/Settings/GetAsset",
        data: { id: id },
        success: function (Assetd) {
            ////console.log(Assetd);

            $("#nameard").val(Assetd.nameAr);
            $("#nameend").val(Assetd.nameEn);
            $("#idd").val(Assetd.id)
            $("#serialNod").val(Assetd.serialNo)
            $("#decriptiond").val(Assetd.decription);
            $("#naturelofAssetd").val(Assetd.naturelofAsset);
            $("#priced").val(Assetd.price);
            $("#assetTypeIdd").val(Assetd.assetTypeId);
            $("#unitTypeIdd").val(Assetd.unitTypeId);


        }
    })


}

function clearformAsset() {
    $("#id").val(0);
    $("#namear").val("");
    $("#nameen").val("");
    $("#serialNo").val("");
    $("#decription").val("");
    $("#naturelofAsset").val("");
    $("#price").val("");
    $("#assetTypeId").val("");
    $("#UnitTypeId").val("");
    $("#hotelId").val("");
}


// ************************************* Asset Status view *************************************
function EditFormAssetStatus(id) {
    $.ajax({
        type: "POST",
        url: "/Settings/GetAssetStatusType",
        data: { id: id },
        success: function (AssetStatus) {
            ////console.log(AssetStatus);

            $("#namear").val(AssetStatus.nameAr);
            $("#nameen").val(AssetStatus.nameEn);

            $("#id").val(AssetStatus.id)
        }
    })


}

function DeleteFormAssetStatus(id) {
    $.ajax({
        type: "POST",
        url: "/Settings/GetAssetStatusType",
        data: { id: id },
        success: function (AssetStatusd) {
            ////console.log(AssetStatusd);

            $("#nameard").val(AssetStatusd.nameAr);
            $("#nameend").val(AssetStatusd.nameEn);


        }
    })


}

function clearformAssetStatus() {
    $("#id").val(0);
    $("#namear").val("");
    $("#nameen").val("");
}



// ************************************* Asset view *************************************

function EditFormAssetType(id) {
    $.ajax({
        type: "POST",
        url: "/Settings/GetAssetType",
        data: { id: id },
        success: function (AssetType) {
            ////console.log(AssetType);

            $("#namear").val(AssetType.nameAr);
            $("#nameen").val(AssetType.nameEn);

            $("#id").val(AssetType.id)
        }
    }) 
}

function DeleteFormAssetType(id) {
    $.ajax({
        type: "POST",
        url: "/Settings/GetAssetType",
        data: { id: id },
        success: function (AssetTyped) {
            ////console.log(AssetTyped);
            $("#idd").val(AssetTyped.id);
            $("#nameard").val(AssetTyped.nameAr);
            $("#nameend").val(AssetTyped.nameEn); 
        }

    }) 
}

function clearformAssetType() {
    $("#id").val(0);
    $("#namear").val("");
    $("#nameen").val("");
}


// ************************************* City view *************************************

function getcities() {
    var id = $("#countryid").val();
    if (id > 0) {
        var ss = "";
        $.get("/Settings/GetCountrycities/" + id, function (data) {
            $.each(data, function (i, j) {
                ss = ss + "<tr>";
                ss = ss + "<td class='align-middle text-center text-sm'>" + (i + 1) + "</td>";
                ss = ss + "<td class='align-middle text-center text-sm'>" + j.nameAr + "</td>";
                ss = ss + "<td class='align-middle text-center text-sm'>" + j.nameEn + "</td>";
                ss = ss + "<td class='align-middle text-center text-sm'><button   id='EditForm'    data-bs-toggle='modal' data-bs-target='#EditModal'    class='card-link btn text-center w-30 mx-2 mx-2 edit' onclick='EditFormcities(" + j.id + ")'><i class='fa-solid fa-pen' aria-hidden='true'></i></button></td>";
                ss = ss + "<td class='float-end me-4'><button   id='DeleteForm'  data-bs-toggle='modal' data-bs-target='#DeleteModal'  class='btn btn-link text-danger text-gradient px-3 mb-0' onclick='DeleteFormcities(" + j.id + ")'><i class='fa-regular fa-trash-can me-2' aria-hidden='true'></i></button></td>";
                ss = ss + "</tr>";

            });
            $("#tbodycities").html(ss);
        });
    }
}

function EditFormcities(id) {
    $.ajax({
        type: "POST",
        url: "/Settings/GetCity",
        data: { id: id },
        success: function (City) {
            ////console.log(City);

            $("#namear").val(City.nameAr);
            $("#nameen").val(City.nameEn);
            $("#id").val(City.id)
            $("#parentId").val(City.parentId)
        }
    })


}
function DeleteFormcities(id) {
    $.ajax({
        type: "POST",
        url: "/Settings/GetCity",
        data: { id: id },
        success: function (Cityd) {
            ////console.log(Cityd);

            $("#nameArd").val(Cityd.nameAr);
            $("#nameEnd").val(Cityd.nameEn);
            $("#idd").val(Cityd.id)

            $("#parentIdd").val(Cityd.parentId);


        }
    })


}


function clearformcities() {
    $("#id").val(0);
    $("#namear").val("");
    $("#nameen").val("");
}

// ************************************* Company *************************************

function GetCompany() {

    var ss = "";
    $.get("/Settings/GetAllCompany", function (data) {
        $.each(data, function (i, j) {
            ss = ss + "<tr>";
            ss = ss + "<td class='align-middle text-center text-sm'>" + (i + 1) + "</td>";
            ss = ss + "<td class='align-middle text-center text-sm'>" + j.name + "</td>";
            ss = ss + "<td class='align-middle text-center text-sm'>" + j.city + "</td>";

            ss = ss + "<td class='align-middle text-center text-sm'>" + j.fullAddress + "</td>";
            ss = ss + "<td class='align-middle text-center text-sm'>" + j.vatNo + "</td>";
            ss = ss + "<td class='align-middle text-center text-sm'><button   id='EditForm' data-bs-toggle='modal' data-bs-target='#EditModal' class='card-link btn text-center w-30 mx-2 mx-2 edit' onclick='EditFormCompany(" + j.id + ")'><i class='fa-solid fa-pen' aria-hidden='true'></i></button></td>";
            ss = ss + "<td class='float-end me-4'><button     id='DeleteForm' class='btn btn-link text-danger text-gradient px-3 mb-0' data-bs-toggle='modal' data-bs-target='#DeleteModal' onclick='DeleteFormCompany(" + j.id + ")'><i class='fa-regular fa-trash-can me-2' aria-hidden='true'></i></button></td>";
            ss = ss + "<td class='align-middle text-center text-sm'><button    id='contactForm' data-bs-toggle='modal'     data-bs-target='#contactModal' class='card-link btn text-center w-30 mx-2 mx-2'  onclick='GetAllCompanycontact(" + j.id + ")'> <i class='fa-solid fa-plus text-success'></i></button></td>";

            ss = ss + "</tr>";

        });
        $("#tbodyCompanys").html(ss);
    });

}
function EditFormCompany(id) {
    $.ajax({
        type: "POST",
        url: "/Settings/GetCompany",
        data: { id: id },
        success: function (Company) {
            ////console.log(Company);

            $("#namear").val(Company.nameAr);
            $("#nameen").val(Company.nameEn);

            $("#fullAddressAr").val(Company.fullAddressAr);
            $("#fullAddressEn").val(Company.fullAddressEn);

            $("#buildingNo").val(Company.buildingNo);

            $("#zipeCode").val(Company.zipeCode);
            $("#responsableName").val(Company.responsableName);
            $("#vatNo").val(Company.vatNo);
            $("#countryId").val(Company.countryId);
            $("#id").val(Company.id)
        }
    })


}

function DeleteFormCompany(id) {
    $.ajax({
        type: "POST",
        url: "/Settings/GetCompany",
        data: { id: id },
        success: function (Companyd) {
            //console.log(Companyd);
            $("#nameard").val(Companyd.nameAr);
            $("#nameend").val(Companyd.nameEn);
            $("#fullAddressArd").val(Companyd.fullAddressAr);
            $("#fullAddressEnd").val(Companyd.fullAddressEn);

            $("#buildingNod").val(Companyd.buildingNo);

            $("#vatNod").val(Companyd.vatNo);
            $("#countryIdd").val(Companyd.countryId)
            $("#idd").val(Companyd.id)
        }
    })
}
 
$('#saveCompany').click(function () {
    var jsonData = {

        Value: $("#value").val(),
        Description: $("#description").val(),
        ContactTypeId: $("#contactTypeId").val(),
        CompanyId: $("#companyid").val(),
        Id: $("#contactid").val(),

    }
    $.post("/Settings/UpdateCompanyContact", jsonData, function (res) {

        if (culture == "ar-SA") {
            alert("تم حفط البيانات بنجاح ");
        }
        else { alert("This action has been saved !"); }


    });


});

function GetAllCompanycontact(id) {
    $("#companyid").val(id);
    var id = $("#companyid").val();

    if (id > 0) {
        var ss = "";
        $.get("/Settings/GetAllCompanycontact/" + id, function (data) {
            //console.log(data);
            $.each(data, function (i, j) {
                ss = ss + "<tr>";
                ss = ss + "<td class='align-middle text-center text-sm'>" + (i + 1) + "</td>";
                ss = ss + "<td class='align-middle text-center text-sm'>" + j.contacttypenam + "</td>";
                ss = ss + "<td class='align-middle text-center text-sm'>" + j.contactvalue + "</td>";
                ss = ss + "<td class='align-middle text-center text-sm'>" + j.contactdescription + "</td>";

                ss = ss + "</tr>";
                //$("#companyid").val(j.id);
            });

            $("#Companycontactbody").html(ss);
        });
    }
}
 
function clearformCompany() {
    $("#id").val(0);
    $("#namear").val("");
    $("#nameen").val("");

    $("#fullAddressAr").val("");
    $("#fullAddressEn").val("");


    $("#buildingNo").val("");

    $("#zipeCode").val("");


    $("#vatNo").val("");
}

function clearCompanycontactmodal() {

    $("#value").val("");
    $("#description").val("");
    $("#contactTypeId").val(0);
    $("#companyid").val(0);
    $("#contactid").val(0);

}


// ************************************* ContactType view *************************************
function EditFormContactType(id) {
    $.ajax({
        type: "POST",
        url: "/Settings/GetContactType",
        data: { id: id },
        success: function (ContactType) {
            //console.log(ContactType);

            $("#namear").val(ContactType.nameAr);
            $("#nameen").val(ContactType.nameEn);

            $("#id").val(ContactType.id)
        }
    })


}

function DeleteFormContactType(id) {
    $.ajax({
        type: "POST",
        url: "/Settings/GetContactType",
        data: { id: id },
        success: function (ContactTyped) {
            //console.log(ContactTyped);
            $("#nameArd").val(ContactTyped.nameAr);
            $("#nameEnd").val(ContactTyped.nameEn);
            $("#idd").val(ContactTyped.id)
        }
    })


}

function clearformContactType() {
    $("#id").val(0);
    $("#namear").val("");
    $("#nameen").val("");
}


// ************************************* Country view *************************************
function EditFormCountry(id) {
    $.ajax({
        type: "POST",
        url: "/Settings/GetCountry",
        data: { id: id },
        success: function (Country) {
            //console.log(Country);
            $("#namear").val(Country.nameAr);
            $("#nameen").val(Country.nameEn);
            $("#id").val(Country.id)
        }
    })


}

function DeleteFormCountry(id) {
    $.ajax({
        type: "POST",
        url: "/Settings/GetCountry",
        data: { id: id },
        success: function (Countryd) {
            //console.log(Countryd);
            $("#nameArd").val(Countryd.nameAr);
            $("#nameEnd").val(Countryd.nameEn);
            $("#idd").val(Countryd.id)
        }
    })


}

function clearformCountry() {
    $("#id").val(0);
    $("#namear").val("");
    $("#nameen").val("");
}

// ************************************* Currency view *************************************
function EditFormCurrency(id) {
    $.ajax({
        type: "POST",
        url: "/Settings/GetCurrency",
        data: { id: id },
        success: function (Curncy) {
            //console.log(Curncy);
            $("#namear").val(Curncy.nameAr);
            $("#nameen").val(Curncy.nameEn);
            $("#id").val(Curncy.id)
        }
    })


}

function DeleteFormCurrency(id) {
    $.ajax({
        type: "POST",
        url: "/Settings/GetCurrency",
        data: { id: id },
        success: function (Curncyd) {
            //console.log(Curncyd);
            $("#nameArd").val(Curncyd.nameAr);
            $("#nameEnd").val(Curncyd.nameEn);
            $("#idd").val(Curncyd.id)
        }
    })


}

function clearformCurrency() {
    $("#id").val(0);
    $("#namear").val("");
    $("#nameen").val("");
}



// ************************************* Customer view *************************************

function GetAllCustomerInHotel() {


    var ss = "";
    $.get("/Settings/GetAllCustomerInHotel", function (data) {
        $.each(data, function (i, j) {
            ss = ss + "<tr>";
            ss = ss + "<td class='align-middle text-center text-sm'> <span class='text-xs font-weight-bold'>" + (i + 1) + "</span></td>";

            ss = ss + "<td class='align-middle text-center text-sm'> <span class='text-xs font-weight-bold'>" + j.firstName + j.lastName + "</span></td>";
            //ss = ss + "<td class='align-middle text-center text-sm'>" + j.isShare + "</td>";
            ss = ss + "<td class='align-middle text-center text-sm'> <span class='text-xs font-weight-bold'>" + j.isCompony + "</span></td>";
            ss = ss + "<td class='align-middle text-center text-sm'> <span class='text-xs font-weight-bold'>" + j.idValue + "</span></td>";
            ss = ss + "<td class='align-middle text-center text-sm'> <span class='text-xs font-weight-bold'>" + j.countryName + "</span></td>";



            ss = ss + "<td class='align-middle text-center text-sm' ><button   id='EditForm'    data-bs-toggle='modal' data-bs-target='#EditModal'    class='card-link btn text-center w-30 mx-2 mx-2  edit' onclick='EditFormCustomer(" + j.id + ")'><i class='fa-solid fa-pen' aria-hidden='true'></i></button></td>";
            ss = ss + "<td class='float-end me-4' ><button   id='DeleteForm'  data-bs-toggle='modal' data-bs-target='#DeleteModal'  class='btn btn-link text-danger text-gradient w-30 mx-2 mx-2' onclick='DeleteFormCustomer(" + j.id + ")'><i class='fa-regular fa-trash-can me-2' aria-hidden='true'></i></button></td>";
            ss = ss + "<td class='align-middle text-center text-sm' ><button   id='contactForm' data-bs-toggle='modal' data-bs-target='#contactModal'    class='card-link btn text-center w-30 mx-2 mx-2' onclick='Getcustomercontacts(" + j.id + ")'><i class='fa-solid fa-plus text-success'></i></button></td>";

            ss = ss + "</tr>";
            //$("#customerid").val(j.id);
        });

        $("#tbodycustomer").html(ss);
    });

}

function EditFormCustomer(id) {
    $.ajax({
        type: "POST",
        url: "/Settings/GetCustomer",
        data: { id: id },
        success: function (customer) {
            //console.log(customer);

            $("#nameAr").val(customer.firstName);
            $("#nameEn").val(customer.lastName);
            $("#idValue").val(customer.idValue);
            $("#idTypeId").val(customer.idTypeId);
            $("#countryId").val(customer.countryId);
            $("#hotelId").val(customer.hotelId);


            $("#countryId").val(customer.countryId);
            $("#hotelId").val(customer.hotelId);

            $("#id").val(customer.id)
        }
    })


}

function DeleteFormCustomer(id) {
    $.ajax({
        type: "POST",
        url: "/Settings/GetCustomer",
        data: { id: id },
        success: function (customerd) {
            //console.log(customerd);

            $("#nameArd").val(customerd.firstName);
            $("#nameEnd").val(customerd.lastName);
            $("#idValued").val(customerd.idValue);
            $("#idTypeIdd").val(customerd.idTypeId);
            $("#countryIdd").val(customerd.countryId);
            $("#hotelIdd").val(customerd.hotelId);

            $("#idd").val(customerd.id)
        }
    })


}

$('#saveCustomercontact').click(function () {
    var jsonData = {

        Value: $("#value").val(),
        Description: $("#description").val(),
        ContactTypeId: $("#contactTypeId").val(),
        CustomerId: $("#customerid").val(),
        Id: $("#contactid").val(),

    }
    $.post("/Settings/UpdateCustomerContact", jsonData, function (res) {

        if (culture == "ar-SA") {
            alert("تم حفط البيانات بنجاح ");
            $("#contactModal").modal("toggle");
        }
        else {
            alert("This action has been saved !");
            $("#contactModal").modal("toggle");
        }


    });


});

function Getcustomercontacts(id) {
    $("#customerid").val(id);
    var id = $("#customerid").val();
    //console.log(id);
    //console.log(id);
    if (id > 0) {
        var ss = "";
        $.get("/Settings/GetAllCustomercontact/" + id, function (data) {
            //console.log(data);
            $.each(data, function (i, j) {
                ss = ss + "<tr>";
                ss = ss + "<td class='align-middle text-center text-sm'>" + (i + 1) + "</td>";
                ss = ss + "<td class='align-middle text-center text-sm'>" + j.contacttypenam + "</td>";
                ss = ss + "<td class='align-middle text-center text-sm'>" + j.contactvalue + "</td>";
                ss = ss + "<td class='align-middle text-center text-sm'>" + j.contactdescription + "</td>";

                ss = ss + "</tr>";
                //$("#customerid").val(j.id);
            });

            $("#customercontactbody").html(ss);
        });
    }
}

function clearformCustomerCustomer() {
    $("#id").val(0);
    $("#nameAr").val("");
    $("#nameEn").val("");

    $("#idValue").val("");
    $("#idTypeId").val("");
    $("#countryId").val("");
    $("#hotelId").val("");
}

function clearCustomercontactmodal() {

    $("#value").val("");
    $("#description").val("");
    $("#contactTypeId").val(0);
    $("#customerid").val(0);
    $("#contactid").val(0);

}




// ************************************* Employee view *************************************

function GetEmployee() {

    var ss = "";
    $.get("/Settings/GetAllEmployeeInHotel", function (data) {
        $.each(data, function (i, j) {
            ss = ss + "<tr>";
            ss = ss + "<td class='align-middle text-center text-sm'>" + (i + 1) + "</td>";
            ss = ss + "<td class='align-middle text-center text-sm'>" + j.name + "</td>";
            ss = ss + "<td class='align-middle text-center text-sm'>" + j.birthDate + "</td>";
            ss = ss + "<td class='align-middle text-center text-sm'>" + j.idNumber + "</td>";
            ss = ss + "<td class='align-middle text-center text-sm'>" + j.countryName + "</td>";
            ss = ss + "<td class='align-middle text-center text-sm'><button   id='EditForm'    data-bs-toggle='modal' data-bs-target='#EditModal'    class='card-link btn text-center w-30 mx-2 mx-2 edit' onclick='EditFormEmployee(" + j.id + ")'><i class='fa-solid fa-pen' aria-hidden='true'></i></button></td>";
            ss = ss + "<td class='float-end me-4'><button   id='DeleteForm'  data-bs-toggle='modal' data-bs-target='#DeleteModal'  class='btn btn-link text-danger text-gradient px-3 mb-0' onclick='DeleteFormEmployee(" + j.id + ")'><i class='fa-regular fa-trash-can me-2' aria-hidden='true'></i></button></td>";
            ss = ss + "</tr>";

        });
        $("#tbodyEmployee").html(ss);
    });

}

function EditFormEmployee(id) {
    $.ajax({
        type: "POST",
        url: "/Settings/GetEmployee",
        data: { id: id },
        success: function (Employee) {
            //console.log(Employee);

            $("#nameAr").val(Employee.nameAr);
            $("#nameEn").val(Employee.nameEn);
            $("#id").val(Employee.id)
            $("#birthDate").val(Employee.birthDate)
            $("#idNumber").val(Employee.idNumber);

            $("#hotelId").val(Employee.hotelId);
            $("#idTypeId").val(Employee.idTypeId);
            $("#countryId").val(Employee.countryId);


        }
    })


}

function DeleteFormEmployee(id) {
    $.ajax({
        type: "POST",
        url: "/Settings/GetEmployee",
        data: { id: id },
        success: function (Employeed) {
            //console.log(Employeed);

            $("#nameArd").val(Employeed.nameAr);
            $("#nameEnd").val(Employeed.nameEn);
            $("#idd").val(Employeed.id);
            $("#birthDated").val(Employeed.birthDate);
            $("#idNumberd").val(Employeed.idNumber); 
            $("#idTypeIdd").val(Employeed.idTypeId);
            $("#countryIdd").val(Employeed.countryId);
        }
    })


}

function clearformEmployee() {
    $("#id").val(0);
    $("#nameAr").val("");
    $("#nameEn").val("");
    $("#birthDate").val("");
    $("#idNumber").val("");
    $("#hotelId").val("");
    $("#idTypeId").val("");
    $("#countryId").val("");
}

// ************************************* Hotel view *************************************

function EditFormHotel(id) {
    $.ajax({
        type: "POST",
        url: "/Settings/GetHotelbyid",
        data: { id: id },
        success: function (Hotel) {
            //console.log(Hotel);

            $("#namear").val(Hotel.nameAr);
            $("#nameen").val(Hotel.nameEn);

            $("#floorNo").val(Hotel.floorNo);
            $("#roomNo").val(Hotel.roomNo);
            $("#fullAddressAr").val(Hotel.fullAddressAr);
            $("#fullAddressEn").val(Hotel.fullAddressEn);

            $("#gps").val(Hotel.gps);
            $("#buildingNo").val(Hotel.buildingNo);
            $("#postBox").val(Hotel.postBox);
            $("#zipeCode").val(Hotel.zipeCode);

            $("#checkInTime").val(Hotel.checkInTime);
            $("#checkOut").val(Hotel.checkOut);
            $("#actualCheckOut").val(Hotel.actualCheckOut);
            $("#vatNo").val(Hotel.vatNo);

            $("#cR").val(Hotel.cr);
            $("#logo").val(Hotel.logo);
            $("#countryId").val(Hotel.countryId);
            $("#id").val(Hotel.id)
        }
    })


}

function DeleteFormHotel(id) {
    $.ajax({
        type: "POST",
        url: "/Settings/GetHotel",
        data: { id: id },
        success: function (Hoteld) {
            //console.log(Hoteld);
            $("#nameard").val(Hoteld.nameAr);
            $("#nameend").val(Hoteld.nameEn);

            $("#floorNod").val(Hoteld.floorNo);
            $("#roomNod").val(Hoteld.roomNo);
            $("#fullAddressArd").val(Hoteld.fullAddressAr);
            $("#fullAddressEnd").val(Hoteld.fullAddressEn);

            $("#buildingNod").val(Hoteld.buildingNo);

            $("#checkInTimed").val(Hoteld.checkInTime);
            $("#checkOutd").val(Hoteld.checkOut);
            $("#actualCheckOutd").val(Hoteld.actualCheckOut);
            $("#vatNod").val(Hoteld.vatNo);

            $("#cRd").val(Hoteld.cr);
            $("#countryIdd").val(Hoteld.countryId)
            $("#idd").val(Hoteld.id)
        }
    })
}
function clearformHotel() {
    $("#id").val(0);
    $("#namear").val("");
    $("#nameen").val("");
    $("#floorNo").val("");
    $("#roomNo").val("");
    $("#fullAddressAr").val("");
    $("#fullAddressEn").val("");

    $("#gps").val("");
    $("#buildingNo").val("");
    $("#postBox").val("");
    $("#zipeCode").val("");

    $("#checkInTime").val("");
    $("#checkOut").val("");
    $("#actualCheckOut").val("");
    $("#vatNo").val("");

    $("#cR").val("");
    $("#logo").val("");
}

$('#saveHotelcontact').click(function () {
    var jsonData = {

        Value: $("#value").val(),
        Description: $("#description").val(),
        ContactTypeId: $("#contactTypeId").val(),
        HotelId: $("#hotelid").val(),
        IsDefault: $("#isDefault").val(),
        Id: $("#contactid").val(),

    }
    $.post("/Settings/UpdateHotelContact", jsonData, function (res) {

        if (culture == "ar-SA") {
            alert("تم حفط البيانات بنجاح ");
        }
        else { alert("This action has been saved !"); }


    });


});

function GetAllHotelcontact(id) {
    $("#hotelid").val(id);
    var id = $("#hotelid").val();

    if (id > 0) {
        var ss = "";
        $.get("/Settings/GetAllHotelcontact/" + id, function (data) {
            //console.log(data);
            $.each(data, function (i, j) {
                ss = ss + "<tr>";
                ss = ss + "<td class='align-middle text-center text-sm'>" + (i + 1) + "</td>";
                ss = ss + "<td class='align-middle text-center text-sm'>" + j.contacttypenam + "</td>";
                ss = ss + "<td class='align-middle text-center text-sm'>" + j.contactvalue + "</td>";
                ss = ss + "<td class='align-middle text-center text-sm'>" + j.contactdescription + "</td>";

                ss = ss + "</tr>";

            });

            $("#hotelContactbody").html(ss);
        });
    }
}

function clearHotelContactModal() {

    $("#value").val("");
    $("#description").val("");
    $("#contactTypeId").val(0);
    $("#companyid").val(0);
    $("#contactid").val(0);

}


// ************************************* IdType view *************************************

function EditFormIdType(id) {
    $.ajax({
        type: "POST",
        url: "/Settings/GetIdType",
        data: { id: id },
        success: function (IdType) {
            //console.log(IdType);

            $("#namear").val(IdType.nameAr);
            $("#nameen").val(IdType.nameEn);

            $("#id").val(IdType.id)
        }
    })


}

function DeleteFormIdType(id) {
    $.ajax({
        type: "POST",
        url: "/Settings/GetIdType",
        data: { id: id },
        success: function (IdTyped) {
            //console.log(IdTyped);
            $("#nameArd").val(IdTyped.nameAr);
            $("#nameEnd").val(IdTyped.nameEn);
            $("#idd").val(IdTyped.id)
        }
    })


}
function clearformIdType() {
    $("#id").val(0);
    $("#namear").val("");
    $("#nameen").val("");
}


// ************************************* PaymentType view *************************************
function EditFormPaymentType(id) {
    $.ajax({
        type: "POST",
        url: "/Settings/GetPaymentType",
        data: { id: id },
        success: function (PaymentType) {
            //console.log(PaymentType);

            $("#namear").val(PaymentType.nameAr);
            $("#nameen").val(PaymentType.nameEn);

            $("#id").val(PaymentType.id)
        }
    })


}

function DeleteFormPaymentType(id) {
    $.ajax({
        type: "POST",
        url: "/Settings/GetPaymentType",
        data: { id: id },
        success: function (PaymentTyped) {
            //console.log(PaymentTyped);
            $("#nameArd").val(PaymentTyped.nameAr);
            $("#nameEnd").val(PaymentTyped.nameEn);
            $("#idd").val(PaymentTyped.id)
        }
    })


}

function clearformPaymentType() {
    $("#id").val(0);
    $("#namear").val("");
    $("#nameen").val("");
}
// ************************************* PurposeVisit view *************************************

function EditFormPurposeVisit(id) {
    $.ajax({
        type: "POST",
        url: "/Settings/GetPurposeVisit",
        data: { id: id },
        success: function (PurposeVisit) {
            //console.log(PurposeVisit);

            $("#namear").val(PurposeVisit.nameAr);
            $("#nameen").val(PurposeVisit.nameEn);

            $("#id").val(PurposeVisit.id)
        }
    })


}
function DeleteFormPurposeVisit(id) {
    $.ajax({
        type: "POST",
        url: "/Settings/GetPurposeVisit",
        data: { id: id },
        success: function (PurposeVisitd) {
            //console.log(PurposeVisitd);
            $("#nameArd").val(PurposeVisitd.nameAr);
            $("#nameEnd").val(PurposeVisitd.nameEn);
            $("#idd").val(PurposeVisitd.id)
        }
    })


}
function clearformPurposeVisit() {
    $("#id").val(0);
    $("#namear").val("");
    $("#nameen").val("");
}

// ************************************* Room view *************************************
function GetRooms() {

    
    var ss = "";
    $.get("/Settings/GetAllRoomInHotel", function (data) {
        $.each(data, function (i, j) {
            ss = ss + "<tr>";
            ss = ss + "<td class='align-middle text-center text-sm'>" + (i + 1) + "</td>";
            ss = ss + "<td class='align-middle text-center text-sm'>" + j.roomNo + "</td>";
            ss = ss + "<td class='align-middle text-center text-sm'>" + j.floorNo + "</td>";
            ss = ss + "<td class='align-middle text-center text-sm'>" + j.normalPrice + "</td>";
            ss = ss + "<td class='align-middle text-center text-sm'>" + j.minPrice + "</td>";
            ss = ss + "<td class='align-middle text-center text-sm'>" + j.singleBedNo + "</td>";
            ss = ss + "<td class='align-middle text-center text-sm'>" + j.doubleBedNo + "</td>";
            ss = ss + "<td class='align-middle text-center text-sm'>" + j.wcNo + "</td>";
 
            ss = ss + "<td class='align-middle text-center text-sm'><button   id='EditForm'    data-bs-toggle='modal' data-bs-target='#EditModal'    class='card-link btn text-center w-30 mx-2 mx-2 edit' onclick='EditFormRoom(" + j.id + ")'><i class='fa-solid fa-pen' aria-hidden='true'></i></button></td>";
            ss = ss + "<td class='float-end me-4'><button   id='DeleteForm'  data-bs-toggle='modal' data-bs-target='#DeleteModal'  class='btn btn-link text-danger text-gradient px-3 mb-0' onclick='DeleteFormRoom(" + j.id + ")'><i class='fa-regular fa-trash-can me-2' aria-hidden='true'></i></button></td>";
            ss = ss + "</tr>";

        });
        $("#tbodyRoom").html(ss);
    });
     
}

function EditFormRoom(id) {
    $.ajax({
        type: "POST",
        url: "/Settings/GetRoom",
        data: { id: id },
        success: function (Room) {
            //console.log(Room);

            $("#roomNo").val(Room.roomNo);
            $("#floorNo").val(Room.floorNo);
            $("#id").val(Room.id)
            $("#normalPrice").val(Room.normalPrice)
            $("#minPrice").val(Room.minPrice);
            $("#singleBedNo").val(Room.singleBedNo);
            $("#doubleBedNo").val(Room.doubleBedNo);
            $("#wcNo").val(Room.wcNo);
            
            $("#roomTypeId").val(Room.roomTypeId);
            $("#roomStatusId").val(Room.roomStatusId);


        }
    })


}

function DeleteFormRoom(id) {
    $.ajax({
        type: "POST",
        url: "/Settings/GetRoom",
        data: { id: id },
        success: function (Roomd) {
            //console.log(Roomd);

            $("#roomNod").val(Roomd.roomNo);
            $("#floorNod").val(Roomd.floorNo);
            $("#idd").val(Roomd.id)
            $("#normalPriced").val(Roomd.normalPrice)
            $("#minPriced").val(Roomd.minPrice);
            $("#singleBedNod").val(Roomd.singleBedNo);

            $("#doubleBedNod").val(Roomd.doubleBedNo);
            $("#wcNod").val(Roomd.wcNo);
             $("#roomTypeIdd").val(Roomd.roomTypeId);
            $("#roomStatusIdd").val(Roomd.roomStatusId);


        }
    })


}

function clearformRoom() {
    $("#id").val(0);
    $("#roomNo").val("");
    $("#floorNo").val("");
    $("#normalPrice").val("");
    $("#minPrice").val("");
    $("#singleBedNo").val("");
    $("#doubleBedNo").val("");
    $("#wcNo").val("");
     
    $("#roomTypeId").val("");
    $("#roomStatusId").val("");
}




// ************************************* Room Asset view *************************************
function GetAllAssetInRoom() {

    var id = $("#roomid").val();
    if (id > 0) {
        var ss = "";
        $.get("/Settings/GetAllAssetInRoom/" + id, function (data) {
            $.each(data, function (i, j) {
                ss = ss + "<tr>";
                ss = ss + "<td class='align-middle text-center text-sm'>" + (i + 1) + "</td>";
                ss = ss + "<td class='align-middle text-center text-sm'>" + j.assetName + "</td>";
                ss = ss + "<td class='align-middle text-center text-sm'>" + j.assettypeName + "</td>";
                ss = ss + "<td class='align-middle text-center text-sm'>" + j.qty + "</td>";
                ss = ss + "<td class='align-middle text-center text-sm'><button   id='EditForm'    data-bs-toggle='modal' data-bs-target='#EditModal'    class='card-link btn text-center w-30 mx-2 mx-2 edit' onclick='EditFormRoomAsset(" + j.id + ")'><i class='fa-solid fa-pen' aria-hidden='true'></i></button></td>";
                ss = ss + "<td class='float-end me-4'><button   id='DeleteForm'  data-bs-toggle='modal' data-bs-target='#DeleteModal'  class='btn btn-link text-danger text-gradient px-3 mb-0' onclick='DeleteFormRoomAsset(" + j.id + ")'><i class='fa-regular fa-trash-can me-2' aria-hidden='true'></i></button></td>";
                ss = ss + "</tr>";

            });
            $("#tbodyRoomAsset").html(ss);
        });
    }
}

function EditFormRoomAsset(id) {
    $.ajax({
        type: "POST",
        url: "/Settings/GetRoomAsset",
        data: { id: id },
        success: function (RoomAsset) {
            //console.log(RoomAsset);
            $("#id").val(RoomAsset.id);
            $("#qty").val(RoomAsset.qty);
            $("#roomId").val(RoomAsset.roomId);
            $("#assetId").val(RoomAsset.assetId);
            $("#assetTypeId").val(RoomAsset.assetTypeId);
        }
    })
}

function DeleteFormRoomAsset(id) {
    $.ajax({
        type: "POST",
        url: "/Settings/GetRoomAsset",
        data: { id: id },
        success: function (RoomAssetd) {
            //console.log(RoomAssetd);
            $("#idd").val(RoomAssetd.id);
            $("#qtyd").val(RoomAssetd.qty);
            $("#roomIdd").val(RoomAssetd.roomId);
            $("#assetIdd").val(RoomAssetd.assetId);
            $("#assetTypeIdd").val(RoomAssetd.assetTypeId);


        }

    })


}

function clearformRoomAsset() {
    $("#id").val(0);
    $("#qty").val("");
    $("#roomId").val("");
    $("#assetId").val("");
    $("#assetTypeId").val("");
}

 
// ************************************* Room Scheme View *************************************

function GetRoomSchema() {
     
             
    var flatDiv = '';
    $.get("/Settings/GetAllRoomInHotel", function (data) {
       
        
        $.each(data, function (i, j) {
            console.log(j);
            if (j.status == 'فارغه' || j.status == 'Avilable') {
                flatDiv += '<div class="card w-80 w-md-40 w-lg-30 w-sm-80 mx-2 mb-4 bg-transparent shadow-none free" style="background-color:darkgray">';
            }
            else if (j.status == 'تحت الصيانه' || j.status == 'Under maintenance') {
                flatDiv += '<div class="card w-80 w-md-40 w-lg-30 w-sm-80 mx-2 mb-4 bg-transparent shadow-none maintenance" style="background-color:darkgray">';
            }
            else if (j.status == 'مشغوله' || j.status == 'Reserved') {
                flatDiv += '<div class="card w-80 w-md-40 w-lg-30 w-sm-80 mx-2 mb-4 bg-transparent shadow-none reserved" style="background-color:darkgray">';
            }
            else {
                flatDiv += '<div class="card w-80 w-md-40 w-lg-30 w-sm-80 mx-2 mb-4 bg-transparent shadow-none offservice" style="background-color:darkgray">';
            }
            flatDiv += '<form class="cardbody" action="">';

             // ************ card-body front ************

            flatDiv += '<div class="card-body front"> ';
            flatDiv += '<div class="icon icon-shape shadow text-center border-radius-md rounded-circle"><i class="fa-solid fa-eye text-lg opacity-10"></i></div>';

            // ************ card Data ************

            if (culture == "ar-SA") {
                flatDiv += '<h6 class="card-title mb-1"> غرفة  &nbsp;' + j.roomNo + ' || '+ j.status + '</h6>';
            }
            else {
                flatDiv += '<h6 class="card-title mb-1"> Room &nbsp;' + j.roomNo + ' || ' + j.status + '</h6>';
            }

 
            if (j.status == 'مشغوله' && j.contractDuration != 0 && culture == "ar-SA")  {
                flatDiv += '<h6 class="card-title mb-1" style="font-size:0.9vw;color:black"> من  &nbsp' + j.contractCheckInTime + ' || إلي ' + j.contractCheckOut + '</h6>';
                flatDiv += '<h6 class="card-title mb-1" style="font-size:0.9vw;color:black"> المدة &nbsp' + j.contractDuration + '   أيام' + ' || القيمة  ' + j.totalPrice + '</h6>';
 
            }
            else if ( (j.status == 'Reserved' && j.contractDuration != 0)) {
                flatDiv += '<h6 class="card-title mb-1" style="font-size:0.8vw;color:black"> From &nbsp' + j.contractCheckInTime + ' || To ' + j.contractCheckOut + '</h6>';
                flatDiv += '<h6 class="card-title mb-1" style="font-size:0.9vw;color:black"> Period   &nbsp' + j.contractDuration + ' Days' + ' || Total  ' + j.totalPrice + '</h6>';
 
            }

            flatDiv += '<div class="square bg-light rounded my-4"></div>';

            // ************ End card Data ************

            // ************ buttons front ************

            flatDiv += '<div class="col d-flex flex-row justify-content-center align-items-center"> ';

            if (j.status == 'فارغه' || j.status == 'Avilable') {
                flatDiv += '<a class="card-link btn text-center mx-2 w-30" href = "/Vouchers/Contract?room=' + j.id + '" > <i class="fa-solid fa-key text-Re fs-6 pb-1"></i></a>';
            }
            if (j.status != 'مشغوله' && j.status != 'Reserved') {
                flatDiv += '<button type="button" data-bs-toggle="modal" data-bs-target="#EditModal" class="card-link btn text-center w-30 mx-2 mx-2 edit" onclick = "EditFormRoomscheme(' + j.id + ')"> <i class="fa-solid fa-pen"></i></button>';

            }
            flatDiv += '<button type="button" class="card-link btn text-center mx-2 w-30 info" onclick="cardback()"  ><i class="fa-solid fa-info"></i></button>';
           
            flatDiv += '</div>';
            flatDiv += '</div>';

            // ************ End buttons front ************

            // ************ card-body back ************

            flatDiv += '<div class="card-body back">';
            flatDiv += '<div class="btn-group mt-3 d-flex justify-content-center">'; 
            flatDiv += '</div>';

            // ************  card Data ************
            flatDiv += '<div class="btn-group d-flex justify-content-center"> '; 
            flatDiv += '<input type="radio" class="btn-check" name = "room3" id = "room3-1" autocomplete = "off" >';

            if (culture == "ar-SA") { 
                flatDiv += '<input type="radio" class="btn-check" name = "room3" id = "room3-2" autocomplete="off" >';
                flatDiv += '<label class="btn btn-outline-primary w-25 px-0 py-2 m-1 rounded-2" for= "room3-2" checked style="font-size:1vw;" >الطابق  &nbsp;' + j.floorNo + ' </label>';
            }
            else { 
                flatDiv += '<input type="radio" class="btn-check" name = "room3" id = "room3-2" autocomplete="off" >';
                flatDiv += '<label class="btn btn-outline-primary w-25 px-0 py-2 m-1 rounded-2" for= "room3-2" checked style="font-size:1vw;" >Floor &nbsp;' + j.floorNo + ' </label>';
            }
             
            flatDiv += '<input type="radio" class="btn-check" name = "room3" id = "room3-3" autocomplete = "off" >';
            flatDiv += '<label class="btn btn-outline-primary w-25 px-0 py-2 m-1 rounded-2" for="room3-3" style="font-size:1vw;"> ' + j.typename + ' </label>';
            flatDiv += '<input type="radio" class="btn-check" name = "room3" id="room3-4" autocomplete = "off" >';
            flatDiv += ' <label class="btn btn-outline-primary w-25 px-0 py-2 m-1 rounded-2" for="room3-4"  style="font-size:1vw;" > ' + j.normalPrice + '$ </label>';

            flatDiv += '</div>';

            flatDiv += '<div class="btn-group d-flex justify-content-center">';
            if ((j.status == 'مشغوله' && j.contractDuration != 0 && culture == "ar-SA") || (j.status == 'Reserved' && j.contractDuration != 0 && culture == "ar-SA")) {
                flatDiv += '<button type="button" data-bs-toggle="modal" data-bs-target="#RecepitVoucherModal" style="font-size:1vw;" class="btn btn-outline-primary w-25 px-0 py-2 m-1 rounded-2" onclick = "RecepitVoucherModal(' + j.contractnumber + ',' + j.totalPrice + ')"> سند قبض </button>';
                flatDiv += '<a type="button"     class="btn btn-outline-primary w-25 px-0 py-2 m-1 rounded-2"  style="font-size:0.9vw;" target="_blank"  href = "/Vouchers/Services/?contract=' + j.contractnumber + '"> خدمات </a>';
                flatDiv += '<a type="button"     class="btn btn-outline-primary w-25 px-0 py-2 m-1 rounded-2" style="font-size:1vw;" target="_blank" href = "/Reports/PrintContractInvoice" > مغادره </a>';

            }
            else if ((j.status == 'مشغوله' && j.contractDuration != 0) || (j.status == 'Reserved' && j.contractDuration != 0)) {
                flatDiv += '<button type="button" data-bs-toggle="modal" data-bs-target="#RecepitVoucherModal" style="font-size:0.9vw;" class="btn btn-outline-primary w-25 px-0 py-2 m-1 rounded-2" onclick = "RecepitVoucherModal(' + j.contractnumber + ',' + j.totalPrice + ')"> Recepit Voucher</button>';
                flatDiv += '<a type="button"     class="btn btn-outline-primary w-25 px-0 py-2 m-1 rounded-2"  style="font-size:0.9vw;" target="_blank"  href = "/Vouchers/Services/?contract=' + j.contractnumber +'"> Services </a>';
                flatDiv += '<a type="button"     class="btn btn-outline-primary w-25 px-0 py-2 m-1 rounded-2"  style="font-size:0.9vw;" target="_blank"  href = "/Reports/PrintContractInvoice/?contractnumber=' + j.contractnumber +'"> Leave </a>';
            }            
            flatDiv += '</div>';
            // ************ End card Data ************

            // ************  buttons back ************

            flatDiv += '<div class="modal-footer border-0 justify-content-center mt-4">';
            flatDiv += ' <button type="button" class="btn bg-white shadow-none text-gray flipundo" data-bs-dismiss="modal"><i class="fa-solid fa-right-from-bracket me-sm-1"></i></button>';

            if ((j.status == 'مشغوله' && j.contractDuration != 0 ) || (j.status == 'Reserved' && j.contractDuration != 0 )) {
                //nor
                flatDiv += '<button type="button"    class="card-link btn text-center w-30 mx-2 mx-2 edit"  data-bs-toggle="modal" data-bs-target="#EditcontractModal" onclick = "EditFormAllContracts(' + j.contractnumber + ')"> <i class="fa-solid fa-pen"></i></button>';
                flatDiv += '<a  class="card-link btn text-center mx-2 w-30"><i class="fa-solid fa-print"></i></a>';

            }
            //flatDiv += '<button type="submit" class="btn bg-gradient-primary text-white flipundo">Save</button>';
            flatDiv += '</div>';
            flatDiv += ' </div>';
            // ************ End buttons back ************
            flatDiv += '</form>';

            flatDiv += '</div>';

        });
        $('#FlatsContainer').html(flatDiv);

    });
           
}
 
function EditFormRoomscheme(id) {
    $.ajax({
        type: "POST",
        url: "/Settings/GetRoom",
        data: { id: id },
        success: function (Room) {
            //console.log(Room);

            $("#roomNo").val(Room.roomNo);
            $("#floorNo").val(Room.floorNo);
            $("#id").val(Room.id)
            $("#normalPrice").val(Room.normalPrice)
            $("#minPrice").val(Room.minPrice);
            $("#singleBedNo").val(Room.singleBedNo);
            $("#doubleBedNo").val(Room.doubleBedNo);
            $("#wcNo").val(Room.wcNo);
             $("#roomTypeId").val(Room.roomTypeId);
            $("#roomStatusId").val(Room.roomStatusId);


        }
    })


}
 
function clearformRoomscheme() {
    $("#id").val(0);
    $("#roomNo").val("");
    $("#floorNo").val("");
    $("#normalPrice").val("");
    $("#minPrice").val("");
    $("#singleBedNo").val("");
    $("#doubleBedNo").val("");
    $("#wcNo").val("");
     
    $("#roomTypeId").val("");
    $("#roomStatusId").val("");
}

function cardback() {
    const buttons = document.querySelectorAll('.info');

    // Loop through each button and add a click event listener
    buttons.forEach(button => {
        button.addEventListener('click', function () {
            // Find the parent card of the clicked button
            const card = this.closest('.cardbody');

            // Add the desired class to the card
            card.classList.add('flippedcard');
        });
    });

    const flipback = document.querySelectorAll('.flipundo');

    // Loop through each button and add a click event listener
    flipback.forEach(button => {
        button.addEventListener('click', function () {
            // Find the parent card of the clicked button
            const card = this.closest('.cardbody');

            // Add the desired class to the card
            card.classList.remove('flippedcard');
        });
    });

    var win = navigator.platform.indexOf('Win') > -1;
    if (win && document.querySelector('#sidenav-scrollbar')) {
        var options = {
            damping: '0.5'
        }
        Scrollbar.init(document.querySelector('#sidenav-scrollbar'), options);
    }


}


$('#updatecontract').click(function () {
    var jsonData = {
        HotelId: $("#hotelId").val(),
        RoomId: $("#roomNum").val(),
        PurposeVisitId: $("#purposeVisitId").val(),

        CheckInTime: $("#checkInTime").val(),
        CheckOut: $("#checkOut").val(),
        UnitPrice: $("#unitPrice").val(),
        CountofPerson: $("#countofPerson").val(),
        Duration: $("#duration").val(),
        TotalVat: $("#totalVat").val(),
        NetPrice: $("#netPrice").val(),
        TotalPrice: $("#totalPrice").val(),

        Id: $("#contractid").val(),
         
    }
    $.post("/Vouchers/UpdateContract", jsonData, function (res) {


        if (culture == "ar-SA") {
            alert("تم حفط البيانات بنجاح ");
            
        }
        else {
            alert("This action has been saved !");
            
        }

        $("#EditcontractModal").modal("toggle");
        location.reload();
    });
});


// ************************************* RoomStatus View *************************************

function EditFormRoomStatus(id) {
    $.ajax({
        type: "POST",
        url: "/Settings/GetRoomStatus",
        data: { id: id },
        success: function (RoomStatus) {
            //console.log(RoomStatus);

            $("#namear").val(RoomStatus.nameAr);
            $("#nameen").val(RoomStatus.nameEn);

            $("#id").val(RoomStatus.id)
        }
    })


}


function DeleteFormRoomStatus(id) {
    $.ajax({
        type: "POST",
        url: "/Settings/GetRoomStatus",
        data: { id: id },
        success: function (RoomStatusd) {
            //console.log(RoomStatusd);
            $("#nameArd").val(RoomStatusd.nameAr);
            $("#nameEnd").val(RoomStatusd.nameEn);
            $("#idd").val(RoomStatusd.id)
        }
    })


}

function clearformRoomStatus() {
    $("#id").val(0);
    $("#namear").val("");
    $("#nameen").val("");
}
 
// ************************************* RoomType View *************************************

function EditFormRoomType(id) {
    $.ajax({
        type: "POST",
        url: "/Settings/GetRoomType",
        data: { id: id },
        success: function (RoomType) {
            //console.log(RoomType);

            $("#namear").val(RoomType.nameAr);
            $("#nameen").val(RoomType.nameEn);

            $("#id").val(RoomType.id)
        }
    })
}

function DeleteFormRoomType(id) {
    $.ajax({
        type: "POST",
        url: "/Settings/GetRoomType",
        data: { id: id },
        success: function (RoomTyped) {
            //console.log(RoomTyped);
            $("#nameArd").val(RoomTyped.nameAr);
            $("#nameEnd").val(RoomTyped.nameEn);
            $("#idd").val(RoomTyped.id)
        }
    })


}

function clearformRoomType() {
    $("#id").val(0);
    $("#namear").val("");
    $("#nameen").val("");
}

// ************************************* Store View *************************************

function GetAllStoreInHotel() {


    var ss = "";
    $.get("/Settings/GetAllStoreInHotel", function (data) {
        $.each(data, function (i, j) {
            ss = ss + "<tr>";
            ss = ss + "<td class='align-middle text-center text-sm'>" + (i + 1) + "</td>";
            ss = ss + "<td class='align-middle text-center text-sm'>" + j.storename + "</td>";
            ss = ss + "<td class='align-middle text-center text-sm'><button id='EditForm' data-bs-toggle='modal' data-bs-target='#EditModal'  class='card-link btn text-center w-30 mx-2 mx-2 edit'  onclick = 'EditFormStore(" + j.id + ")' > <i class='fa-solid fa-pen' aria-hidden='true'></i></button></td>";

            ss = ss + "<td class='float-end me-4'><button  data-bs-toggle='modal' data-bs-target='#DeleteModal' class='btn btn-link text-danger text-gradient px-3 mb-0'  onclick='DeleteFormStore(" + j.id + ")'><i class='fa-regular fa-trash-can me-2' aria-hidden='true'></i></button></td>";

            ss = ss + "</tr>";
        });
        $("#tbodyStore").html(ss);
    });

}

function EditFormStore(id) {
    $.ajax({
        type: "POST",
        url: "/Settings/GetStore",
        data: { id: id },
        success: function (Employee) {
            //console.log(Employee);

            $("#nameAr").val(Employee.nameAr);
            $("#nameEn").val(Employee.nameEn);
            $("#id").val(Employee.id)
         }
    })


}

function DeleteFormStore(id) {
    $.ajax({
        type: "POST",
        url: "/Settings/GetStore",
        data: { id: id },
        success: function (Employeed) {
            //console.log(Employeed);

            $("#nameArd").val(Employeed.nameAr);
            $("#nameEnd").val(Employeed.nameEn);
            $("#idd").val(Employeed.id)

         }
    })


}

function clearformStore() {
    $("#id").val(0);
    $("#namear").val("");
    $("#nameen").val("");
}
 


// ************************************* Store Asset View *************************************
function SelectAllStoreInHotel() { 
   
    if (culture == "ar-SA") {
        var ss = "<option value=0>  المخازن </option>";
    }
    else {
        var ss = "<option value=0>select Store  </option>";    }
    $.get("/Settings/GetAllStoreInHotel", function (data) {
        $.each(data, function (i, j) {
            ss = ss + "<option value=" + j.id + ">" + j.storename + "</option>";
        });
        $("#storeid").html(ss);
        $("#storeId").html(ss);
        $("#storeIdd").html(ss);

    });

}


function GetAllAssetInStore() {

    var id = $("#storeid").val();
    if (id > 0) {
        var ss = "";
        $.get("/Settings/GetAllAssetInStore/" + id, function (data) {
            $.each(data, function (i, j) {
                ss = ss + "<tr>";
                ss = ss + "<td class='align-middle text-center text-sm'>" + (i + 1) + "</td>";
                ss = ss + "<td class='align-middle text-center text-sm'>" + j.assetName + "</td>";
                ss = ss + "<td class='align-middle text-center text-sm'>" + j.assetStatus + "</td>";
                ss = ss + "<td class='align-middle text-center text-sm'>" + j.intailQty + "</td>";
                ss = ss + "<td class='align-middle text-center text-sm'>" + j.currentQty + "</td>";

                ss = ss + "<td class='align-middle text-center text-sm'><button id='EditForm' data-bs-toggle='modal' data-bs-target='#EditModal'  class='card-link btn text-center w-30 mx-2 mx-2 edit'  onclick = 'EditFormStoreAsset(" + j.id + ")' > <i class='fa-solid fa-pen' aria-hidden='true'></i></button></td>";

                ss = ss + "<td class='float-end me-4'><button  data-bs-toggle='modal' data-bs-target='#DeleteModal' class='btn btn-link text-danger text-gradient px-3 mb-0'  onclick='DeleteFormStoreAsset(" + j.id + ")'><i class='fa-regular fa-trash-can me-2' aria-hidden='true'></i></button></td>";

                ss = ss + "</tr>";

            });
            $("#tbodyStoreAsset").html(ss);
        });
    }
}

function EditFormStoreAsset(id) {
    $.ajax({
        type: "POST",
        url: "/Settings/GetStoreAsset",
        data: { id: id },
        success: function (StoreAsset) {
            //console.log(StoreAsset);
            $("#id").val(StoreAsset.id);
            $("#intailQty").val(StoreAsset.intailQty);
            $("#currentQty").val(StoreAsset.currentQty);

            $("#storeId").val(StoreAsset.storeId);
            $("#assetId").val(StoreAsset.assetId);
            $("#assetStatusTypeId").val(StoreAsset.assetStatusTypeId);


        }
    })


}

function DeleteFormStoreAsset(id) {
    $.ajax({
        type: "POST",
        url: "/Settings/GetStoreAsset",
        data: { id: id },
        success: function (StoreAssetd) {
            //console.log(StoreAssetd);
            $("#idd").val(StoreAssetd.id);
            $("#intailQtyd").val(StoreAssetd.intailQty);
            $("#currentQtyd").val(StoreAssetd.currentQty);

            $("#storeIdd").val(StoreAssetd.storeId);
            $("#assetIdd").val(StoreAssetd.assetId);
            $("#assetStatusTypeIdd").val(StoreAssetd.assetStatusTypeId);


        }

    })


}

function clearformStoreAsset() {
    $("#id").val(0);
    $("#intailQty").val("");
    $("#currentQty").val("");
    $("#storeId").val("");
    $("#assetId").val("");
    $("#assetStatusTypeId").val("");



}


// *************************************  Store Responsable View *************************************

function SelectAllEmployeeInHotel() {
     
    if (culture == "ar-SA") {
        var ss = "<option value=0>  الموظفين </option>";
    }
    else {
        var ss = "<option value=0>select Employee Name </option>";

    }


    $.get("/Settings/GetAllEmployeeInHotel", function (data) {
        $.each(data, function (i, j) {
            ss = ss + "<option value=" + j.id + ">" + j.name + "</option>";
             
        });
        $("#employeeid").html(ss);
        $("#employeeId").html(ss);
        $("#employeeIdd").html(ss);


    });

}


function GetAllStoreResponsable() {

    var id = $("#employeeid").val();
    if (id > 0) {
        var ss = "";
        $.get("/Settings/GetAllStoreResponsable/" + id, function (data) {
            $.each(data, function (i, j) {
                ss = ss + "<tr>";
                ss = ss + "<td class='align-middle text-center text-sm'>" + (i + 1) + "</td>";
                ss = ss + "<td class='align-middle text-center text-sm'>" + j.employeename + "</td>";

                ss = ss + "<td class='align-middle text-center text-sm'>" + j.storename + "</td>";
                ss = ss + "<td class='align-middle text-center text-sm'>" + j.startDate + "</td>";
                ss = ss + "<td class='align-middle text-center text-sm'>" + j.endDate + "</td>";
                ss = ss + "<td class='align-middle text-center text-sm'><button   id='EditStoreResponsableForm'    data-bs-toggle='modal' data-bs-target='#EditModal'    class='card-link btn text-center w-30 mx-2 mx-2 edit' onclick='EditStoreResponsableForm(" + j.id + ")'><i class='fa-solid fa-pen' aria-hidden='true'></i></button></td>";
                ss = ss + "<td class='float-end me-4'><button   id='DeleteStoreResponsableForm'  data-bs-toggle='modal' data-bs-target='#DeleteModal'  class='btn btn-link text-danger text-gradient px-3 mb-0' onclick='DeleteStoreResponsableForm(" + j.id + ")'><i class='fa-regular fa-trash-can me-2' aria-hidden='true'></i></button></td>";
                ss = ss + "</tr>";

            });
            $("#tbodyStoreResponsable").html(ss);
        });
    }
}


function EditStoreResponsableForm(id) {
    $.ajax({
        type: "POST",
        url: "/Settings/GetStoreResponsable",
        data: { id: id },
        success: function (StoreResponsable) {
            //console.log(StoreResponsable);
            $("#id").val(StoreResponsable.id);
            $("#startDate").val(StoreResponsable.startDate);
            $("#endDate").val(StoreResponsable.endDate);
            $("#storeId").val(StoreResponsable.storeId);
            $("#employeeId").val(StoreResponsable.employeeId);
        }
    })
}

function DeleteStoreResponsableForm(id) {
    $.ajax({
        type: "POST",
        url: "/Settings/GetStoreResponsable",
        data: { id: id },
        success: function (StoreResponsabled) {
            //console.log(StoreResponsabled);
            $("#idd").val(StoreResponsabled.id);
            $("#startDated").val(StoreResponsabled.startDate);
            $("#endDated").val(StoreResponsabled.endDate);
            $("#storeIdd").val(StoreResponsabled.storeId);
            $("#employeeIdd").val(StoreResponsabled.employeeId);
        }
    })
}

function clearStoreResponsableform() {
    $("#id").val(0);
    $("#startDate").val("");
    $("#endDate").val("");
    $("#storeId").val("");
    $("#employeeId").val("");
}


// ************************************* Services View nnn *************************************

//function SelectAllAssetInStore() {
//    var flatDiv = '';
//    var id = $("#storeid").val();
//    if (id > 0) {
//        var ss = "<option value=0>select Product</option>";
//        $.get("/Settings/GetAllAssetInStore/" + id, function (data) {
//            console.log(data)
//            $.each(data, function (i, j) {
//                if (j.assetStatus == "جيده" || j.assetStatus == "good" ) {
//                    ss = ss + "<option value=" + j.assetId + ">" + j.assetName + "</option>";
//                }
//            });
//            $("#productid").html(ss);
//        });
//    }
//}

function SelectAllAssetInStore() {
    var flatDiv = '';
    var id = $("#storeid").val();
    $("#servicesStoreId").val(id);
    if (id > 0) {
       
        $.get("/Settings/GetAllAssetInStore/" + id, function (data) {
            console.log(data)
            $.each(data, function (i, j) {
                if (j.assetStatus == "جيده" || j.assetStatus == "good") {
                    flatDiv += '<div class="card w-80 w-md-40 w-lg-30 w-sm-80 mx-2 mb-4 bg-transparent shadow-none free" style="background-color:darkgray">';
                    flatDiv += '<form class="cardbody" action="">';
                    // ************ card-body front ************

                    flatDiv += '<div class="card-body front"> ';

                    // ************ card Data ************

                    flatDiv += '<h6 class="card-title mb-1">' + j.assetName + '</h6>';
                    flatDiv += '<h6 class="card-title mb-1" style="font-size:0.9vw;color:black"> ' + j.currentQty + '</h6>';
                    flatDiv += '<h6 class="card-title mb-1" style="font-size:0.9vw;color:black"> ' + j.price + '$ </h6>';
                    flatDiv += '<div class="square bg-light rounded my-4"></div>';

                    // ************ End card Data ************

                    // ************ buttons front ************

                    flatDiv += '<div class="col d-flex flex-row justify-content-center align-items-center"> ';
                    flatDiv += '<a class="card-link btn text-center mx-2 w-30" onclick="GetAllAssetInfo('+j.assetId+')"  > <i class="fa-solid fa-shopping-cart text-Re fs-6 pb-1"></i></a>';

                   
                    flatDiv += '</div>';
                    flatDiv += '</div>';

        // ************ End buttons front ************
                    flatDiv += '</form>';

                    flatDiv += '</div>';

                }
            });
            $('#productid').html(flatDiv);
        });
    }
}
  
function GetAllAssetInfo(id) {

    /* var id = $("#productid").val();*/
    if (id > 0) {
        var ss = "";
        var totalid = "product";
        var qty = "qty";
        //console.log(id);
        $.get("/Settings/GetAllAssetInfo/" + id, function (data) {
            console.log(data);
             
            $.each(data, function (i, j) {
                totalid = totalid + j.id;
                qty = qty + j.id;


                console.log(i + 1);
                ss = ss + "<tr>";
                ss = ss + "<td class='align-middle text-center text-sm'>" + (i + 1) + "</td>";
                ss = ss + "<td  class='align-middle text-center text-sm'>" + j.assetName + "</td>";
                
                ss = ss + "<td style='display:none'> <input   class='UnitPrice form-control' id='unitPrice' value='" + j.price + "'  ></td>";
                ss = ss + "<td> <input  type='number' class='Qty form-control' id='" + qty + "' onChange='calctotalProductValue(" + j.id + "," + j.price + ")'> </td>";

                ss = ss + "<td> <input   class='totalPrice form-control' value='0.00'  id = '" + totalid + "'  disabled='disabled' > </td>";
                ss = ss + "<td>  <button class='btn btn-link text-danger text-gradient px-3 mb-0' onClick='RemoveItems(this)'> <i class='fa-regular fa-trash-can me-2' aria-hidden='true'></i></button> </td>";
                ss = ss + "<td style='display:none'> <input   class='assetId form-control' id='unitPrice' value='" + j.assetId + "'  ></td>";

                ss = ss + "</tr>";
               /* $("#servicesAssetId").val(j.assetId);*/
                $("#servicesunitPrice").val(j.price);

            });
            $("#tbodyPurchases").append(ss);
            
        });
    }
}

function calctotalProductValue(id, unitPrice) {
    //**** calc total Product Value ****
    var productId = "product" + id;
    var productQty = "qty" +id;
    var qty = $("#" + productQty).val();
    var rentprice = unitPrice  //price
    var totalValue = Number(rentprice) * Number(qty);
    $("#" + productId).val(totalValue);


    //**** calc All Services Value ****
    var cell = document.getElementsByClassName("totalPrice");
    
    var val = 0;
    var i = 0;
    console.log("my cell");
    console.log(cell);
   
    while (cell[i] != undefined) {
        val += parseFloat(cell[i].value);
        i++;
       
    } //end while
    document.getElementById("invoiceNetPrice").value = parseFloat(val).toFixed(2);


    var netPriceValue = parseFloat(val).toFixed(2);


    $("#servicesQty").val(qty);
    $("#servicesTotalPrice").val(netPriceValue);

    var totalVat = $("#invoicevat").val();
    totalVat = totalVat / 100;

    var totalpriceValue = Number(netPriceValue) + (Number(totalVat) * Number(netPriceValue));
    //$("#contractTotalPrice").val(totalpriceValue);
    //console.log($("#contractTotalPrice").val());
    document.getElementById("totalValueWithTaxes").value = parseFloat(totalpriceValue).toFixed(2);

   
   

}

function calctotalServicesValue() {
    
    var cell = document.getElementsByClassName("totalPrice");
    console.log(cell);
    var val = 0;
    var i = 0;
    while (cell[i] != undefined) {
        val += parseFloat(cell[i].value);
        i++;
        console.log(val);
    } //end while
    document.getElementById("invoiceNetPrice").value = parseFloat(val).toFixed(2);

    var netPriceValue = parseFloat(val).toFixed(2);

    var totalVat = $("#invoicevat").val();
    totalVat = totalVat / 100;

    var totalpriceValue = Number(netPriceValue) + (Number(totalVat) * Number(netPriceValue));
    //$("#contractTotalPrice").val(totalpriceValue);
    //console.log($("#contractTotalPrice").val());
    document.getElementById("totalValueWithTaxes").value = parseFloat(totalpriceValue).toFixed(2);



}

function RemoveItems(deleteButton) {
    let row = deleteButton.parentElement.parentElement;
    row.parentNode.removeChild(row);
    calctotalServicesValue();
    calcallPurchasesValue();
}

function GetAllTaxTypeForinvoice() {
    s = 0;
    $.get("/Settings/GetAllTaxTypeForinvoice", function (data) {
        $.each(data, function (i, j) {
            s += parseFloat(j.value)
        });
        console.log(s);
        $("#invoicevat").val(s);
    });

   }    


$('#insertServiceItems').click(function () {
   

    var jsonData = {
        HotelId: $("#Sessionhotelid").val(),//sssss
        CustomerId: $("#customerIdincontract").val(),
        ContractId: $("#contractId").val(),
        PaymentTypeId: $("#paymentTypeId").val(),
        StoreId: $("#servicesStoreId").val(),

        Date: $("#date").val(),
        Vat: $("#invoicevat").val(),
        NetPrice: $("#invoiceNetPrice").val(),
        Total: $("#totalValueWithTaxes").val(),
        StoreId: $("#servicesStoreId").val(),
        
        Id: $("#id").val(),

    }
    //console.log(jsonData.NetPrice);
    //console.log(Total);
    // Loop through Qty elements
    jsonData.Qty = [];
    var qtyElements = document.getElementsByClassName("Qty");
    for (var i = 0; i < qtyElements.length; i++) {
        jsonData.Qty.push(qtyElements[i].value);
    }

    // Loop through UnitPrice elements
    jsonData.UnitPrice = [];
    var unitPriceElements = document.getElementsByClassName("UnitPrice");
    for (var i = 0; i < unitPriceElements.length; i++) {
        jsonData.UnitPrice.push(unitPriceElements[i].value);
    }

    // Loop through TotalPrice elements
    jsonData.TotalPrice = [];
    var totalPriceElements = document.getElementsByClassName("totalPrice");
    for (var i = 0; i < totalPriceElements.length; i++) {
        jsonData.TotalPrice.push(totalPriceElements[i].value);
    }

    // Loop through AssetId elements
    jsonData.AssetId = [];
    var assetIdElements = document.getElementsByClassName("assetId");
    for (var i = 0; i < assetIdElements.length; i++) {
        jsonData.AssetId.push(assetIdElements[i].value);
    }

    console.log(jsonData)
    var contractid = $("#contractId").val();
    $.post("/Vouchers/UpdateService", jsonData, function (res) {

        console.log("Success:", res);
        window.location.assign("/Vouchers/Services/?" + "contract=" + contractid );
        
    })
        .fail(function (jqXHR, textStatus, errorThrown) {
            // Error callback
            console.error("Error:", textStatus, errorThrown); 
    });
});



// ************************************* TaxType View *************************************

function GetAllTaxTypeInHotel() {

    
        var ss = "";
        $.get("/Settings/GetAllTaxTypeInHotel", function (data) {
            //console.log(data)
            $.each(data, function (i, j) {
                ss = ss + "<tr>";
                ss = ss + "<td class='align-middle text-center text-sm'>" + (i + 1) + "</td>";
                ss = ss + "<td class='align-middle text-center text-sm'>" + j.name  + "</td>";
                 ss = ss + "<td class='align-middle text-center text-sm'>" + j.value + "</td>";
                ss = ss + "<td class='align-middle text-center text-sm'>" + j.isFixed + "</td>";
                ss = ss + "<td class='align-middle text-center text-sm'>" + j.contractOnly + "</td>";
                ss = ss + "<td class='align-middle text-center text-sm'><button   id='EditForm'    data-bs-toggle='modal' data-bs-target='#EditModal'    class='card-link btn text-center w-30 mx-2 mx-2 edit' onclick='EditFormTaxType(" + j.id + ")'><i class='fa-solid fa-pen' aria-hidden='true'></i></button></td>";
                ss = ss + "<td class='float-end me-4'><button   id='DeleteForm'  data-bs-toggle='modal' data-bs-target='#DeleteModal'  class='btn btn-link text-danger text-gradient px-3 mb-0' onclick='DeleteFormTaxType(" + j.id + ")'><i class='fa-regular fa-trash-can me-2' aria-hidden='true'></i></button></td>";

                ss = ss + "</tr>";

            });
            $("#tbodyTaxType").html(ss);
        });
    
}


function EditFormTaxType(id) {
    $.ajax({
        type: "POST",
        url: "/Settings/GetTaxType",
        data: { id: id },
        success: function (TaxType) {
            //console.log(TaxType);

            $("#nameAr").val(TaxType.nameAr);
            $("#nameEn").val(TaxType.nameEn);
            $("#id").val(TaxType.id);
            $("#value").val(TaxType.value);
            //$("#ContractOnly").val(TaxType.contractOnly);
            $("#hotelId").val(TaxType.hotelId);

        }
    })


}


function DeleteFormTaxType(id) {
    $.ajax({
        type: "POST",
        url: "/Settings/GetTaxType",
        data: { id: id },
        success: function (TaxTyped) {
            //console.log(TaxTyped);

            $("#nameArd").val(TaxTyped.nameAr);
            $("#nameEnd").val(TaxTyped.nameEn);
            $("#idd").val(TaxTyped.id);
            $("#valued").val(TaxTyped.value);
            $("#hotelIdd").val(TaxTyped.hotelId);
        }
    })


}

function clearformTaxType() {
    $("#id").val(0);
    $("#nameAr").val("");
    $("#nameEn").val("");
    $("#value").val("");
    $("#contractOnly").val("");
    $("#hotelId").val("");
}


// ************************************* UnitType View *************************************

function EditFormUnitType(id) {
    $.ajax({
        type: "POST",
        url: "/Settings/GetUnitType",
        data: { id: id },
        success: function (UnitType) {
            //console.log(UnitType);

            $("#namear").val(UnitType.nameAr);
            $("#nameen").val(UnitType.nameEn);

            $("#id").val(UnitType.id)
        }
    })


}

function DeleteFormUnitType(id) {
    $.ajax({
        type: "POST",
        url: "/Settings/GetUnitType",
        data: { id: id },
        success: function (UnitTyped) {
            //console.log(UnitTyped);
            $("#nameArd").val(UnitTyped.nameAr);
            $("#nameEnd").val(UnitTyped.nameEn);
            $("#idd").val(UnitTyped.id)
        }
    })


}

function clearformUnitType() {
    $("#id").val(0);
    $("#namear").val("");
    $("#nameen").val("");
}


// ************************************* Vendor view *************************************


function GetVendor() {

    var ss = "";
    $.get("/Settings/GetAllVendorInHotel", function (data) {
        $.each(data, function (i, j) {
            ss = ss + "<tr>";
            ss = ss + "<td class='align-middle text-center text-sm'>" + (i + 1) + "</td>";
            ss = ss + "<td class='align-middle text-center text-sm'>" + j.vendorname + "</td>";
            ss = ss + "<td class='align-middle text-center text-sm'>" + j.vatNo + "</td>";
            ss = ss + "<td class='align-middle text-center text-sm'>" + j.responsableName + "</td>";
            ss = ss + "<td class='align-middle text-center text-sm'>" + j.vendorAddress + "</td>";
            ss = ss + "<td class='align-middle text-center text-sm'><button   id='EditForm'    data-bs-toggle='modal' data-bs-target='#EditModal'    class='card-link btn text-center w-30 mx-2 mx-2 edit' onclick='EditFormVendor(" + j.id + ")'><i class='fa-solid fa-pen' aria-hidden='true'></i></button></td>";
            ss = ss + "<td class='float-end me-4'><button   id='DeleteForm'  data-bs-toggle='modal' data-bs-target='#DeleteModal'  class='btn btn-link text-danger text-gradient px-3 mb-0' onclick='DeleteFormVendor(" + j.id + ")'><i class='fa-regular fa-trash-can me-2' aria-hidden='true'></i></button></td>";
            ss = ss + "<td class='align-middle text-center text-sm' ><button   id='contactForm' data-bs-toggle='modal' data-bs-target='#contactModal'    class='card-link btn text-center w-30 mx-2 mx-2' onclick='GetVendorcontacts(" + j.id + ")'><i class='fa-solid fa-plus text-success'></i></button></td>";


            ss = ss + "</tr>";
            //$("#vendorid").val(j.id);
        });
        $("#tbodyvendor").html(ss);
    });

}

function EditFormVendor(id) {
    $.ajax({
        type: "POST",
        url: "/Settings/GetVendor",
        data: { id: id },
        success: function (Vendor) {
            //console.log(Vendor);

            $("#namear").val(Vendor.nameAr);
            $("#nameen").val(Vendor.nameEn);
            $("#vatNo").val(Vendor.vatNo);
            $("#addressAr").val(Vendor.addressAr);
            $("#addressEn").val(Vendor.addressEn);
            $("#responsableName").val(Vendor.responsableName);
            $("#countryId").val(Vendor.cityId); 
            $("#id").val(Vendor.id)
        }
    })


}

function DeleteFormVendor(id) {
    $.ajax({
        type: "POST",
        url: "/Settings/GetVendor",
        data: { id: id },
        success: function (Vendord) {
            //console.log(Vendord);

            $("#nameard").val(Vendord.nameAr);
            $("#nameend").val(Vendord.nameEn);
            $("#vatNod").val(Vendord.vatNo);
            $("#addressArd").val(Vendord.addressAr);
            $("#addressEnd").val(Vendord.addressEn);
            $("#responsableNamed").val(Vendord.responsableName);
            
            $("#idd").val(Vendord.id)
        }
    })


}

function GetVendorcontacts(id) {
    $("#vendorid").val(id);
    var id = $("#vendorid").val();
    //console.log(id);
    //console.log(id);
    if (id > 0) {
        var ss = "";
        $.get("/Settings/GetAllVendorrcontact/" + id, function (data) {
            //console.log(data);
            $.each(data, function (i, j) {
                ss = ss + "<tr>";
                ss = ss + "<td class='align-middle text-center text-sm'>" + (i + 1) + "</td>";
                ss = ss + "<td class='align-middle text-center text-sm'>" + j.contacttypenam + "</td>";
                ss = ss + "<td class='align-middle text-center text-sm'>" + j.contactvalue + "</td>";
                ss = ss + "<td class='align-middle text-center text-sm'>" + j.contactdescription + "</td>";

                ss = ss + "</tr>";
                //$("#customerid").val(j.id);
            });

            $("#Vendorcontactbody").html(ss);
        });
    }
}

$('#saveVendorContact').click(function () {
    var jsonData = {

        Value: $("#value").val(),
        Description: $("#description").val(),
        ContactTypeId: $("#contactTypeId").val(),
        VendorId: $("#vendorid").val(),
        Id: $("#contactid").val(),

    }
    $.post("/Settings/UpdateVendorContact", jsonData, function (res) {

        if (culture == "ar-SA") {
            alert("تم حفط البيانات بنجاح ");
        }
        else { alert("This action has been saved !"); }


    });


});

function clearformVendor() {
    $("#id").val(0);
    $("#namear").val("");
    $("#nameen").val("");
    $("#vatNo").val("");
    $("#addressAr").val("");
    $("#addressEn").val("");
    $("#responsableName").val("");
    $("#cityId").val("");
    $("#hotelId").val("");
}


function clearVendorcontactmodal() {

    $("#value").val("");
    $("#description").val("");
    $("#contactTypeId").val(0);
    $("#vendorid").val(0);
    $("#contactid").val(0);

}

// *************************************  Purchases *************************************
  
function GetVendorByName() {

    var name = $("#vendorNameid").val();
     
    if (name != null) {

        var ss = "";
        $.get("/Settings/GetVendorByName/?" + "name=" + name , function (data) {
            if (data != false) {
                console.log(data);
                ss += '<br />';
                var nameValue = data[0]?.name ?? 'N/A';
                var vatNoValue = data[0]?.vatNo ?? 'N/A';
                var vendorid = data[0]?.id ?? 'N/A';
                if (culture == "ar-SA") { 
                    ss += `<h2 class="form-control"> <label> اسم المورد : </label> ${nameValue} </h2>`;
 
                }
                else { 
                    ss += `<h2 class="form-control"> <label> Vendor Name : </label> ${nameValue} </h2>`;
                     
                }
                $("#purchasesVendorid").val(vendorid);
                console.log(vendorid);
            }
            else {
                $("#EditModal").modal("show");
                ss = "";
            }
            //$.alert($("#customerIdincontract").val());
            $("#tbodySearchVendor").html(ss);
        });
    }
}



$('#addNewVendor').click(function () {
   
    var jsonData = {
        NameAr: $("#namear").val(),
        NameEn: $("#nameen").val(),
        AddressAr: $("#addressAr").val(),
        AddressEn: $("#addressEn").val(),
        VatNo: $("#vatNo").val(),
        HotelId: $("#vendorhotelId").val(),
        CityId: $("#countryId").val(),
        ResponsableName: $("#responsableName").val(),
        Id: $("#newVendorid").val(),
    }
    console.log(jsonData);
    $.post("/Settings/UpdateVendor", jsonData, function (res) {

        if (culture == "ar-SA") {
            alert("تم حفط البيانات بنجاح ");
            var id = $("#namear").val();
            $("#namear").val(id);
        }
        else { alert("This action has been saved !");
            var id = $("#nameen").val();
            $("#nameen").val(id);
} 

        GetVendorByName();
        $("#EditModal").modal("toggle");

    });


}); 

function SelectAllProductByAssetType() {
    var flatDiv = '';
    var id = $("#assetTypeId").val();
    
    if (id > 0) {
        $.get("/Settings/GetAllAssetByAssetType/" + id, function (data) {
           /* console.log(data)*/
            $.each(data, function (i, j) {
                 
                    flatDiv += '<div class="card w-80 w-md-40 w-lg-30 w-sm-80 mx-2 mb-4 bg-transparent shadow-none free" style="background-color:darkgray">';
                    flatDiv += '<form class="cardbody" action="">';
                    // ************ card-body front ************

                    flatDiv += '<div class="card-body front"> ';

                    // ************ card Data ************

                    flatDiv += '<h6 class="card-title mb-1">' + j.assetName + '</h6>'; 
                    flatDiv += '<h6 class="card-title mb-1" style="font-size:0.9vw;color:black"> ' + j.price + '$ </h6>';
                    flatDiv += '<div class="square bg-light rounded my-4"></div>';

                    // ************ End card Data ************

                    // ************ buttons front ************

                    flatDiv += '<div class="col d-flex flex-row justify-content-center align-items-center"> ';
                flatDiv += '<a class="card-link btn text-center mx-2 w-30" onclick="GetAllPurchasesInfo(' + j.assetId + ')"  > <i class="fa-solid fa-shopping-cart text-Re fs-6 pb-1"></i></a>';


                    flatDiv += '</div>';
                    flatDiv += '</div>';

                    // ************ End buttons front ************
                    flatDiv += '</form>';

                    flatDiv += '</div>';

                
            });
            $('#productid').html(flatDiv);
        });
    }
}

function GetAllPurchasesInfo(id) {

    /* var id = $("#productid").val();*/
    if (id > 0) {
        var ss = "";
        var totalid = "product";
        var qty = "qty";
        //console.log(id);
        $.get("/Settings/GetAllAssetInfo/" + id, function (data) {
            console.log(data); 
            $.each(data, function (i, j) {
                totalid = totalid + j.id;
                qty = qty + j.id; 
                /*console.log(i + 1);*/
                ss = ss + "<tr>";
                ss = ss + "<td class='align-middle text-center text-sm'>" + (i + 1) + "</td>";
                ss = ss + "<td  class='align-middle text-center text-sm'>" + j.assetName + "</td>";

                ss = ss + "<td style='display:none'> <input   class='UnitPrice form-control' id='unitPrice' value='" + j.price + "'  ></td>";
                ss = ss + "<td> <input  type='number' class='Qty form-control' id='" + qty + "' onChange='calctotalPurchasesValue(" + j.id + "," + j.price + ")'> </td>";

                ss = ss + "<td> <input   class='totalPrice form-control' value='0.00'  id = '" + totalid + "'  disabled='disabled' > </td>";
                ss = ss + "<td>  <button class='btn btn-link text-danger text-gradient px-3 mb-0' onClick='RemoveItems(this)'> <i class='fa-regular fa-trash-can me-2' aria-hidden='true'></i></button> </td>";
                ss = ss + "<td style='display:none'> <input   class='assetId form-control' id='unitPrice' value='" + j.assetId + "'  ></td>";

                ss = ss + "</tr>";
                /* $("#servicesAssetId").val(j.assetId);*/
                //$("#servicesunitPrice").val(j.price);

            });
            $("#tbodyPurchases").append(ss);

        });
    }
}

function calctotalPurchasesValue(id, unitPrice) {
    //**** calc total Product Value ****
    var productId = "product" + id;
    var productQty = "qty" + id;
    var qty = $("#" + productQty).val();
    var rentprice = unitPrice  //price
    var totalValue = Number(rentprice) * Number(qty);
    $("#" + productId).val(totalValue);
    console.log(qty,  rentprice, totalValue);

    //**** calc All Services Value ****
    var cell = document.getElementsByClassName("totalPrice");

    var val = 0;
    var i = 0;
    console.log("my cell");
    console.log(cell);

    while (cell[i] != undefined) {
        val += parseFloat(cell[i].value);
        i++;

    } //end while
    document.getElementById("purchasNetPrice").value = parseFloat(val).toFixed(2);


    var netPriceValue = parseFloat(val).toFixed(2);


    $("#servicesQty").val(qty);
    $("#servicesTotalPrice").val(netPriceValue);

    var totalVat = $("#invoicevat").val();
    totalVat = totalVat / 100;

    var totalpriceValue = Number(netPriceValue) + (Number(totalVat) * Number(netPriceValue));
    //$("#contractTotalPrice").val(totalpriceValue);
    //console.log($("#contractTotalPrice").val());
    document.getElementById("purchastotalValueWithTaxes").value = parseFloat(totalpriceValue).toFixed(2);

}

function calcallPurchasesValue() {

    var cell = document.getElementsByClassName("totalPrice");
    console.log(cell);
    var val = 0;
    var i = 0;
    while (cell[i] != undefined) {
        val += parseFloat(cell[i].value);
        i++;
        console.log(val);
    } //end while
    document.getElementById("purchasNetPrice").value = parseFloat(val).toFixed(2);

    var netPriceValue = parseFloat(val).toFixed(2);

    var totalVat = $("#invoicevat").val();
    totalVat = totalVat / 100;

    var totalpriceValue = Number(netPriceValue) + (Number(totalVat) * Number(netPriceValue));
    //$("#contractTotalPrice").val(totalpriceValue);
    //console.log($("#contractTotalPrice").val());
    document.getElementById("purchastotalValueWithTaxes").value = parseFloat(totalpriceValue).toFixed(2);



} 
$('#insertPurchasesItems').click(function () {
     
    var jsonData = {
        HotelId: $("#Sessionhotelid").val(), 
        VendorId: $("#purchasesVendorid").val(), 
        PurchaseDate: $("#purchasesdate").val(), 
        Vat: $("#invoicevat").val(), 
        NetPrice: $("#purchasNetPrice").val(), 
        Total: $("#purchastotalValueWithTaxes").val(), 
        Id: $("#id").val(),  
    }
     
    // Loop through Qty elements
    jsonData.Quantity = [];
    var qtyElements = document.getElementsByClassName("Qty");
    for (var i = 0; i < qtyElements.length; i++) {
        jsonData.Quantity.push(qtyElements[i].value);
    }

    // Loop through UnitPrice elements
    jsonData.UnitPrice = [];
    var unitPriceElements = document.getElementsByClassName("UnitPrice");
    for (var i = 0; i < unitPriceElements.length; i++) {
        jsonData.UnitPrice.push(unitPriceElements[i].value);
    }

    // Loop through TotalPrice elements
    jsonData.TotalPrice = [];
    var totalPriceElements = document.getElementsByClassName("totalPrice");
    for (var i = 0; i < totalPriceElements.length; i++) {
        jsonData.TotalPrice.push(totalPriceElements[i].value);
    }

    // Loop through AssetId elements
    jsonData.AssetId = [];
    var assetIdElements = document.getElementsByClassName("assetId");
    for (var i = 0; i < assetIdElements.length; i++) {
        jsonData.AssetId.push(assetIdElements[i].value);
    }

    console.log(jsonData); 

    $.post("/Vouchers/UpdatePurchases", jsonData, function (res) {

        console.log("Success:", res.purchasesVoucherId);

        // Check if purchaseId is present in the response
        if (res.purchasesVoucherId !== undefined) {
            // Redirect to PrintPurchasesinvoice action with purchaseId
        //    window.location.href = "/Reports/PrintPurchasesinvoice/?purchaseId=" + res.purchasesVoucherId;
           
            window.open("/Reports/PrintPurchasesinvoice/?purchaseId=" + res.purchasesVoucherId, "_blank");
            location.reload();
        } else {
            console.error("purchaseId not found in the response.");
        }
        

    })
        
});


$('#insertNewProduct').click(function () {

    var jsonData = {
        HotelId: $("#Sessionhotelid").val(),
        NaturelofAsset: $("#naturelofAsset").val(),
        AssetTypeId: $("#assetTypeId").val(),
        SerialNo: $("#serialNo").val(),
        UnitTypeId: $("#unitTypeId").val(),
        NameAr: $("#productnamear").val(),
        NameEn: $("#productnameen").val(),
        Price: $("#price").val(),
        Decription: $("#decription").val(),
        Id: $("#newProductId").val(),
    }
    console.log(jsonData)
    $.post("/Settings/UpdateAsset", jsonData, function (res) {
        console.log(res)
        if (culture == "ar-SA") {
            alert("تم حفط البيانات بنجاح ");
        }
        else { alert("This action has been saved !"); }
    })
    $("#ProductModal").modal("toggle");
});




 
// *************************************  Contract view (Book a contract) *************************************

function SearchIdType() {
   
     
    if (culture == "ar-SA") {
        var ss = "<option value=0> ----اختر---- </option>";
    }
    else { var ss = "<option value=0> ----Select---- </option>"; }

    $.get("/Settings/GetAllIdType", function (data) {
        $.each(data, function (i, j) {
            ss = ss + "<option value=" + j.name + ">" + j.name + "</option>";
        });
        $("#idTypeSearch").html(ss);
    });
}


function Getcustomer() {

    var id = $("#customerid").val();
    var idType = $("#idTypeSearch").val();
    if (id > 0) {

        var ss = "";
        $.get("/Settings/GetCustomerbyId/?" + "id=" + id + "&idtype=" + idType, function (data) {
            if (data != false) {
                ss += '<br />';
                if (culture == "ar-SA") {
                    ss += '<h1> بيانات العميل </h1>';
                    ss += '<h2  class= "form-control"  > <label>الكود :  </label> ' + data.id + '</h2>';
                    ss += '<h2  class= "form-control"  > <label>اسم النزيل : </label> ' + data.firstName + ' ' + data.lastName + '</h2>';
                    ss += '<h2  class= "form-control"  > <label>الجنسية : </label> ' + data.countryName + '</h2>';
                    ss += '<h2  class= "form-control"  > <label>تابع لشركه؟   </label> ' + data.isCompony + '</h2>';
                    ss += '<h2  class= "form-control"  > <label>الفندق :  </label> ' + data.hotelname + '</h2>';

                }
                else {
                    ss += '<h1> Client info </h1>';
                    ss += '<h2  class= "form-control"  > <label>ID :  </label> ' + data.id + '</h2>';
                    ss += '<h2  class= "form-control"  > <label>Client : </label> ' + data.firstName + ' ' + data.lastName  + '</h2>';
                    ss += '<h2  class= "form-control"  > <label>Nationality : </label> ' + data.countryName + '</h2>';
                    ss += '<h2  class= "form-control"  > <label>Affiliated with the company ?  </label> ' + data.isCompony + '</h2>';
                    ss += '<h2  class= "form-control"  > <label>Hotel :  </label> ' + data.hotelname + '</h2>';


                } 
                $("#customerIdincontract").val(data.id);
            }
            else {
                $("#EditModal").modal("show");
                ss = "";
            }
            //$.alert($("#customerIdincontract").val());
            $("#tbodycustomercontract").html(ss);
        });
    }
}


$('#addnewcustomer').click(function () {
    var jsonData = {
        FirstName: $("#firstName").val(),
        LastName: $("#lastName").val(),
        IsShare: $("#isShare").val(),
        IsCompony: $("#isCompony").val(),
        IdValue: $("#idValue").val(),
        HotelId: $("#customerhotelId").val(),
        CountryId: $("#countryId").val(),
        IdTypeId: $("#idTypeId").val(),
        Id: $("#newcustomerid").val(),
    }
    $.post("/Settings/UpdateCustomer", jsonData, function (res) {

        if (culture == "ar-SA") {
            alert("تم حفط البيانات بنجاح ");
        }
        else { alert("This action has been saved !"); }

        var id = $("#idValue").val();
        var idType = $("#idTypeId option:selected").text();

        //alert(idType);
        $("#customerid").val(id);
        $("#idTypeSearch").val(idType);

        Getcustomer();
        $("#EditModal").modal("toggle");

    });


}); 

function calcContractDuration() {
    var date1 = $("#checkInTime").val()
    var date2 = $("#checkOut").val()

    date1 = date1.split('T')[0];
    date2 = date2.split('T')[0];

    date1 = new Date(date1);
    date2 = new Date(date2);
    var Difference_In_Time = date2.getTime() - date1.getTime();
    var days = Difference_In_Time / (1000 * 3600 * 24);
    //console.log(days);

    $("#contractDuration").val(days);
    $("#contractDuration").change();
    //console.log($("#duration").val());

}


$("#contractDuration").change(function () {
    calcConttractTotalPrice();
});
function calcConttractTotalPrice() {
     var IsHospitality = $("#IsHospitalityContract").is(":checked");
    if ($("#IsHospitalityContract").is(":checked")) {
        var rentprice = $("#unitPriceConttract").val();//price

        var rentPeriod = $("#contractDuration").val();//contractDuration

        var netPriceValue = 0;
        $("#netPrice").val(netPriceValue);

        var totalVat = $("#totalVat").val();
        totalVat = totalVat / 100;
        var totalpriceValue = 0;
        $("#totalPrice").val(totalpriceValue);

    }
    else {
        var rentprice = $("#unitPriceConttract").val();//price
        //console.log($("#contractDuration").val());
        var rentPeriod = $("#contractDuration").val();//contractDuration

        var netPriceValue = Number(rentprice) * Number(rentPeriod);
        $("#netPrice").val(netPriceValue);

        var totalVat = $("#totalVat").val();
        totalVat = totalVat / 100;
        var totalpriceValue = Number(netPriceValue) + (Number(totalVat) * Number(netPriceValue));
        $("#contractTotalPrice").val(totalpriceValue);
        console.log($("#contractTotalPrice").val());
        //$("#contractDuration").val(rentPeriod);}

    }
}
$("#unitPriceConttract").change(function () {
    
    calcConttractTotalPrice();
});


 

// ************************************* All Contract view *************************************


 
function SearchContract() {
    var id = $("#searchcustomerid").val();
    var searchdateCheckInTimeid = $("#searchdateCheckInTimeid").val(); 
    var searchdateEXITid = $("#searchdateEXITid").val(); 
    if (id > 0 || searchdateCheckInTimeid != null) {
        var operationListSearch = "";
        var selectidSearch = "";
        var sSearch = "";
        var today = new Date();
        var x = document.getElementById("myDIVSearch");
        if (x.style.display === "none") {
            x.style.display = "block";
        }
        

        $.get("/Vouchers/SearchContracts/?" + "id=" + id + "&dateENTRY=" + searchdateCheckInTimeid + "&dateEXIT=" + searchdateEXITid , function (data) {
            //console.log(data);
            $.each(data, function (i, j) {
                var checkoutDate = new Date(j.checkOut);
                checkoutDate.setHours(0, 0, 0, 0);
                today.setHours(0, 0, 0, 0);
                operationListSearch = "";
                selectidSearch = "oplistSearch" + j.contractid;
                if (culture == "ar-SA") {
                    operationListSearch += "<select class='form-control'  id='" + selectidSearch + "' onchange='popSearchchnage(" + j.contractid + "," + j.totalPrice + ")' ><option value=op>عمليات</option>";

                }
                else {
                    operationListSearch += "<select class='form-control'  id='" + selectidSearch + "' onchange='popSearchchnage(" + j.contractid + "," + j.totalPrice + ")' ><option value=op>Operation</option>";

                }

                sSearch = sSearch + "<tr>";
                sSearch = sSearch + "<td class='align-middle text-center text-sm'>" + (i + 1) + "</td>";
                sSearch = sSearch + "<td class='align-middle text-center text-sm'>" + j.firstName + "&nbsp" + j.lastName + "</td>";

                sSearch = sSearch + "<td class='align-middle text-center text-sm'>" + j.contractid + "</td>";
                sSearch = sSearch + "<td class='align-middle text-center text-sm'>" + j.roomNo + "</td>";


                sSearch = sSearch + "<td class='align-middle text-center text-sm'>" + j.dateCheckInTime + "</td>";
                sSearch = sSearch + "<td class='align-middle text-center text-sm'>" + j.checkOut + "</td>";
                sSearch = sSearch + "<td class='align-middle text-center text-sm'>" + j.totalPrice + "</td>";
                sSearch = sSearch + "<td class='align-middle text-center text-sm'>" + j.countofPerson + "</td>";
                sSearch = sSearch + "<td class='align-middle text-center text-sm'>" + j.duration + "</td>";
                
                if (culture == "ar-SA" && checkoutDate > today ) {
                    operationListSearch += "<option   value='3' >سند قبض</option> ";
                    operationListSearch += "<option value='4' >سند صرف</option> ";
                    operationListSearch += "<option value='6' >مغادره </option> ";
                    operationListSearch += "<option   value='8' >طباعة</option> ";
                }
                else if (culture == "en-US" && checkoutDate > today) {
                    operationListSearch += "<option   value='3' > Recepit Voucher</option> ";
                    operationListSearch += "<option value='4' >Payment Voucher</option> ";
                    operationListSearch += "<option value='6' >Leave </option> ";
                    operationListSearch += "<option   value='8' >Print</option> ";
                } 

                else if (culture == "ar-SA" && checkoutDate < today ) {
                    operationListSearch += "<option   value='8' >طباعة</option> ";
                    
                }
                else if (culture == "en-US" && checkoutDate < today) {
                    operationListSearch += "<option   value='8' >Print</option> ";
                   
                } 




                sSearch = sSearch + "<td class='align-middle text-center text-sm'>" + operationListSearch + "  </td>";

                operationListSearch = "";


                //sSearch = sSearch + "<td class='align-middle text-center text-sm'><button id='EditForm' data-bs-toggle='modal' data-bs-target='#EditModal'  class='card-link btn text-center w-30 mx-2 mx-2 edit'  onclick = 'EditFormAllContracts(" + j.id + ")' > <i class='fa-solid fa-pen' aria-hidden='true'></i></button></td>";

                sSearch = sSearch + "</tr>";


            });
            $("#tbodycustomercontract").html(sSearch); 
            $("#searchcustomerid").val("");
            $("#searchdateCheckInTimeid").val("");
            $("#searchdateEXITid").val("");
        }); 

    }
}
 
function SelectAllRoomInHotel() {
    
    if (culture == "ar-SA") {
        var ss = "<option value=0>اختار رقم الغرفة</option>";
    }
    else { var ss = "<option value=0>select Room Number</option>"; } 
        $.get("/Settings/GetAllRoomInHotel" , function (data) {
            $.each(data, function (i, j) {

                if (culture == "ar-SA") {
                    ss = ss + "<option value=" + j.id + ">غرفة &nbsp" + j.roomNo + " / &nbsp نوع الغرفه &nbsp" + j.typename + "</option>";
                }
                else {
                    ss = ss + "<option value=" + j.id + ">Room &nbsp" + j.roomNo +  " / &nbsp Room Type &nbsp" + j.typename + "</option>";
     }


            });

            $("#roomNum").html(ss);
        });
   
}
 
function GetAllTaxForContract() {

    s = 0;
    $.get("/Settings/GetAllTaxTypeForContract", function (data) {
        $.each(data, function (i, j) {
            s += parseFloat(j.value)
        });
        $("#totalVat").val(s);
    });

}
// set min attribute to checkOut variable  (min date >>> today date)
function SetMinDate() {
    var now = new Date();

    var day = ("0" + now.getDate()).slice(-2);
    var month = ("0" + (now.getMonth() + 1)).slice(-2);
    var today = now.getFullYear() + "-" + (month) + "-" + (day);
    $('#checkOut').attr('min', today);

} 
function GetAllContractsInHotel() {
    var operationList = "";
    var selectid = "";
    var ss = "";
    var today = new Date();
    $.get("/Vouchers/GetAllContractsInHotel", function (data) {
        //console.log(data);
        $.each(data, function (i, j) {
            var checkoutDate = new Date(j.checkOut);
            checkoutDate.setHours(0, 0, 0, 0);
            today.setHours(0, 0, 0, 0);
            operationList = "";
            selectid = "oplist" + j.id;
            if (culture == "ar-SA") {
                operationList += "<select class='form-control'  id='" + selectid + "' onchange='popchnage(" + j.id + "," + j.totalPrice + ")' ><option value=op>عمليات</option>";

            }
            else {
                operationList += "<select class='form-control'  id='" + selectid + "' onchange='popchnage(" + j.id + "," + j.totalPrice + ")' ><option value=op>Operation</option>";

            }

            ss = ss + "<tr>";
            ss = ss + "<td class='align-middle text-center text-sm'>" + (i + 1) + "</td>";
            ss = ss + "<td class='align-middle text-center text-sm'>" + j.firstName + "&nbsp" + j.lastName + "</td>";

            ss = ss + "<td class='align-middle text-center text-sm'>" + j.id + "</td>";
            ss = ss + "<td class='align-middle text-center text-sm'>" + j.roomNo + "</td>";


            ss = ss + "<td class='align-middle text-center text-sm'>" + j.dateCheckInTime + "</td>";
            ss = ss + "<td class='align-middle text-center text-sm'>" + j.checkOutstr + "</td>";
            ss = ss + "<td class='align-middle text-center text-sm'>" + j.totalPrice + "</td>";
            ss = ss + "<td class='align-middle text-center text-sm'>" + j.countofPerson + "</td>";
            ss = ss + "<td class='align-middle text-center text-sm'>" + j.duration + "</td>";
            //console.log(checkoutDate > today);
            if (culture == "ar-SA" && checkoutDate > today) {
                operationList += "<option   value='1' >سند قبض</option> ";
                operationList += "<option value='2' >سند صرف</option> ";
                operationList += "<option value='5' >مغادره </option> ";
                operationList += "<option   value='9' >طباعة</option> ";
            }
            else if (culture == "en-US" && checkoutDate > today)  {
                operationList += "<option   value='1' > Recepit Voucher</option> ";
                operationList += "<option value='2' >Payment Voucher</option> ";
                operationList += "<option value='5' >Leave </option> ";
                operationList += "<option   value='9' >Print</option> ";
            }

            else if (culture == "ar-SA" && checkoutDate < today) {
                operationList += "<option   value='9' >طباعة</option> ";

            }
            else if (culture == "en-US" && checkoutDate < today) {
                operationList += "<option   value='9' >Print</option> ";

            } 
          

            ss = ss + "<td class='align-middle text-center text-sm'>" + operationList + "  </td>";

            operationList = "";


            //ss = ss + "<td class='align-middle text-center text-sm'><button id='EditForm' data-bs-toggle='modal' data-bs-target='#EditModal'  class='card-link btn text-center w-30 mx-2 mx-2 edit'  onclick = 'EditFormAllContracts(" + j.id + ")' > <i class='fa-solid fa-pen' aria-hidden='true'></i></button></td>";

            ss = ss + "</tr>";


        });
        $("#tbodyAllContracts").html(ss);
       



    });

}

function popchnage(id,totalPrice ) {
     
    var xx = "oplist" + id;
    var xz = $("#" + xx).val();
    
    //alert(xz);
    if (xz == "1") {
        RecepitVoucherModal(id, totalPrice);
    }
    else if (xz == "2") {
        PaymentVoucherModal(id, totalPrice);
    } 
};


function popSearchchnage(id, totalPrice) { 

    var oplistSearch = "oplistSearch" + id;


    var oplistSearchvalue = $("#" + oplistSearch).val();
    //alert(oplistSearchvalue);

    if (oplistSearchvalue == '3') {
        RecepitVoucherModal(id, totalPrice);
    }
    else if (oplistSearchvalue == '4') {
        PaymentVoucherModal(id, totalPrice);
    } 

};



function RecepitVoucherModal(contractid , price) {
    $("#receptcontractid").val(contractid);
    $("#recepttotalPrice").val(price);

    $("#RecepitVoucherModal").modal('show');

   
}

$("#amount").change(function () {
    //Total Remaining Value
    var totalPrice = $("#recepttotalPrice").val();
    var amountpaid = $("#amount").val(); 

    var RemainingValue = Number(totalPrice) - Number(amountpaid);
    $("#totalRemainingValue").val(RemainingValue);
 });

$('#saveRecepitVoucher').click(function () {
    var jsonData = {
        Amount: $("#amount").val(),
        TotalPrice: $("#recepttotalPrice").val(),
        TotalRemainingValue: $("#totalRemainingValue").val(), 

        Description: $("#description").val(),
        PaymentDate: $("#paymentDate").val(),
        Isprocess: $("#isprocess").val(),
        PaymentNature: $("#paymentNature").val(),
        HotelId: $("#Sessionhotelid").val(),
        ContractId: $("#receptcontractid").val(),
        PaymentTypeId: $("#paymentTypeId").val(),
        CurrencyId: $("#currencyIdRecepit").val(),

        Id: $("#receptid").val(),

    }
    $.post("/Vouchers/UpdateContractRecepitVoucher", jsonData, function (res) {

        
        if (culture == "ar-SA") {
            alert("تم حفط البيانات بنجاح ");
        }
        else {
           
            alert("This action has been saved !");
        }

        $("#RecepitVoucherModal").modal("toggle");
    });
});
function clearRecepitVoucherModal() {

    $("#amount").val(0);
    $("#paymenttotalPrice").val(0);
    $("totalRemainingValue").val(0);
    $("#description").val("");

    $("#receptcontractid").val(0);
    $("#paymentTypeId").val(0);
    $("#currencyIdRecepit").val(0);
    $("#receptid").val(0);
    

}

///// Payment Voucher Modal
function PaymentVoucherModal(contractid, price) {
    $("#paymentVouchercontractid").val(contractid);
    /*$("#paymenttotalPrice").val(price);*/
    $("#PaymentVoucherModal").modal('show'); 
   
}

//$("#paymentVoucheramount").change(function () {
//    //Total Remaining Value
//    var totalPrice = $("#paymenttotalPrice").val();
//    var amountpaid = $("#paymentVoucheramount").val();

//    var RemainingValue = Number(totalPrice) - Number(amountpaid);
//    $("#totalPaymentRemainingValue").val(RemainingValue);
//});


$('#savePaymentVoucher').click(function () {
    var jsonData = {
        Amount: $("#paymentVoucheramount").val(),
        //TotalPrice: $("#paymenttotalPrice").val(),
        //TotalRemainingValue: $("#totalPaymentRemainingValue").val(), 

        Description: $("#paymentVoucherdescription").val(),
        PaymentDate: $("#paymentVoucherpaymentDate").val(),
        Isprocess: $("#paymentVoucherisprocess").val(),
        PaymentNature: $("#paymentVoucherpaymentNature").val(),
        HotelId: $("#hotelid").val(),
        ContractId: $("#paymentVouchercontractid").val(),
        PaymentTypeId: $("#paymentVoucherpaymentTypeId").val(), 
        CurrencyId: $("#currencyId").val(),
        Id: $("#paymentVoucherid").val(),

    }
    $.post("/Vouchers/UpdateContractPaymentVoucher", jsonData, function (res) {

        if (culture == "ar-SA") {
            alert("تم حفط البيانات بنجاح ");
        }
        else { alert("This action has been saved !"); }

        $("#PaymentVoucherModal").modal("toggle");

    });
});
function clearPaymentVoucherModal() {

    $("#paymentVoucheramount").val(0);
    $("#paymenttotalPrice").val(0);
    $("totalPaymentRemainingValue").val(0);

    $("#paymentVoucherdescription").val("");

    $("#paymentVoucherid").val(0);
    $("#paymentVoucherpaymentTypeId").val(0);
    $("#currencyIdVoucher").val(0);
    $("#paymentVouchercontractid").val(0);

}

var oldcheckInTime = "";
var notspentduration = "";
var spentduration = "";
var oldprice = "";
var oldroomid = "";
var oldduration = "";
function EditFormAllContracts(id) {
    $.ajax({

        type: "POST",
        url: "/Vouchers/GetContract",
        data: { id: id },
        success: function (Contract) {
            ////console.log(Contract);
            $("#hotelId").val(Contract.hotelId);
            $("#contractid").val(Contract.id);
            $("#Rent").val(Contract.unitPrice);
            $("#roomNum").val(Contract.roomId);
            $("#purposeVisitId").val(Contract.purposeVisitId);

            $("#checkInTime").val(Contract.checkInTime);
            $("#checkOut").val(Contract.checkOut);
            $("#totalPrice").val(Contract.totalPrice);
            $("#duration").val(Contract.duration);
            $("#countofPerson").val(Contract.countofPerson);
            $("#totalVat").val(Contract.totalVat);
            $("#netPrice").val(Contract.netPrice);
            $("#unitPrice").val(Contract.unitPrice);
            
            
            oldroomid = $("#roomNum").val();
            oldprice = $("#unitPrice").val();
            oldcheckInTime = $("#checkInTime").val();
            oldduration = $("#duration").val();

        }
    })


}

function changeRoom() {

    var roomid = $("#roomNum").val();
    //alert(oldprice);
    //alert(oldcheckInTime);
    //alert(oldroomid);
    //alert(roomid);
   /* var id = $("#hotelid").val();*/
    if (roomid > 0) {
        $.get("/Settings/GetRoom/" + roomid, function (data) {
            //console.log(data);
            $("#Rent").val(data.normalPrice);
            $("#unitPrice").val(data.normalPrice).change();
             
        });
       
    }
}


function calctotalDaysNum() {
    var date1 = $("#checkInTime").val()
    var date2 = $("#checkOut").val()
    var date3 = oldcheckInTime;

    date1 = date1.split('T')[0];
    date2 = date2.split('T')[0];

    date1 = new Date(date1);
    date2 = new Date(date2);
    var Difference_In_Time = date2.getTime() - date1.getTime();
    var days = Difference_In_Time / (1000 * 3600 * 24);
    ////console.log(days);
    //alert(oldcheckInTime);

    date3 = date3.split('T')[0];
    date3 = new Date(date3);

    var Difference_In_checkInTime = date1.getTime() - date3.getTime();

    spentduration = Difference_In_checkInTime / (1000 * 3600 * 24);
    notspentduration = oldduration - spentduration;
    //alert(spentduration);
    //alert(notspentduration);
    ////console.log(spentduration);

    $("#duration").val(days).change();
}
$("#duration").change(function () {
    calctotalPriceValue();
});

$("#unitPrice").change(function () {
    calctotalPriceValue();
});



function calctotalPriceValue() {
    //new price data
    var newroomid = $("#roomNum").val();
    var rentprice = $("#unitPrice").val();//price
    var rentPeriod = $("#duration").val();//duration
    var netPriceValue = Number(rentprice) * Number(rentPeriod);
    $("#netPrice").val(netPriceValue);
    var totalVat = $("#totalVat").val();
    totalVat = Number(totalVat);
    totalVat = totalVat / 100;
     //old price data
    var oldnetPriceValue = Number(oldprice) * Number(spentduration); //price for spent day in first room
    var notSpentTimePrice = Number(oldprice) * Number(notspentduration)//price for not spent day in first room
    //alert(spentduration);//duration in first room
    //alert(oldnetPriceValue);//duration in first room
    //alert(notSpentTimePrice);//duration in first room
    //alert(newroomid);
    //alert(oldroomid);
    if (newroomid == oldroomid) {
        var totalpriceValue = Number(netPriceValue) + (Number(totalVat) * Number(netPriceValue));
        $("#totalPrice").val(totalpriceValue);
    }
    else if (spentduration > 0 && newroomid != oldroomid) {
        var totalpriceValue = Number(netPriceValue) + (Number(totalVat) * Number(netPriceValue)) + Number(oldnetPriceValue);
        $("#totalPrice").val(totalpriceValue);
    }
     
}

function clearformAllContracts() {
    $("#hotelId").val(0);
    $("#id").val(0);
    $("#checkInTime").val("");
    $("#checkOut").val("");
    $("#totalPrice").val(0);
    $("#duration").val(0);
    $("#purposeVisitId").val(0);
    $("#countofPerson").val(0);
    $("#totalVat").val(0);
    $("#netPrice").val(0);
    $("#unitPrice").val(0);
    $("#Rent").val(0);
}


function DeleteFormAllContracts(id) {
    $.ajax({
        type: "POST",
        url: "/Vouchers/GetContract",
        data: { id: id },
        success: function (Contractd) {
            //console.log(Contractd);

            $("#hotelIdd").val(Contractd.hotelId);
            $("#idd").val(Contractd.id);
            $("#checkInTimed").val(Contractd.checkInTime);
            $("#checkOutd").val(Contractd.checkOut);
            $("#totalPriced").val(Contractd.totalPrice);
        }
    })


}


//*************************** Reports ***************************

function CustomerReports() { 
    var ss = "";
    $.get("/Settings/GetAllCustomerInHotel", function (data) {
        $.each(data, function (i, j) {
            ss = ss + "<tr>";
            ss = ss + "<td class='align-middle text-center text-sm'> " + (i + 1) + "</td>";

            ss = ss + "<td class='align-middle text-center text-sm'>" + j.firstName +' '+ j.lastName + "</td>";
            //ss = ss + "<td class='align-middle text-center text-sm'>" + j.isShare + "</td>";
            ss = ss + "<td class='align-middle text-center text-sm'>" + j.idValue + "</td>";
            ss = ss + "<td class='align-middle text-center text-sm'>" + j.idType + "</td>";

            ss = ss + "<td class='align-middle text-center text-sm'>" + j.countryName + "</td>";
 
            ss = ss + "<td class='align-middle text-center text-sm' ><button   id='contactForm' data-bs-toggle='modal' data-bs-target='#contactModal'    class='card-link btn text-center w-30 mx-2 mx-2' onclick='Getcustomercontacts(" + j.id + ")'> <i class='fa-solid fa-info text-success'></i></button></td>";

            ss = ss + "</tr>";
            //$("#customerid").val(j.id);
        });

        $("#tbodycustomerReports").html(ss);
    });

}


function SearchCustomerReports() { 
    var id = $("#SearchCustomerid").val();
    var idType = $("#idTypeSearch").val();
    var x = document.getElementById("myDIVSearch");
    if (id > 0) {
        var ss = "";
        $.get("/Settings/GetCustomerbyId/?" + "id=" + id + "&idtype=" + idType, function (data) {
            if (data != false) {
                if (x.style.display === "none") {
                    x.style.display = "block";
                }
                ss = ss + "<tr>";
                ss = ss + "<td class='align-middle text-center text-sm'> " + (1) + "</td>";
                ss = ss + "<td class='align-middle text-center text-sm'>" + data.firstName + ' ' + data.lastName + "</td>";
                ss = ss + "<td class='align-middle text-center text-sm'>" + data.idValue + "</td>";
                ss = ss + "<td class='align-middle text-center text-sm'>" + data.idType + "</td>";
                ss = ss + "<td class='align-middle text-center text-sm'>" + data.countryName + "</td>";
                ss = ss + "<td class='align-middle text-center text-sm' ><button   id='contactForm' data-bs-toggle='modal' data-bs-target='#contactModal'    class='card-link btn text-center w-30 mx-2 mx-2' onclick='Getcustomercontacts(" + data.id + ")'> <i class='fa-solid fa-info text-success'></i></button></td>";

                ss = ss + "</tr>";
                $("#tbodysearchCustomerReport").html(ss);
                $("#SearchCustomerid").val("");
                $("#idTypeSearch").val("");
            }
            else {
                x.style.display = "none";
            }

        });
    }
}

function EmployeeReports() {

    var ss = "";
    $.get("/Settings/GetAllEmployeeInHotel", function (data) {
        $.each(data, function (i, j) {
            ss = ss + "<tr>";
            ss = ss + "<td class='align-middle text-center text-sm'>" + (i + 1) + "</td>";
            ss = ss + "<td class='align-middle text-center text-sm'>" + j.name + "</td>";
            ss = ss + "<td class='align-middle text-center text-sm'>" + j.birthDate + "</td>";
            ss = ss + "<td class='align-middle text-center text-sm'>" + j.idNumber + "</td>";
            ss = ss + "<td class='align-middle text-center text-sm'>" + j.idType + "</td>"; 
            ss = ss + "<td class='align-middle text-center text-sm'>" + j.countryName + "</td>"; 
            ss = ss + "</tr>";

        });
        $("#tbodyEmployeeReports").html(ss);
    });

}

function SearchEmployeeReports() {
    var id = $("#SearchEmployeeid").val();
    var idType = $("#idTypeSearch").val();
    var x = document.getElementById("myDIVSearch");
    if (id > 0) {
        var ss = "";
        $.get("/Settings/GetEmployeebyId/?" + "id=" + id + "&idtype=" + idType, function (data) {
            if (data != false) {
                if (x.style.display === "none") {
                    x.style.display = "block";
                }
                ss = ss + "<tr>";
                ss = ss + "<td class='align-middle text-center text-sm'> " + (1) + "</td>";
                ss = ss + "<td class='align-middle text-center text-sm'>" + data.name + "</td>";
                ss = ss + "<td class='align-middle text-center text-sm'>" + data.birthDate + "</td>";
                ss = ss + "<td class='align-middle text-center text-sm'>" + data.idNumber + "</td>";
                ss = ss + "<td class='align-middle text-center text-sm'>" + data.idType + "</td>";
                ss = ss + "<td class='align-middle text-center text-sm'>" + data.countryName + "</td>";
                ss = ss + "</tr>";
                $("#tbodysearchEmployeeReport").html(ss);
                $("#SearchEmployeeid").val("");
                $("#idTypeSearch").val("");
            }
            else {
                x.style.display = "none";
            }

        });
    }
}


function AssetReports() {
    var ss = "";
    $.get("/Settings/GetAllAssetInHotel", function (data) {
        //console.log(data);
        $.each(data, function (i, j) {
            ss = ss + "<tr>";
            ss = ss + "<td class='align-middle text-center text-sm'>" + (i + 1) + "</td>";
            ss = ss + "<td class='align-middle text-center text-sm'>" + j.assetName + "</td>";
            ss = ss + "<td class='align-middle text-center text-sm'>" + j.naturelofAsset + "</td>";
            ss = ss + "<td class='align-middle text-center text-sm'>" + j.serialNo + "</td>"; 
            ss = ss + "<td class='align-middle text-center text-sm'>" + j.price + "</td>";
            ss = ss + "<td class='align-middle text-center text-sm'>" + j.assetStatus + "</td>";
            ss = ss + "<td class='align-middle text-center text-sm'>" + j.storename + "</td>";
            ss = ss + "<td class='align-middle text-center text-sm'>" + j.intailQty + "</td>";
            ss = ss + "<td class='align-middle text-center text-sm'>" + j.currentQty + "</td>";

             
            ss = ss + "<td class='align-middle text-center text-sm'>" + j.decription + "</td>";
           
            ss = ss + "</tr>";

        });
        $("#tbodyAssetsReport").html(ss);
    });

}

function RoomPriceWithoutBreakfastReport() {


    var ss = "";
    $.get("/Settings/GetAllRoomInHotel", function (data) {
        $.each(data, function (i, j) {
            ss = ss + "<tr>";
            ss = ss + "<td class='align-middle text-center text-sm'>" + (i + 1) + "</td>";
            ss = ss + "<td class='align-middle text-center text-sm'>" + j.roomNo + "</td>";
            ss = ss + "<td class='align-middle text-center text-sm'>" + j.floorNo + "</td>";
            ss = ss + "<td class='align-middle text-center text-sm'>" + j.normalPrice + "</td>";
            ss = ss + "<td class='align-middle text-center text-sm'>" + j.minPrice + "</td>";
            ss = ss + "<td class='align-middle text-center text-sm'>" + j.singleBedNo + "</td>";
            ss = ss + "<td class='align-middle text-center text-sm'>" + j.doubleBedNo + "</td>";
            ss = ss + "<td class='align-middle text-center text-sm'>" + j.wcNo + "</td>";
            ss = ss + "</tr>";

        });
        $("#RoomPriceWithoutBreakfast").html(ss);
    });

}


function RoomPriceWithBreakfastReport() { 
    var ss = "";
    $.get("/Settings/GetAllRoomInHotel", function (data) {
        $.each(data, function (i, j) {
            ss = ss + "<tr>";
            ss = ss + "<td class='align-middle text-center text-sm'>" + (i + 1) + "</td>";
            ss = ss + "<td class='align-middle text-center text-sm'>" + j.roomNo + "</td>";
            ss = ss + "<td class='align-middle text-center text-sm'>" + j.floorNo + "</td>";
            ss = ss + "<td class='align-middle text-center text-sm'>" + j.priceWithBreakfast + "</td>";
            ss = ss + "<td class='align-middle text-center text-sm'>" + j.singleBedNo + "</td>";
            ss = ss + "<td class='align-middle text-center text-sm'>" + j.doubleBedNo + "</td>";
            ss = ss + "<td class='align-middle text-center text-sm'>" + j.wcNo + "</td>";
            ss = ss + "</tr>";

        });
        $("#RoomPriceWithBreakfast").html(ss);
    });

}

function RoomReport() {


    var ss = "";
    $.get("/Settings/GetAllRoomInHotel", function (data) {
        $.each(data, function (i, j) {
            ss = ss + "<tr>";
            ss = ss + "<td class='align-middle text-center text-sm'>" + (i + 1) + "</td>";
            ss = ss + "<td class='align-middle text-center text-sm'>" + j.roomNo + "</td>";
            ss = ss + "<td class='align-middle text-center text-sm'>" + j.floorNo + "</td>";
            ss = ss + "<td class='align-middle text-center text-sm'>" + j.status + "</td>";
            ss = ss + "<td class='align-middle text-center text-sm'>" + j.typename + "</td>";
            ss = ss + "<td class='align-middle text-center text-sm'>" + j.normalPrice + "</td>";
            ss = ss + "<td class='align-middle text-center text-sm'>" + j.singleBedNo + "</td>";
            ss = ss + "<td class='align-middle text-center text-sm'>" + j.doubleBedNo + "</td>";
           


            ss = ss + "</tr>";

        });
        $("#RoomReport").html(ss);
    });

}


function TotalroomincomeReport() {


    var ss = "";
    $.get("/Reports/GetTotalroomincome", function (data) {
        $.each(data, function (i, j) {
            ss = ss + "<tr>";
            ss = ss + "<td class='align-middle text-center text-sm'>" + (i + 1) + "</td>";
            ss = ss + "<td class='align-middle text-center text-sm'>" + j.roomId + "</td>"; 
            ss = ss + "<td class='align-middle text-center text-sm'>" + j.roomType + "</td>"; 
            ss = ss + "<td class='align-middle text-center text-sm'>" + j.totalPrice + "</td>";
             
            ss = ss + "</tr>";

        });
        $("#TotalRoomIncomeReport").html(ss);
    });

}

function SearchTotalRoomIncomeByTime() {

    var FromTimeid = $("#fromTimeid").val();
    var ToTimeid = $("#toTimeid").val();
    if (FromTimeid != null) {

        var ss = "";
        var x = document.getElementById("myDIVSearch");

        $.get("/Reports/Searchroomincome/?" + "startDate=" + FromTimeid + "&endDate=" + toTimeid, function (data) {
            console.log(data);
            if (data != false) {
                if (x.style.display === "none") {
                    x.style.display = "block";
                }
                $.each(data, function (i, j) {

                    ss = ss + "<tr>";
                    ss = ss + "<td class='align-middle text-center text-sm'>" + (i + 1) + "</td>";
                    ss = ss + "<td class='align-middle text-center text-sm'>" + j.roomId + "</td>";
                    ss = ss + "<td class='align-middle text-center text-sm'>" + j.roomType + "</td>";
                    ss = ss + "<td class='align-middle text-center text-sm'>" + j.totalPrice + "</td>";
                    ss = ss + "</tr>";


                });
                $("#tbodyTotalIncome").html(ss);
                $("#fromTimeid").val("");
                $("#toTimeid").val("");
            }
            else {
                x.style.display = "none";
            }

        });

    }
}






function ContractsReport() {
   
    var ss = "";
    $.get("/Vouchers/GetAllContractsInHotel", function (data) {
        //console.log(data);
        $.each(data, function (i, j) { 
            ss = ss + "<tr>";
            ss = ss + "<td class='align-middle text-center text-sm'>" + (i + 1) + "</td>";
            ss = ss + "<td class='align-middle text-center text-sm'>" + j.firstName + "&nbsp" + j.lastName + "</td>";

            ss = ss + "<td class='align-middle text-center text-sm'>" + j.id + "</td>";
            ss = ss + "<td class='align-middle text-center text-sm'>" + j.roomNo + "</td>";


            ss = ss + "<td class='align-middle text-center text-sm'>" + j.dateCheckInTime + "</td>";
            ss = ss + "<td class='align-middle text-center text-sm'>" + j.checkOut + "</td>";
            ss = ss + "<td class='align-middle text-center text-sm'>" + j.totalPrice + "</td>";
            ss = ss + "<td class='align-middle text-center text-sm'>" + j.countofPerson + "</td>";
            ss = ss + "<td class='align-middle text-center text-sm'>" + j.duration + "</td>"; 
            ss = ss + "</tr>";


        });
        $("#ContractsReport").html(ss); 
    });

}


function SearchReportContract() {
    var id = $("#searchcustomerid").val();
    var searchdateCheckInTimeid = $("#searchdateCheckInTimeid").val();
    var searchdateEXITid = $("#searchdateEXITid").val();
    if (id > 0 || searchdateCheckInTimeid != null) {
        
        var sSearch = "";
        var x = document.getElementById("myDIVSearch");
         
        $.get("/Vouchers/SearchContracts/?" + "id=" + id + "&dateENTRY=" + searchdateCheckInTimeid + "&dateEXIT=" + searchdateEXITid, function (data) {
            //console.log(data);
            if (data != false) {
                if (x.style.display === "none") {
                    x.style.display = "block";
                }
                $.each(data, function (i, j) {

                    sSearch = sSearch + "<tr>";
                    sSearch = sSearch + "<td class='align-middle text-center text-sm'>" + (i + 1) + "</td>";
                    sSearch = sSearch + "<td class='align-middle text-center text-sm'>" + j.firstName + "&nbsp" + j.lastName + "</td>";

                    sSearch = sSearch + "<td class='align-middle text-center text-sm'>" + j.contractid + "</td>";
                    sSearch = sSearch + "<td class='align-middle text-center text-sm'>" + j.roomNo + "</td>";


                    sSearch = sSearch + "<td class='align-middle text-center text-sm'>" + j.dateCheckInTime + "</td>";
                    sSearch = sSearch + "<td class='align-middle text-center text-sm'>" + j.checkOut + "</td>";
                    sSearch = sSearch + "<td class='align-middle text-center text-sm'>" + j.totalPrice + "</td>";
                    sSearch = sSearch + "<td class='align-middle text-center text-sm'>" + j.countofPerson + "</td>";
                    sSearch = sSearch + "<td class='align-middle text-center text-sm'>" + j.duration + "</td>";

                    sSearch = sSearch + "</tr>";


                });
                $("#tbodycustomercontract").html(sSearch);
                $("#searchcustomerid").val("");
                $("#searchdateCheckInTimeid").val("");
                $("#searchdateEXITid").val("");
            }
            else {
                x.style.display = "none";
            }
          
        });

    }
}


function HospitalityContractsReport() {

    var ss = "";
    $.get("/Vouchers/GetAllHospitalityContractsInHotel", function (data) {
        //console.log(data);
        $.each(data, function (i, j) {
            ss = ss + "<tr>";
            ss = ss + "<td class='align-middle text-center text-sm'>" + (i + 1) + "</td>";
            ss = ss + "<td class='align-middle text-center text-sm'>" + j.firstName + "&nbsp" + j.lastName + "</td>";

            ss = ss + "<td class='align-middle text-center text-sm'>" + j.id + "</td>";
            ss = ss + "<td class='align-middle text-center text-sm'>" + j.roomNo + "</td>";


            ss = ss + "<td class='align-middle text-center text-sm'>" + j.dateCheckInTime + "</td>";
            ss = ss + "<td class='align-middle text-center text-sm'>" + j.checkOut + "</td>";
            ss = ss + "<td class='align-middle text-center text-sm'>" + j.totalPrice + "</td>";
            ss = ss + "<td class='align-middle text-center text-sm'>" + j.countofPerson + "</td>";
            ss = ss + "<td class='align-middle text-center text-sm'>" + j.duration + "</td>";
            ss = ss + "</tr>";


        });
        $("#HospitalityContractsReport").html(ss);
    });

}



//RecepitVouchers
function RecepitVouchersReport() {
 
    var ss = "";
    $.get("/Reports/GetAllRecepitVouchersInHotel", function (data) {
        ////console.log(data);
        $.each(data, function (i, j) {
 

            ss = ss + "<tr>";
            ss = ss + "<td class='align-middle text-center text-sm'>" + (i + 1) + "</td>";
            ss = ss + "<td class='align-middle text-center text-sm'>" + j.customername + " " + j.customerlastname+ "</td>";
            ss = ss + "<td class='align-middle text-center text-sm'>" + j.roomNo + "</td>";
            ss = ss + "<td class='align-middle text-center text-sm'>" + j.totalPrice + "</td>";
            ss = ss + "<td class='align-middle text-center text-sm'>" + j.paymentType + "</td>";
            ss = ss + "<td class='align-middle text-center text-sm'>" + j.paymentNature + "</td>";
            ss = ss + "<td class='align-middle text-center text-sm'>" + j.amount + "</td>";
            ss = ss + "<td class='align-middle text-center text-sm'>" + j.paymentDate + "</td>";


            ss = ss + "</tr>"; 


        });
        $("#tbodyb").html(ss);




    });

}

function SearchReportRecepitVoucher() {
  
    var searchdateCheckInTimeid = $("#searchdateCheckInTimeid").val();
    var searchdateEXITid = $("#searchdateEXITid").val();
    if ( searchdateCheckInTimeid != null) {

        var ss = "";
        var x = document.getElementById("myDIVSearch");

        $.get("/Vouchers/SearchRecepitVoucher/?" + "startDate=" + searchdateCheckInTimeid + "&endDate=" + searchdateEXITid, function (data) {
            //console.log(data);
            if (data != false) {
                if (x.style.display === "none") {
                    x.style.display = "block";
                }
                $.each(data, function (i, j) {

                    ss = ss + "<tr>";
                    ss = ss + "<td class='align-middle text-center text-sm'>" + (i + 1) + "</td>";
                    ss = ss + "<td class='align-middle text-center text-sm'>" + j.customername + " " + j.customerlastname + "</td>";
                    ss = ss + "<td class='align-middle text-center text-sm'>" + j.roomNo + "</td>";
                    ss = ss + "<td class='align-middle text-center text-sm'>" + j.totalPrice + "</td>";
                    ss = ss + "<td class='align-middle text-center text-sm'>" + j.paymentType + "</td>";
                    ss = ss + "<td class='align-middle text-center text-sm'>" + j.paymentNature + "</td>";
                    ss = ss + "<td class='align-middle text-center text-sm'>" + j.amount + "</td>";
                    ss = ss + "<td class='align-middle text-center text-sm'>" + j.paymentDate + "</td>";
                    ss = ss + "</tr>";


                });
                $("#tbodycustomercontract").html(ss);
                 $("#searchdateCheckInTimeid").val("");
                $("#searchdateEXITid").val("");
            }
            else {
                x.style.display = "none";
            }

        });

    }
}


// Employee handover data
function Employeehandoverdata() {

    var ss = "";
    $.get("/Reports/GetEmployeehandoverdata", function (data) {
        ////console.log(data);
        $.each(data, function (i, j) {


            ss = ss + "<tr>";
            ss = ss + "<td class='align-middle text-center text-sm'>" + (i + 1) + "</td>"; 
            ss = ss + "<td class='align-middle text-center text-sm'>" + j.amount + "</td>";
            ss = ss + "<td class='align-middle text-center text-sm'>" + j.paymentType + "</td>";
            ss = ss + "<td class='align-middle text-center text-sm'>" + j.paymentNature + "</td>";
            ss = ss + "<td class='align-middle text-center text-sm'>" + j.paymentDate + "</td>";


            ss = ss + "</tr>"; 
        });
        $("#tbodydata").html(ss);




    });

}
 
function SearchEmployeehandoverdata() {

    var searchdateCheckInTimeid = $("#searchdateCheckInTimeid").val();
    var searchdateEXITid = $("#searchdateEXITid").val();
    if (searchdateCheckInTimeid != null) {

        var ss = "";
        var x = document.getElementById("myDIVSearch");

        $.get("/Reports/SearchRecepitVoucher/?" + "startDate=" + searchdateCheckInTimeid + "&endDate=" + searchdateEXITid, function (data) {
            //console.log(data);
            if (data != false) {
                if (x.style.display === "none") {
                    x.style.display = "block";
                }
                console.log(data);
                $.each(data, function (i, j) {

                    ss = ss + "<tr>";
                    ss = ss + "<td class='align-middle text-center text-sm'>" + (i + 1) + "</td>";
                    ss = ss + "<td class='align-middle text-center text-sm'>" + j.username + "</td>";
                    ss = ss + "<td class='align-middle text-center text-sm'>" + j.amount + "</td>";
                    ss = ss + "<td class='align-middle text-center text-sm'>" + j.paymentType + "</td>";
                    if (culture == "ar-SA" && j.paymentNature == "Contract") {
                        ss = ss + "<td class='align-middle text-center text-sm'> عقد </td>";

                    }
                    else {
                        ss = ss + "<td class='align-middle text-center text-sm'>" + j.paymentNature + "</td>";
                    }

                    ss = ss + "<td class='align-middle text-center text-sm'>" + j.paymentDate + "</td>";
                    ss = ss + "</tr>";


                });
                $("#tbodycustomercontract").html(ss);
                $("#searchdateCheckInTimeid").val("");
                $("#searchdateEXITid").val("");
            }
            else {
                x.style.display = "none";
            }

        });

    }
}

function toggleItem() {
    var selectElement = document.getElementById('culture');
    var currentSelection = selectElement.value;
    console.log(currentSelection)
    // Toggle between items
    if (currentSelection === 'en-US') {
        selectElement.value = 'ar-SA';
    } else {
        selectElement.value = 'en-US';
    }
}


// ************************************* Services  *************************************

function ServicesReport() { 
    var ss = "";
    $.get("/Reports/GetAllServicesInHotel", function (data) {
        console.log(data);
        $.each(data, function (i, j) { 
            ss = ss + "<tr>";
            ss = ss + "<td class='align-middle text-center text-sm'>" + (i + 1) + "</td>";
            ss = ss + "<td class='align-middle text-center text-sm'>" + j.customername + " " + j.customerlastname + "</td>";
            ss = ss + "<td class='align-middle text-center text-sm'>" + j.contractid + "</td>";
            ss = ss + "<td class='align-middle text-center text-sm'>" + j.orderedDate + "</td>";
            ss = ss + "<td class='align-middle text-center text-sm'>" + j.id + "</td>";
            ss = ss + "<td class='align-middle text-center text-sm'>" + j.netPrice + "</td>";
            ss = ss + "<td class='align-middle text-center text-sm'>" + j.vat + "</td>";
            ss = ss + "<td class='align-middle text-center text-sm'>" + j.total + "</td>"; 
            ss = ss + "</tr>";


        });
        $("#tbodyServices").html(ss);  
    });

}

function SearchReportServices() {

    var FromDate = $("#searchFromDateServicesId").val();
    var ToDate = $("#searchToDateServicesId").val();
    if (FromDate != null) {

        var ss = "";
        var x = document.getElementById("myDIVSearch");

        $.get("/Reports/SearchServices/?" + "startDate=" + FromDate + "&endDate=" + ToDate, function (data) {
            console.log(data);
            if (data != false) {
                if (x.style.display === "none") {
                    x.style.display = "block";
                }
                $.each(data, function (i, j) {

                    ss = ss + "<tr>";
                    ss = ss + "<td class='align-middle text-center text-sm'>" + (i + 1) + "</td>";
                    ss = ss + "<td class='align-middle text-center text-sm'>" + j.customername + " " + j.customerlastname + "</td>";
                    ss = ss + "<td class='align-middle text-center text-sm'>" + j.contractid + "</td>";
                    ss = ss + "<td class='align-middle text-center text-sm'>" + j.orderedDate + "</td>";
                    ss = ss + "<td class='align-middle text-center text-sm'>" + j.id + "</td>";
                    ss = ss + "<td class='align-middle text-center text-sm'>" + j.netPrice + "</td>";
                    ss = ss + "<td class='align-middle text-center text-sm'>" + j.vat + "</td>";
                    ss = ss + "<td class='align-middle text-center text-sm'>" + j.total + "</td>"; 
                    ss = ss + "</tr>";


                });
                $("#tbodySearchServices").html(ss);
                //$("#searchFromDateServicesId").val("");
                //$("#searchToDateServicesId").val("");
            }
            else {
                x.style.display = "none";
            }

        });

    }
}

function PrintSearchServices() {

    var FromDate = $("#searchFromDateServicesId").val();
    var ToDate = $("#searchToDateServicesId").val();
    console.log(FromDate);
     
     
    $.ajax({
        url: '/Reports/PrintSearchServices',
        method: 'GET',
        data: { StartDate: FromDate, EndDate: ToDate },
        success: function (result) {
            // Handle the response
        }
    });
    
}

// ************************************* Purchase  *************************************
function PurchaseReport() {
    var ss = "";
    $.get("/Reports/GetAllSPurchasesInHotel", function (data) {
        console.log(data);
        $.each(data, function (i, j) {
            ss = ss + "<tr>";
            ss = ss + "<td class='align-middle text-center text-sm'>" + (i + 1) + "</td>";
            ss = ss + "<td class='align-middle text-center text-sm'>" + j.vendorname +  "</td>";
            ss = ss + "<td class='align-middle text-center text-sm'>" + j.purchaseDate + "</td>";
            ss = ss + "<td class='align-middle text-center text-sm'>" + j.id + "</td>";
            ss = ss + "<td class='align-middle text-center text-sm'>" + j.netPrice + "</td>";
            ss = ss + "<td class='align-middle text-center text-sm'>" + j.vat + "</td>";
            ss = ss + "<td class='align-middle text-center text-sm'>" + j.total + "</td>";
            ss = ss + "</tr>";


        });
        $("#tbodyPurchase").html(ss);
    });

}

function SearchReportPurchase() {

    var FromDate = $("#searchFromDateId").val();
    var ToDate = $("#searchToDateId").val();
    if (FromDate != null) {

        var ss = "";
        var x = document.getElementById("myDIVSearch");

        $.get("/Reports/SearchPurchases/?" + "startDate=" + FromDate + "&endDate=" + ToDate, function (data) {
            console.log(data);
            if (data != false) {
                if (x.style.display === "none") {
                    x.style.display = "block";
                }
                $.each(data, function (i, j) {

                    ss = ss + "<tr>";
                    ss = ss + "<td class='align-middle text-center text-sm'>" + (i + 1) + "</td>";
                    ss = ss + "<td class='align-middle text-center text-sm'>" + j.vendorname + "</td>";
                    ss = ss + "<td class='align-middle text-center text-sm'>" + j.purchaseDate + "</td>";
                    ss = ss + "<td class='align-middle text-center text-sm'>" + j.id + "</td>";
                    ss = ss + "<td class='align-middle text-center text-sm'>" + j.netPrice + "</td>";
                    ss = ss + "<td class='align-middle text-center text-sm'>" + j.vat + "</td>";
                    ss = ss + "<td class='align-middle text-center text-sm'>" + j.total + "</td>";
                    ss = ss + "</tr>";


                });
                $("#tbodySearchPurchases").html(ss);
                //$("#searchFromDateServicesId").val("");
                //$("#searchToDateServicesId").val("");
            }
            else {
                x.style.display = "none";
            }

        });

    }
}


function PrintSearchPurchases() {

    var FromDate = $("#searchFromDateId").val();
    var ToDate = $("#searchToDateId").val();
    console.log(ToDate);
    // Build the URL with query parameters
    var url = "/Reports/PrintSearchPurchases?StartDate=" + encodeURIComponent(FromDate) + "&EndDate=" + encodeURIComponent(ToDate);

    // Navigate to the specified URL
    window.open(url, "_blank");
    //window.location.href = url;

}







function PurchaseItemsReport() {
    var ss = "";
    $.get("/Reports/GetAllSPurchasesItemsInHotel", function (data) {
        console.log(data);
        $.each(data, function (i, j) {
            ss = ss + "<tr>";
            ss = ss + "<td class='align-middle text-center text-sm'>" + (i + 1) + "</td>";
            ss = ss + "<td class='align-middle text-center text-sm'>" + j.assetname + "</td>";
            ss = ss + "<td class='align-middle text-center text-sm'>" + j.purchaseDate + "</td>";
             ss = ss + "<td class='align-middle text-center text-sm'>" + j.quantity + "</td>";
            ss = ss + "<td class='align-middle text-center text-sm'>" + j.unitPrice + "</td>";
            ss = ss + "<td class='align-middle text-center text-sm'>" + j.total + "</td>";
            ss = ss + "</tr>";


        });
        $("#tbodyPurchaseItem").html(ss);
    });

}
// ************************************* Roles & & Users  *************************************
function GetAllRoles() {
    var ss = "";
    $.get("/Roles/GetAllRoles", function (data) {
        console.log(data);
        $.each(data, function (i, j) {
            ss = ss + "<option value=" + j.roleId + ">" + j.roleName + "</option>";
        });
        $("#roles").html(ss);

    });
}

function GetUserRoles(id) {
    console.log(id);
    $("#userId").val(id)
    //$.ajax({
    //    type: "POST",
    //    url: "/Roles/GetUserRoles",
    //    data: { userId: id },
    //    success: function (user) {
    //        //console.log(user);
    //        $("#userId").val(user.userId)
    //    }
    //})

    var userId = id;
    if (id != null) {
        var ss = "";
        $.get("/Roles/GetUserRoles/?" + "userId=" + userId, function (data) {
            console.log(data.selectedRolesId);
            
            $.each(data.selectedRolesId, function (index, roleName) {
                ss = ss + "<tr>";
                ss = ss + "<td class='align-middle text-center text-sm'>" + (index + 1) + "</td>";
                ss = ss + "<td  class='align-middle text-center text-sm'>" + roleName + "</td>";  
                ss = ss + "<td>  <button class='btn btn-link text-danger text-gradient px-3 mb-0' onClick='RemoveUserRole( \"" + userId + "\", \"" + roleName + "\")'> <i class='fa-regular fa-trash-can me-2' aria-hidden='true'></i></button> </td>";
                ss = ss + "</tr>";
               
            });
            $("#tbodyUserRoles").html(ss);
        });
    }
     
}

function RemoveUserRole(userid, roleName)
{
    var jsonData = { 
        userId: userid,
        RoleName: roleName, 
    }
    $.post("/Roles/RemoveUserRole", jsonData, function (res) {

        alert("This action has been saved !");
        // Reload the page after the role is removed
        //location.reload();
        GetUserRoles(userid);

    });
}






function clearformUserRole() { 
    $("#roles").val("");
    $("#userId").val(0); 
}
 
 









"use strict"; !function () { var e, t; -1 < navigator.platform.indexOf("Win") && (document.getElementsByClassName("main-content")[0] && (e = document.querySelector(".main-content"), new PerfectScrollbar(e)), document.getElementsByClassName("sidenav")[0] && (e = document.querySelector(".sidenav"), new PerfectScrollbar(e)), document.getElementsByClassName("navbar-collapse")[0] && (t = document.querySelector(".navbar:not(.navbar-expand-lg) .navbar-collapse"), new PerfectScrollbar(t)), document.getElementsByClassName("fixed-plugin")[0]) && (t = document.querySelector(".fixed-plugin"), new PerfectScrollbar(t)) }(), navbarBlurOnScroll("navbarBlur"); var fixedPlugin, fixedPluginButton, fixedPluginButtonNav, fixedPluginCard, fixedPluginCloseButton, navbar, buttonNavbarFixed, tooltipTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="tooltip"]')), tooltipList = tooltipTriggerList.map(function (e) { return new bootstrap.Tooltip(e) }), total = (document.querySelector(".fixed-plugin") && (fixedPlugin = document.querySelector(".fixed-plugin"), fixedPluginButton = document.querySelector(".fixed-plugin-button"), fixedPluginButtonNav = document.querySelector(".fixed-plugin-button-nav"), fixedPluginCard = document.querySelector(".fixed-plugin .card"), fixedPluginCloseButton = document.querySelectorAll(".fixed-plugin-close-button"), navbar = document.getElementById("navbarBlur"), buttonNavbarFixed = document.getElementById("navbarFixed"), fixedPluginButton && (fixedPluginButton.onclick = function () { fixedPlugin.classList.contains("show") ? fixedPlugin.classList.remove("show") : fixedPlugin.classList.add("show") }), fixedPluginButtonNav && (fixedPluginButtonNav.onclick = function () { fixedPlugin.classList.contains("show") ? fixedPlugin.classList.remove("show") : fixedPlugin.classList.add("show") }), fixedPluginCloseButton.forEach(function (e) { e.onclick = function () { fixedPlugin.classList.remove("show") } }), document.querySelector("body").onclick = function (e) { e.target != fixedPluginButton && e.target != fixedPluginButtonNav && e.target.closest(".fixed-plugin .card") != fixedPluginCard && fixedPlugin.classList.remove("show") }, navbar) && "true" == navbar.getAttribute("navbar-scroll") && buttonNavbarFixed.setAttribute("checked", "true"), document.querySelectorAll(".nav-pills")); function getEventTarget(e) { return (e = e || window.event).target || e.srcElement } function sidebarColor(e) { for (var t, n = e.parentElement.children, i = e.getAttribute("data-color"), a = 0; a < n.length; a++)n[a].classList.remove("active"); e.classList.contains("active") ? e.classList.remove("active") : e.classList.add("active"), document.querySelector(".sidenav").setAttribute("data-color", i), document.querySelector("#sidenavCard") && (e = ["card", "card-background", "shadow-none", "card-background-mask-" + i], (t = document.querySelector("#sidenavCard")).className = "", t.classList.add(...e), t = ["ni", "ni-diamond", "text-gradient", "text-lg", "top-0", "text-" + i], (e = document.querySelector("#sidenavCardIcon")).className = "", e.classList.add(...t)) } function navbarFixed(e) { var t = ["position-sticky", "blur", "shadow-blur", "mt-4", "left-auto", "top-1", "z-index-sticky"], n = document.getElementById("navbarBlur"); e.getAttribute("checked") ? (n.classList.remove(...t), n.setAttribute("navbar-scroll", "false"), navbarBlurOnScroll("navbarBlur"), e.removeAttribute("checked")) : (n.classList.add(...t), n.setAttribute("navbar-scroll", "true"), navbarBlurOnScroll("navbarBlur"), e.setAttribute("checked", "true")) } function navbarBlurOnScroll(e) { const t = document.getElementById(e); e = !!t && t.getAttribute("navbar-scroll"); let n = ["position-sticky", "blur", "shadow-blur", "mt-4", "left-auto", "top-1", "z-index-sticky"], i = ["shadow-none"]; function a() { t && (t.classList.remove(...n), t.classList.add(...i), s("transparent")) } function s(e) { var t = document.querySelectorAll(".navbar-main .nav-link"), n = document.querySelectorAll(".navbar-main .sidenav-toggler-line"); "blur" === e ? (t.forEach(e => { e.classList.remove("text-body") }), n.forEach(e => { e.classList.add("bg-dark") })) : "transparent" === e && (t.forEach(e => { e.classList.add("text-body") }), n.forEach(e => { e.classList.remove("bg-dark") })) } window.onscroll = debounce("true" == e ? function () { 5 < window.scrollY ? (t.classList.add(...n), t.classList.remove(...i), s("blur")) : a() } : function () { a() }, 10) } function debounce(i, a, s) { var l; return function () { var e = this, t = arguments, n = s && !l; clearTimeout(l), l = setTimeout(function () { l = null, s || i.apply(e, t) }, a), n && i.apply(e, t) } } function sidebarType(e) { for (var t = e.parentElement.children, n = e.getAttribute("data-class"), i = [], a = 0; a < t.length; a++)t[a].classList.remove("active"), i.push(t[a].getAttribute("data-class")); e.classList.contains("active") ? e.classList.remove("active") : e.classList.add("active"); for (var s = document.querySelector(".sidenav"), a = 0; a < i.length; a++)s.classList.remove(i[a]); s.classList.add(n) } total.forEach(function (s, e) { var l = document.createElement("div"), t = s.querySelector("li:first-child .nav-link").cloneNode(); t.innerHTML = "-", l.classList.add("moving-tab", "position-absolute", "nav-link"), l.appendChild(t), s.appendChild(l), s.getElementsByTagName("li").length; l.style.padding = "0px", l.style.width = s.querySelector("li:nth-child(1)").offsetWidth + "px", l.style.transform = "translate3d(0px, 0px, 0px)", l.style.transition = ".5s ease", s.onmouseover = function (e) { let a = getEventTarget(e).closest("li"); if (a) { let n = Array.from(a.closest("ul").children), i = n.indexOf(a) + 1; s.querySelector("li:nth-child(" + i + ") .nav-link").onclick = function () { l = s.querySelector(".moving-tab"); let e = 0; if (s.classList.contains("flex-column")) { for (var t = 1; t <= n.indexOf(a); t++)e += s.querySelector("li:nth-child(" + t + ")").offsetHeight; l.style.transform = "translate3d(0px," + e + "px, 0px)", l.style.height = s.querySelector("li:nth-child(" + t + ")").offsetHeight } else { for (t = 1; t <= n.indexOf(a); t++)e += s.querySelector("li:nth-child(" + t + ")").offsetWidth; l.style.transform = "translate3d(" + e + "px, 0px, 0px)", l.style.width = s.querySelector("li:nth-child(" + i + ")").offsetWidth + "px" } } } } }), window.addEventListener("resize", function (e) { total.forEach(function (t, e) { t.querySelector(".moving-tab").remove(); var n = document.createElement("div"), i = t.querySelector(".nav-link.active").cloneNode(), a = (i.innerHTML = "-", n.classList.add("moving-tab", "position-absolute", "nav-link"), n.appendChild(i), t.appendChild(n), n.style.padding = "0px", n.style.transition = ".5s ease", t.querySelector(".nav-link.active").parentElement); if (a) { var s = Array.from(a.closest("ul").children), i = s.indexOf(a) + 1; let e = 0; if (t.classList.contains("flex-column")) { for (var l = 1; l <= s.indexOf(a); l++)e += t.querySelector("li:nth-child(" + l + ")").offsetHeight; n.style.transform = "translate3d(0px," + e + "px, 0px)", n.style.width = t.querySelector("li:nth-child(" + i + ")").offsetWidth + "px", n.style.height = t.querySelector("li:nth-child(" + l + ")").offsetHeight } else { for (l = 1; l <= s.indexOf(a); l++)e += t.querySelector("li:nth-child(" + l + ")").offsetWidth; n.style.transform = "translate3d(" + e + "px, 0px, 0px)", n.style.width = t.querySelector("li:nth-child(" + i + ")").offsetWidth + "px" } } }), window.innerWidth < 991 ? total.forEach(function (e, t) { e.classList.contains("flex-column") || e.classList.add("flex-column", "on-resize") }) : total.forEach(function (e, t) { e.classList.contains("on-resize") && e.classList.remove("flex-column", "on-resize") }) }); const iconNavbarSidenav = document.getElementById("iconNavbarSidenav"), iconSidenav = document.getElementById("iconSidenav"), sidenav = document.getElementById("sidenav-main"); let body = document.getElementsByTagName("body")[0], className = "g-sidenav-pinned"; function toggleSidenav() { body.classList.contains(className) ? (body.classList.remove(className), setTimeout(function () { sidenav.classList.remove("bg-white") }, 100), sidenav.classList.remove("bg-transparent")) : (body.classList.add(className), sidenav.classList.add("bg-white"), sidenav.classList.remove("bg-transparent"), iconSidenav.classList.remove("d-none")) } iconNavbarSidenav && iconNavbarSidenav.addEventListener("click", toggleSidenav), iconSidenav && iconSidenav.addEventListener("click", toggleSidenav); let referenceButtons = document.querySelector("[data-class]"); function navbarColorOnResize() { 1200 < window.innerWidth ? referenceButtons.classList.contains("active") && "bg-transparent" === referenceButtons.getAttribute("data-class") ? sidenav.classList.remove("bg-white") : sidenav.classList.add("bg-white") : (sidenav.classList.add("bg-white"), sidenav.classList.remove("bg-transparent")) } function sidenavTypeOnResize() { var e = document.querySelectorAll('[onclick="sidebarType(this)"]'); window.innerWidth < 1200 ? e.forEach(function (e) { e.classList.add("disabled") }) : e.forEach(function (e) { e.classList.remove("disabled") }) } window.addEventListener("resize", navbarColorOnResize), window.addEventListener("resize", sidenavTypeOnResize), window.addEventListener("load", sidenavTypeOnResize);