$(document).ready(function () {
   
    GetAllHotel();
    GetAll();
    GetAllContactType();
});

function GetAllHotel() {
    var ss = "<option value=0>select Hotel</option>";
    $.get("/Settings/GetAllHotel", function (data) {
        $.each(data, function (i, j) {
            ss = ss + "<option value=" + j.id + ">" + j.nameAr + "</option>";
        });
        $("#hotelid").html(ss);
        //$("#hotelId").html(ss);
        //$("#hotelIdd").html(ss);
        alert("This action has been saved !");
    });
}


function GetAll() {
    var ss = "<option value=0>select</option>";
    $.get("/Settings/GetCityOnly", function (data) {
        $.each(data, function (i, j) {
            ss = ss + "<option value=" + j.id + ">" + j.nameAr + "</option>";
        });
        $("#cityId").html(ss);
        $("#cityIdd").html(ss);
    });
}

function GetAllContactType() {
    var ss = "<option value=0>select contact Type</option>";
    $.get("/Settings/GetAllContactType", function (data) {
        $.each(data, function (i, j) {
            ss = ss + "<option value=" + j.id + ">" + j.nameAr + "</option>";
        });
        $("#contactTypeId").html(ss);

    });
}

function GetVendor() {

    var id = $("#hotelid").val();
    if (id > 0) {
        var ss = "";
        $.get("/Settings/GetAllVendorInHotel/" + id, function (data) {
            $.each(data, function (i, j) {
                ss = ss + "<tr>";
                ss = ss + "<td class='align-middle text-center text-sm'>" + (i + 1) + "</td>";
                ss = ss + "<td class='align-middle text-center text-sm'>" + j.nameAr + "</td>";
                ss = ss + "<td class='align-middle text-center text-sm'>" + j.nameEn + "</td>";
                ss = ss + "<td class='align-middle text-center text-sm'>" + j.vatNo + "</td>";
                ss = ss + "<td class='align-middle text-center text-sm'>" + j.responsableName + "</td>";
                ss = ss + "<td class='align-middle text-center text-sm'>" + j.addressAr + "</td>";
                ss = ss + "<td class='align-middle text-center text-sm'>" + j.addressEn + "</td>";
                ss = ss + "<td class='align-middle text-center text-sm'><button   id='EditForm'    data-bs-toggle='modal' data-bs-target='#EditModal'    class='card-link btn text-center w-30 mx-2 mx-2 edit' onclick='EditForm(" + j.id + ")'><i class='fa-solid fa-pen' aria-hidden='true'></i></button></td>";
                ss = ss + "<td class='float-end me-4'><button   id='DeleteForm'  data-bs-toggle='modal' data-bs-target='#DeleteModal'  class='btn btn-link text-danger text-gradient px-3 mb-0' onclick='DeleteForm(" + j.id + ")'><i class='fa-regular fa-trash-can me-2' aria-hidden='true'></i></button></td>";
                ss = ss + "<td><button   id='contactForm'    data-bs-toggle='modal' data-bs-target='#contactModal'    class='btn btn-danger' > Addcontact </button></td>";
                ss = ss + "</tr>";
                $("#vendorid").val(j.id);
            });
            $("#tbody").html(ss);
        });
    }
}


function EditForm(id) {
    $.ajax({
        type: "POST",
        url: "/Settings/GetVendor",
        data: { id: id },
        success: function (Vendor) {
            console.log(Vendor);

            $("#namear").val(Vendor.nameAr);
            $("#nameen").val(Vendor.nameEn);
            $("#vatNo").val(Vendor.vatNo);
            $("#addressAr").val(Vendor.addressAr);
            $("#addressEn").val(Vendor.addressEn);
            $("#responsableName").val(Vendor.responsableName);
            $("#cityId").val(Vendor.cityId);
            $("#hotelId").val(Vendor.hotelId);

            $("#id").val(Vendor.id)
        }
    })


}

function DeleteForm(id) {
    $.ajax({
        type: "POST",
        url: "/Settings/GetVendor",
        data: { id: id },
        success: function (Vendord) {
            console.log(Vendord);

            $("#nameard").val(Vendord.nameAr);
            $("#nameend").val(Vendord.nameEn);
            $("#vatNod").val(Vendord.vatNo);
            $("#addressArd").val(Vendord.addressAr);
            $("#addressEnd").val(Vendord.addressEn);
            $("#responsableNamed").val(Vendord.responsableName);
            $("#cityIdd").val(Vendord.cityId);
            $("#hotelIdd").val(Vendord.hotelId);

            $("#idd").val(Vendord.id)
        }
    })


}


$('#saveme').click(function () {
    var jsonData = {

        Value: $("#value").val(),
        Description: $("#description").val(),
        ContactTypeId: $("#contactTypeId").val(),
        VendorId: $("#vendorid").val(),
        Id: $("#contactid").val(),

    }
    $.post("/Settings/UpdateVendorContact", jsonData, function (res) {

        alert("This action has been saved !");

    });


});

function clearform() {
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


function clearcontactmodal() {

    $("#value").val("");
    $("#description").val("");
    $("#contactTypeId").val(0);
    $("#vendorid").val(0);
    $("#contactid").val(0);

}




