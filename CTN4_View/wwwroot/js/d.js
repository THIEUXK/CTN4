$(document).ready(function () {

    $("#first").on("input", function () {
        debugger
        var value = $(this).val();
        validateName(value, 'first');
    });

    function validateName(value, inputId) {
        var specialChars = /[!@#$%^&*()_+\-=\[\]{};':"\\|,.<>\/?]+/;

        if (specialChars.test(value)) {
            // Hiển thị thông báo lỗi
            $("#nameError").text("Tên không được chứa ký tự đặc biệt!");
            // Xóa giá trị nhập vào
            $("#" + inputId).val("");
        } else {
            // Nếu tên hợp lệ, xóa thông báo lỗi
            $("#nameError").text("");
        }
    }
    // validateEmail.js
    $(document).ready(function () {
        $('#email').on('input', function () {
            debugger
            validateEmail();
        });

        function validateEmail() {
            var emailInput = $('#email');
            var emailError = $('#email-error');

            // Kiểm tra định dạng email
            var emailRegex = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;
            var isValid = emailRegex.test(emailInput.val());

            // Hiển thị thông báo nếu định dạng không hợp lệ
            if (!isValid) {
                emailError.html('Vui lòng nhập một địa chỉ email hợp lệ.');
            } else {
                emailError.html(''); // Xóa thông báo nếu định dạng hợp lệ
                // Thực hiện các hành động khác nếu cần
            }
        }
    });
    $(document).ready(function () {
        $("#nhangiamgia").click(function () {
            var couponCode = $("#nhapgiamgia").val();

            // Thực hiện yêu cầu Ajax
            $.ajax({
                type: "POST", // Hoặc "GET" tùy thuộc vào yêu cầu của bạn
                url: "path/to/your/api", // Đường dẫn tới API xử lý coupon code
                data: { couponCode: couponCode },
                success: function (response) {
                    // Xử lý phản hồi từ server nếu cần
                    console.log(response);

                    // Ví dụ: Hiển thị thông báo cho người dùng
                    alert("Coupon applied successfully!");
                },
                error: function (error) {
                    // Xử lý lỗi nếu có
                    console.log(error);

                    // Ví dụ: Hiển thị thông báo lỗi cho người dùng
                    alert("Error applying coupon. Please try again.");
                }
            });
        });
    });
    $(document).on('click', '.btnXuatEx3', function () {
        var isConfirmed = confirm("Bạn có chắc chắn muốn xác nhận đơn hàng?");

        // Nếu người dùng xác nhận, thực hiện hành động xuất File Excel
        if (isConfirmed) {
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
            if (arrcheck.length > 0) {
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
            } else {
                console.log('Không có sản phẩm được chọn.');
                $('#alertMessage').addClass('red-alert').html('Không có sản phẩm nào được chọn. Vui lòng chọn ít nhất một sản phẩm để tiếp tục.').show();
                // Nếu không có sản phẩm được chọn, có thể hiển thị thông báo hoặc thực hiện hành động khác mà bạn muốn
                // Ngăn chặn sự kiện mặc định của nút để tránh chuyển trang
                return false;
            }
        }

    });
    $(document).on('click', '.btnXuatEx5', function () {
        var isConfirmed = confirm("Bạn có chắc chắn muốn ẩn đơn hàng?");

        // Nếu người dùng xác nhận, thực hiện hành động xuất File Excel
        if (isConfirmed) {
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
            if (arrcheck.length > 0) {
                console.log(JSON.stringify({ listId: arrcheck }));
                $.ajax({
                    url: '/QuanLyHd/AnHD',
                    type: 'POST',
                    dataType: 'json',
                    contentType: 'application/json;charset=utf-8',
                    data: JSON.stringify(obj),
                    success: function (result) {
                        debugger
                        if (result == "ok") {
                            location.reload()
                            $("#aaa1").html(`<div class="alert alert-danger" style="background-color:lightgreen;color:black">Ẩn đơn hàng thành công</div>`);
                        }

                        else if (result == "that bai 1") {
                            $("#aaa").html(`<div class="alert alert-danger">Có đơn hàng không dủ điều kiện</div>`);

                        }
                    }
                })
            } else {
                console.log('Không có sản phẩm được chọn.');
                $('#alertMessage').addClass('red-alert').html('Không có sản phẩm nào được chọn. Vui lòng chọn ít nhất một sản phẩm để tiếp tục.').show();
                // Nếu không có sản phẩm được chọn, có thể hiển thị thông báo hoặc thực hiện hành động khác mà bạn muốn
                // Ngăn chặn sự kiện mặc định của nút để tránh chuyển trang
                return false;
            }
        }

    });
    $(document).on('click', '.btnXuatEx6', function () {
        var isConfirmed = confirm("Bạn có chắc chắn muốn hiện đơn hàng?");

        // Nếu người dùng xác nhận, thực hiện hành động xuất File Excel
        if (isConfirmed) {
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
            if (arrcheck.length > 0) {
                console.log(JSON.stringify({ listId: arrcheck }));
                $.ajax({
                    url: '/QuanLyHd/HienHD',
                    type: 'POST',
                    dataType: 'json',
                    contentType: 'application/json;charset=utf-8',
                    data: JSON.stringify(obj),
                    success: function (result) {
                        debugger
                        if (result == "ok") {
                            location.reload()
                            $("#aaa1").html(`<div class="alert alert-danger" style="background-color:lightgreen;color:black">Hiện đơn hàng thành công</div>`);
                        }
                        else if (result == "that bai 1") {
                            $("#aaa").html(`<div class="alert alert-danger">Có đơn hàng không dủ điều kiện</div>`);

                        }
                    }
                })
            } else {
                console.log('Không có sản phẩm được chọn.');
                $('#alertMessage').addClass('red-alert').html('Không có sản phẩm nào được chọn. Vui lòng chọn ít nhất một sản phẩm để tiếp tục.').show();
                // Nếu không có sản phẩm được chọn, có thể hiển thị thông báo hoặc thực hiện hành động khác mà bạn muốn
                // Ngăn chặn sự kiện mặc định của nút để tránh chuyển trang
                return false;
            }
        }

    });
    $(document).on('click', '.btnXuatEx2', function () {
        var isConfirmed = confirm("Bạn có chắc chắn muốn xuất File Excel?");

        // Nếu người dùng xác nhận, thực hiện hành động xuất File Excel
        if (isConfirmed) {
            // Gọi hàm hoặc thực hiện code để xuất File Excel
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
            if (arrcheck.length > 0) {
                console.log(JSON.stringify({ listId: arrcheck }));
                $.ajax({
                    url: '/QuanLyHd/XuatEx2',
                    type: 'POST',
                    dataType: 'json',
                    contentType: 'application/json;charset=utf-8',
                    data: JSON.stringify(obj),
                    success: function (result) {
                        debugger

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
            } else {
                console.log('Không có sản phẩm được chọn.');
                $('#alertMessage').addClass('red-alert').html('Không có sản phẩm nào được chọn. Vui lòng chọn ít nhất một sản phẩm để tiếp tục.').show();
                // Nếu không có sản phẩm được chọn, có thể hiển thị thông báo hoặc thực hiện hành động khác mà bạn muốn
                // Ngăn chặn sự kiện mặc định của nút để tránh chuyển trang
                return false;
            }
        }

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
        var tienhangaValue = $('#tienhanga').val();
        var tiengiamaValue = $("#tiengiam1").val();
        var tongtienValue = $("#tongtien1").val();
        var idDon = $("#idDon").val();
        debugger
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
                tienhang: tienhangaValue,
                tiengiam: tiengiamaValue,
                tongtien: tongtienValue,
                idDon: idDon,
            }
            debugger
            $.ajax({
                url: '/CheckOut/GetTotalShipping2',
                type: 'POST',
                dataType: 'json',
                data: JSON.stringify(obj),
                contentType: 'application/json',
                success: function (result) {
                    debugger
                    if (result.message == "False") {
                        $("#adressnew").val(`Địa chỉ này hiện không hỗ trợ ship`);
                    }
                    else {
                        if (result.data.totaloder < 1) {
                            result.data.totaloder = 0
                        }
                        var x1 = result.data.total;
                        x1 = x1.toLocaleString('it-IT', { style: 'currency', currency: 'VND' });
                        var x2 = result.data.totaloder;
                        x2 = x2.toLocaleString('it-IT', { style: 'currency', currency: 'VND' });
                        var x3 = result.tienGiam;
                        x3 = x3.toLocaleString('it-IT', { style: 'currency', currency: 'VND' });
                        $("#tienship").html(`${(x1)}`);
                        $("#tongtien").html(` ${(x2)}`);
                        $("#tiengiam").html(` ${(x3)}`);
                        debugger
                        $("#tienship1").val(result.data.total);
                        $("#tongtien1").val(result.data.totaloder);
                        $("#tiengiam1").val(result.tienGiam);
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
        var tienhangaValue = $('#tienhanga').val();
        var tiengiamaValue = $("#tiengiam1").val();
        var tongtienValue = $("#tongtien1").val();
        debugger
        if (idDiaChi != 0) {
            $.ajax({
                url: '/CheckOut/chonDiaChi',
                type: 'GET',
                dataType: 'json',
                data: {
                    idDiaChiKD: idDiaChi,
                    tienhang: tienhangaValue,
                    tiengiam: tiengiamaValue,
                    tongtien: tongtienValue,
                },
                contentType: 'application/json',
                success: function (result) {
                    debugger
                    if (result.totaloder < 1) {
                        result.totaloder = 0
                    }
                    var x1 = result.TienShip;
                    x1 = x1.toLocaleString('it-IT', { style: 'currency', currency: 'VND' });
                    var x2 = result.totaloder;
                    x2 = x2.toLocaleString('it-IT', { style: 'currency', currency: 'VND' });
                    var x3 = result.tienGiam;
                    x3 = x3.toLocaleString('it-IT', { style: 'currency', currency: 'VND' });
                    $("#tiengiam").html(` ${(x3)}`);
                    debugger
                    $("#tiengiam1").val(result.tienGiam);
                    $("#tienship").html(`${(x1)}`);
                    $("#tongtien").html(` ${(x2)}`);
                    $("#tienship1").val(result.TienShip);
                    $("#tongtien1").val(result.totaloder);
                    let adress = $("#diachicosan option:selected").text();
                    $("#addct").val(result.DiaChichiTiet).html(`${(result.DiaChichiTiet)}`);
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
// validateEmail.js


