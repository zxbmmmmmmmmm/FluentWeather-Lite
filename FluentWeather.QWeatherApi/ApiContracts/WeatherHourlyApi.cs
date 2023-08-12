﻿using FluentWeather.QWeatherApi.Bases;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json.Serialization;

namespace FluentWeather.QWeatherApi.ApiContracts;

public class WeatherHourlyApi: QApiContractBase<WeatherHourlyResponse>
{
    public override HttpMethod Method => HttpMethod.Get;
    public override string Url => ApiConstants.Weather.HourlyForecast168H;
}
public class WeatherHourlyResponse : QWeatherResponseBase
{
    [JsonPropertyName("hourly")] public List<HourlyForecastItem> HourlyForecasts { get; set; }
    public class HourlyForecastItem
    {
        [JsonPropertyName("fxTime")]
        public string FxTime { get; set; }

        [JsonPropertyName("temp")]
        public string Temp { get; set; }

        [JsonPropertyName("icon")]
        public string Icon { get; set; }

        [JsonPropertyName("text")]
        public string Text { get; set; }

        [JsonPropertyName("wind360")]
        public string Wind360 { get; set; }

        [JsonPropertyName("windDir")]
        public string WindDir { get; set; }

        [JsonPropertyName("windScale")]
        public string WindScale { get; set; }

        [JsonPropertyName("windSpeed")]
        public string WindSpeed { get; set; }

        [JsonPropertyName("humidity")]
        public string Humidity { get; set; }

        [JsonPropertyName("pop")]
        public string Pop { get; set; }

        [JsonPropertyName("precip")]
        public string Precipitation { get; set; }

        [JsonPropertyName("pressure")]
        public string Pressure { get; set; }

        [JsonPropertyName("cloud")]
        public string Cloud { get; set; }

        [JsonPropertyName("dew")]
        public string Dew { get; set; }
    }

}