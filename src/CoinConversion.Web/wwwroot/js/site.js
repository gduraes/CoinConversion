(function ($) {
    function processForm(e) {

        

        if ($('#ValueOrigin').val() !== "") {
            
            console.log($('#ValueOrigin').val());

            var rate = {
                ValueOrigin: $('#ValueOrigin').val(),
                ApiKey: "7795e574f6c9677966aeacf39e496503",
                FormatMsg: 1,
                CurrencyDestination: $('#CurrencyDestination').val(),
                CurrencyOrigin: $('#CurrencyOrigin').val()
            };

            console.log(rate);
            
            $.ajax({
                url: 'http://localhost:53267/api/calculaterates',
                type: 'post',
                crossDomain: true,
                dataType: 'json',
                contentType: 'application/json',
                data: JSON.stringify(rate),
                success: function (data, textStatus, jQxhr) {
                    console.log(data);
                    $('#responseResult').html(
                        $('#CurrencyDestination').val() + ' ' + $('#ValueOrigin').val() / data
                    );
                },
                error: function (jqXhr, textStatus, errorThrown) {
                    console.log(errorThrown);
                }
            });
            
        } else {
            alert("Preencha o valor");
            $('#ValueOrigin').focus(); 
        }

        e.preventDefault();
    }

    $('#my-form').submit(processForm);
})(jQuery);