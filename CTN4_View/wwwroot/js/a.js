$(document).ready(function () {

    $(document).on('click', '.btnXuatEx3', function () {
        var arrcheck = [];
        //loadTotal()
        // Get all checkboxes with class form-check-input that are checked
        var checkedCheckboxes = $(".form-check-input:checked");
        checkedCheckboxes.each(function () {
            arrcheck.push(parseInt($(this).val()));
        })
        var obj = {
            IdHD: arrcheck
        }
        //if (checkedCheckboxes.length != 0) {
        console.log(JSON.stringify({ listId: arrcheck }));
        $.ajax({
            url: '/QuanLyHd/XuatEx3',
            type: 'POST',
            dataType: 'json',
            contentType: 'application/json;charset=utf-8',
            data: JSON.stringify(obj),
            success: function (result) {
                debugger
                if (result == "ok") {
                    $("#aaa1").html(`<div class="alert alert-danger" style="background-color:lightgreen;color:black">Xác nhận đơn hàng thành công</div>`);
                }
                else if (result == "that bai 1") {
                    $("#aaa").html(`<div class="alert alert-danger">Có đơn hàng không dủ điều kiện</div>`);
                  
                }
            }
        })
    });
    $(document).on('click', '.btnXuatEx2', function () {
        var arrcheck = [];
        //loadTotal()
        // Get all checkboxes with class form-check-input that are checked
        var checkedCheckboxes = $(".form-check-input:checked");
        checkedCheckboxes.each(function () {
            arrcheck.push(parseInt($(this).val()));
        })
        var obj = {
            IdHD: arrcheck
        }
        //if (checkedCheckboxes.length != 0) {
        console.log(JSON.stringify({ listId: arrcheck }));
        $.ajax({
            url: '/QuanLyHd/XuatEx2',
            type: 'POST',
            dataType: 'json',
            contentType: 'application/json;charset=utf-8',
            data: JSON.stringify(obj),
            success: function (result) {

                if (result.length !== 0) {
                    var files = [];
                    $.each(result, function (key, val) {
                        //debugger
                        //console.log(val);
                        files.push("/ex/" + val);
                    });
                    for (var ii = 0; ii < files.length; ii++) {
                        debugger
                        downloadURL(files[ii]);
                    }
                }
            }
        })
    });

    var count = 0;
    var downloadURL = function downloadURL(url) {
        var hiddenIFrameID = 'hiddenDownloader' + count++;
        var iframe = document.createElement('iframe');
        iframe.id = hiddenIFrameID;
        iframe.style.display = 'none';
        document.body.appendChild(iframe);
        iframe.src = url;
    }

    //$(document).on('click', '.btnXuatEx', function () {
    //    //loadTotal()
    //    var IdHD = this.value;
    //    if (IdHD != null) {
    //        $.ajax({
    //            url: '/QuanLyHd/XuatEx',
    //            type: 'GET',
    //            dataType: 'json',
    //            data: {
    //                IdHD: IdHD
    //            },
    //            contentType: 'application/json',
    //            success: function (result) {
    //                if (result != null) {
    //                    debugger
    //                    location.href = "/ex/" + result;
    //                }
    //            }
    //        });
    //    }
    //    else {
    //        location.reload();
    //    }
    //});
    $('#provin').change(function () {
        //loadTotal();
        var id_provin = this.value;

        $('#district option').remove();
        $('#district').append(new Option("-- Chọn quận/huyện --", 0));
        $('#ward option').remove();
        $('#ward').append(new Option("-- Chọn phường/xã --", 0));
        if (this.value != 0) {
            $.ajax({
                url: '/CheckOut/GetListDistrict',
                type: 'GET',
                dataType: 'json',
                data: {
                    idProvin: id_provin

                },
                contentType: 'application/json',
                success: function (result) {

                    $.each(result.data, function (key, val) {
                        $("#district").append(new Option(val.DistrictName, val.DistrictID));
                    });
                }
            });
        }
    });
    //Chọn quận huyện
    $('#district').change(function () {
        //loadTotal();
        var id_ward = this.value;
        $('#ward option').remove();
        $('#ward').append(new Option("-- Chọn phường/xã --", 0));

        if (this.value != 0) {

            $.ajax({
                url: '/CheckOut/GetListWard',
                type: 'GET',
                dataType: 'json',
                data: {
                    idWard: id_ward

                },
                contentType: 'application/json',
                success: function (result) {

                    $.each(result.data, function (key, val) {
                        $("#ward").append(new Option(val.WardName, val.WardCode));
                    });

                }

            });


        }

    });
    //Tính phí ship
    //Chọn xã
    $('#ward').change(function () {
        var id_ward = this.value;
        sessionStorage.removeItem('shiptotal');
        $("#total_ship").text('');
        if (this.value != 0) {
            var obj = {
                service_id: 53321,
                insurance_value: 500000,
                from_district_id: 3440,
                to_ward_code: id_ward,
                to_district_id: parseInt($('#district').val()),
                weight: 1000,
                length: 31,
                height: 21,
                width: 11,
            }
            $.ajax({
                url: '/CheckOut/GetTotalShipping',
                type: 'Post',
                dataType: 'json',
                data: JSON.stringify(obj),
                contentType: 'application/json',
                success: function (result) {
                    if (result.message == "False") {
                        $("#adressnew").val(`Địa chỉ này hiện không hỗ trợ ship`);
                    }
                    else {
                        var x1 = result.data.total;
                        x1 = x1.toLocaleString('it-IT', { style: 'currency', currency: 'VND' });
                        var x2 = result.data.totaloder;
                        x2 = x2.toLocaleString('it-IT', { style: 'currency', currency: 'VND' });

                        $("#tienship").html(`${(x1)}`);
                        $("#tongtien").html(` ${(x2)}`);
                        $("#tienship1").val(result.data.total);
                        $("#tongtien1").val(result.data.totaloder);
                        let adress = $("#ward option:selected").text() + "," + $("#district option:selected").text() + "," + $("#provin option:selected").text();
                        //add địa chỉ
                        $("#diachinay").val(adress).html(`${(adress)}`);
                        $("#adressnew").val(adress).html(`${(adress)}`);
                    }

                }
            });
        }
    });
    $('#diachicosan').change(function () {
        //loadTotal();

        var idDiaChi = this.value;
        if (idDiaChi != 0) {
            $.ajax({
                url: '/CheckOut/chonDiaChi',
                type: 'GET',
                dataType: 'json',
                data: {
                    idDiaChiKD: idDiaChi

                },
                contentType: 'application/json',
                success: function (result) {
                    var x1 = result.TienShip;
                    x1 = x1.toLocaleString('it-IT', { style: 'currency', currency: 'VND' });
                    var x2 = result.totaloder;
                    x2 = x2.toLocaleString('it-IT', { style: 'currency', currency: 'VND' });

                    let adress = $("#diachicosan option:selected").text();
                    $("#tienship").html(`${(x1)}`);
                    $("#tongtien").html(` ${(x2)}`);
                    $("#tienship1").val(result.TienShip);
                    $("#tongtien1").val(result.totaloder);
                    $("#diachinay").val(adress).html(`${(adress)}`);
                    $("#adressnew").val(adress).html(`${(adress)}`);
                }
            });
        }
        else {
            location.reload();
        }


    });
    //$('#themdiachi').click(function () {
    //    //loadTotal();
    //    var obj = {
    //        DiaChi=$('#diachinay').val(),
    //        tiennhip=$('#tienship1').val()
    //    }
    //    $.ajax({
    //        url: '/CheckOut/ThemDiaChi',
    //        type: 'Post',
    //        dataType: 'json',
    //        data: JSON.stringify(obj),
    //        contentType: 'application/json',
    //        success: function (result) {
    //            let adress = $("#diachicosan option:selected").text();
    //            $("#tienship").html(`${formatVND(52000)}`);
    //            $("#tongtien").html(` ${formatVND(result)}đ`);
    //            $("#tienship1").val(52000);
    //            $("#tongtien1").val(result);
    //            $("#diachinay").val(adress).html(`${(adress)}`);
    //            $("#adressnew").val(adress).html(`${(adress)}`);
    //        }
    //    });




    //});

});