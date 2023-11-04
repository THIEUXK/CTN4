$(document).ready(function () {

    //loadCartCheckout();
    //$('#fullname_ck, #andress_ck, #email_ck, #phone_ck').keyup(function () {

    //    $('#mess_fullname').text('');
    //    $('#mess_andress').text('');
    //    $('#mess_phone').text('');
    //    $('#mess_email').text('');

    //});
    //Chọn tỉnh thành
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
                //"service_id":53321,
                //"insurance_value":500000,
                //"coupon": null,
                //"from_district_id":1486,
                //"to_district_id":1493,
                //"to_ward_code":"20314",
                //"height": 25,
                //"length":10,
                //"weight":3000,
                //"width": 30
                service_id: 53321,
                insurance_value: 500000,
                coupon: null,
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
                type: 'POST',
                dataType: 'json',
                data: JSON.stringify(obj),
                contentType: 'application/json',
                success: function (result) {

                    $("#tienship").html(`50,000đ`);
                    $("#tongtien").html(${ formatVND(result.data.totaloder)
                }
                });
            let adress = "," + $("#ward option:selected").text() + "," + $("#district option:selected").text() + "," + $("#provin option:selected").text();
            //add địa chỉ
            $("#adress_detail").val(adress);
        }
    });
}
    });

    //    $('#btn_order').click(function () {
    //        if (validateForm() != false) {


    //            var obj = {
    //                FullName: $('#fullname_ck').val(),
    //                Address: $('#andress_ck').val(),
    //                Phone: $('#phone_ck').val(),
    //                Email: $('#email_ck').val(),
    //                Note: $('#note_ck').val(),
    //            }
    //            $.ajax({
    //                url: '/CheckOut/OrderCheckOut', // đường dẫn tới endpoint của phương thức OrderCheckOut
    //                type: 'POST', // phương thức gửi request là POST
    //                data: JSON.stringify(obj), // chuyển đối tượng order sang định dạng JSON để gửi đi
    //                contentType: 'application/json; charset=utf-8', // loại nội dung gửi đi là JSON
    //                dataType: 'json', // loại dữ liệu trả về là JSON
    //                success: function (result) {
    //                    if (result > 1) {
    //                        // xử lý kết quả trả về từ server
    //                        MessageSucces("Đặt hàng thành công !");
    //                        setTimeout(function () {
    //                            window.location = "/Home";
    //                        }, 3000);
    //                    } else {
    //                        MessageError("Đã có lỗi xảy ra vui lòng thử lại sau", 5000)
    //                    }



    //                },
    //                error: function (error) {
    //                    // xử lý khi có lỗi xảy ra
    //                    MessageError(error, 5000)
    //                }
    //            });
    //        }


    //    });
    //});

    //function validateForm() {
    //    // Kiểm tra họ tên
    //    var fullName = document.getElementById("fullname_ck").value;
    //    if (fullName == "") {
    //        document.getElementById("mess_fullname").innerHTML = "Họ tên không được để trống";
    //        return false;
    //    } else {
    //        document.getElementById("mess_fullname").innerHTML = "";

    //    }

    //    // Kiểm tra địa chỉ
    //    var address = document.getElementById("andress_ck").value;
    //    if (address == "") {
    //        document.getElementById("mess_andress").innerHTML = "Địa chỉ không được để trống";
    //        return false;
    //    }

    //    // Kiểm tra email
    //    var email = document.getElementById("email_ck").value;
    //    var emailPattern = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    //    if (!emailPattern.test(email)) {
    //        document.getElementById("mess_email").innerHTML = "Email không hợp lệ";
    //        return false;
    //    }

    //    // Kiểm tra số điện thoại
    //    var phone = document.getElementById("phone_ck").value;
    //    var phonePattern = /(03|05|07|08|09)+([0-9]{8})\b/g;
    //    if (!phonePattern.test(phone)) {
    //        document.getElementById("mess_phone").innerHTML = "Số điện thoại không hợp lệ!";
    //        return false;
    //    } else {
    //        document.getElementById("mess_phone").innerHTML = "";
    //    }
    //    // Kiểm tra tỉnh/thành
    //    var province = document.getElementById("provin").value;
    //    if (parseInt(province) < 1) {
    //        document.getElementById("mess_provin").innerHTML = "Tỉnh/Thành không được để trống";
    //        return false;
    //    } else {
    //        document.getElementById("mess_provin").innerHTML = "";
    //    }

    //    // Kiểm tra quận/huyện
    //    var district = document.getElementById("district").value;
    //    if (parseInt(district) < 1) {
    //        document.getElementById("mess_district").innerHTML = "Quận/Huyện không được để trống";
    //        return false;
    //    } else {
    //        document.getElementById("mess_district").innerHTML = "";
    //    }



    //    // Kiểm tra phường/xã
    //    var ward = document.getElementById("ward").value;
    //    if (parseInt(ward) < 1) {
    //        document.getElementById("mess_ward").innerHTML = "Phường/Xã không được để trống";
    //        return false;
    //    } else {
    //        document.getElementById("mess_ward").innerHTML = "";
    //    }

    //    return true;
    //}

    //function loadCartCheckout() {
    //    $('#btn_order').show();
    //    $.ajax({
    //        type: 'GET',
    //        url: '/Cart/GetCarts',
    //        success: function (response) {

    //            if (response.length > 0) {

    //                var html = '';
    //                const totalCart = response.reduce((accumulator, currentItem) => {
    //                    return accumulator + currentItem.total;
    //                }, 0);
    //                html += `<h5 class="font-weight-medium mb-3">Sản phẩm</h5>`;
    //                $.each(response, function (index, value) {
    //                    html += ` <div class="d-flex justify-content-between">
    //                        <p>${value.productName} Số lượng: ${value.quantity}</p>
    //                        <p>${formatVND(value.total)}</p>
    //                    </div>`;


    //                });
    //                $('#body_cart_checkout').html(html);

    //                $('#total_checkout').html(`<h5 class="font-weight-bold">Tổng tiền</h5>
    //                        <h5 class="font-weight-bold">${formatVND(totalCart)}</h5> `);
    //            } else {
    //                $('#btn_order').hide();

    //            }

    //        },
    //        error: function (xhr, status, error) {
    //            MessageError(error, 5000)
    //        }
    //    });
});