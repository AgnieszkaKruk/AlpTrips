
    $(document).ready(function () {
        var apiKey = '24456521918244a590a194429231506';
        var latitude = @Model.Latitude; // pobierz szerokoœæ geograficzn¹ góry z Modelu
        var longitude = @Model.Longitude; // pobierz d³ugoœæ geograficzn¹ góry z Modelu

        var apiUrl = 'https://api.weatherapi.com/v1/current.json?key=' + apiKey + '&q=' + latitude + ',' + longitude;

        $.ajax({
            url: apiUrl,
            method: 'GET',
            success: function (response) {
                var weatherData = response.current;
                var temperature = weatherData.temp_c;
                var precipitation = weatherData.precip_mm;
                var windSpeed = weatherData.wind_kph;
                var iconUrl = weatherData.condition.icon;

                // Zaktualizuj okienko z pogod¹ na stronie
                $('#weather').html('Aktualna temperatura: ' + temperature + '°C, Si³a wiatru: ' + windSpeed + ' km/h, Opady: ' + precipitation + ' mm');
                $('#weather-icon').attr('src', 'https:' + iconUrl);
                $('#weather-icon').attr('src', 'https:' + iconUrl);
            },
            error: function (error) {
                console.log(error);
            }
        });
    });

    $(document).ready(function () {
        var apiKey = '24456521918244a590a194429231506';
        var latitude = @Model.Latitude; // pobierz szerokoœæ geograficzn¹ góry z Modelu
        var longitude = @Model.Longitude; // pobierz d³ugoœæ geograficzn¹ góry z Modelu

        var apiUrl = 'https://api.weatherapi.com/v1/forecast.json?key=' + apiKey + '&q=' + latitude + ',' + longitude + '&days=7';

        $.ajax({
            url: apiUrl,
            method: 'GET',
            success: function (response) {
                var forecastData = response.forecast;
                var forecastHtml = '';

                for (var i = 1; i < forecastData.forecastday.length; i++) {
                    var forecastDay = forecastData.forecastday[i];
                    var date = forecastDay.date;
                    var maxTemp = forecastDay.day.maxtemp_c;
                    var minTemp = forecastDay.day.mintemp_c;
                    var condition = forecastDay.day.condition.text;
                    var iconUrl = forecastDay.day.condition.icon;
                    var windStrength = forecastDay.day.maxwind_kph;
                    var precipitation = forecastDay.day.totalprecip_mm;

                    forecastHtml += '<div class="forecast-day">';
                    forecastHtml += '<p style="margin-bottom: 5px;" class="forecast-date">' + date + '</p>';
                    forecastHtml += '<img class="forecast-icon" src="https:' + iconUrl + '" alt="Weather Icon">';
                    forecastHtml += '<p  style="text-align: left;margin-bottom: 5px;"" class="forecast-temperature">Max: ' + maxTemp + '°C, Min: ' + minTemp + '°C</p>';
                    forecastHtml += '<p style="text-align: left;margin-bottom: 5px;"" class="forecast-wind">Wiatr: ' + windStrength + ' km/h</p>';
                    forecastHtml += '<p style="text-align: left;margin-bottom: 5px;"" class="forecast-precipitation">Opady: ' + precipitation + ' mm</p>';
forecastHtml += '</div>';
                }

// Wyœwietl prognozê na stronie
$('#weekly-weather').html(forecastHtml);
            },
error: function (error) {
    console.log(error);
}
        });
    });

