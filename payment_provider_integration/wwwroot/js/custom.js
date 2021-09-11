

$(document).ready(function () {
    $("#send").click(function (event) {
        console.log("Send clicked");
        var formData = {
            orderId: $("#orderId").val(),
            amount: $("#amount").val(),
            currency: $("#currency").val(),
            country: $("#country").val(),
            cardNumber: $("#cardNumber").val(),
            cardHolder: $("#cardHolder").val(),
            cardExpiryDate: $("#cardExpiryDate").val(),
            cvv: $("#cvv").val(),
        };

        console.log("Data collected");
        if (formData) {
            console.log("Before ajax");
            $.ajax({
                type: "POST",
                //url: "api/payments/create-payment",
                url: "/Home/CreatePayment/",
                data: JSON.stringify(formData),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                //timeout: 10000,
                success: function (data) {
                    console.log(data);
                    //var mydata = data.Result;
                    if (data.isSuccessStatusCode) {

                        console.log("Before css");
                        $("#creditCard").addClass("invisible");
                        $("#formSubmit").removeClass("invisible");
                        console.log("After css");

                        //$("#transaction").val(data.result.transactionId);
                        $("#paReqHtml").val(data.result.paReq);

                    }
                }
            })
        }

    })
});

