$(document).ready(function () {
    loadCart();

    $('input[name="size"], input[name="color"]').change(function () {
        var selectedSizeId = $('input[name="size"]:checked').val();
        var selectedColorId = $('input[name="color"]:checked').val();
        if (selectedSizeId > 0 && selectedColorId > 0) {
            // Send data to server using AJAX in JSON format
            $.ajax({
                type: 'GET',
                url: '/Shop/GetTotalProduct',
                data: {
                    id: $('#productId_Detail').val(),
                    sizeId: selectedSizeId,
                    colorId: selectedColorId
                },

                success: function (response) {
                    console.log(response);
                    var x = response == null ? 0 : response.stock;
                    var html = '';
                    html += `<div class="input-group quantity mr-3" style="width: 130px;">
                                            <div class="input-group-btn">
                                                <label class="text-dark ">Số lượng:</label>
                                                <button class="btn btn-dark btn-minus text-white">
                                                          ${x}
                                                </button>
                                            </div>

                                        </div>`;
                    $('#add_to_cart').show();
                    $('#group_total').html(html);
                    if (response == null || response.stock < 1) {
                        $('#add_to_cart').hide();
                    } else {
                        $('#add_to_cart').data('id', response.pcsid);
                    }


                },
                error: function (xhr, status, error) {
                    MessageError(error, 5000)
                }
            });
        }
    });
    $("#add_to_cart").click(function () {
        var selectedSize = $('input[name="size"]').filter(':checked').val();
        var selectedColor = $('input[name="color"]').filter(':checked').val();
        if (!selectedSize) {
            MessageWarning("Vui lòng chọn size ");
            return;

        }
        if (!selectedColor) {
            MessageWarning("Vui lòng chọn color ");
            return;
        }

        var id = $(this).data('id');
        $.ajax({
            type: 'POST',
            url: '/Cart/AddToCart',
            data: {
                id: id,
                quantity: $('#value_cart').val()
            },

            success: function (response) {
                if (response.status == true) {
                    $('#modalcart').modal('show');
                    loadCart();
                    loadCartCheckout();
                } else {
                    MessageError(response.mess);
                }


            },
            error: function (xhr, status, error) {
                MessageError(error, 5000)
            }
        });
    });




});
function updateCart(id) {
    const inputElement = event.target;
    const quantity = inputElement.value;
    $.ajax({
        type: 'POST',
        url: '/Cart/UpdateToCart',
        data: {
            id: id,
            quantitynew: quantity
        },

        success: function (response) {
            if (response.status == true) {
                loadCart();
                loadCartCheckout();
            } else {
                loadCart();
                MessageError(response.mess);
            }


        },
        error: function (xhr, status, error) {
            MessageError(error, 5000)
        }
    });
}
function DeleteCart(id) {

    $.ajax({
        type: 'POST',
        url: '/Cart/DeleteCart',
        data: {
            id: id,

        },

        success: function (response) {
            if (response.status == true) {
                loadCart();
                loadCartCheckout();
            } else {
                loadCart();
                loadCartCheckout();
                MessageError(response.mess);
            }


        },
        error: function (xhr, status, error) {
            MessageError(error, 5000)
        }
    });
}
function loadCart() {
    $.ajax({
        type: 'GET',
        url: '/Cart/GetCarts',
        success: function (response) {
            console.log(response);
            var lengthcart = response.length;
            $('#length_cart').text(lengthcart);
            if (lengthcart > 0) {
                var html = '';
                const totalCart = response.reduce((accumulator, currentItem) => {
                    return accumulator + currentItem.total;
                }, 0);
                $.each(response, function (index, value) {
                    html += ` <tr>
                                                <td class="align-middle"><img src="/ImageProduct/${value.productImage}" width="100" ></td>
                                            <td class="align-middle">${value.productName}</td>
                                             <td class="align-middle">${formatVND(value.price)}</td>
                                                            <td class="align-middle ">  <input type="number" min="1" max="100" onchange="return updateCart('${value.productCsID}')" class="form-control form-control bg-secondary text-center" value="${value.quantity}" ></td>
                                            <td class="align-middle">${formatVND(value.total)}</td>
                                              <td class="align-middle"><button class="btn btn-danger text-white"onclick = "return DeleteCart('${value.productCsID}')"><i class="fa fa-times"></i></button></td>
                                        </tr>`;
                });
                $('#btn-checkout').show();
                $('#tbody_carts').html(html);
                $('#tfoot_carts').html(` <tr><td colspan="4" class="text-dark">Tổng tiền:</td><td>${formatVND(totalCart)}</td></tr>`);

            } else {
                $('#tbody_carts').html(' <tr> <td>Chưa có sản phẩm nào !  </td></tr> ');
                $('#btn-checkout').hide();
                $('#tfoot_carts').html('');
            }
        },
        error: function (xhr, status, error) {
            MessageError(error, 5000)
        }
    });
}

