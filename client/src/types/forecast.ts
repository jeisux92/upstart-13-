export interface Forecast {
    number:                     number;
    name:                       string;
    startTime:                  Date;
    endTime:                    Date;
    isDaytime:                  boolean;
    temperature:                number;
    temperatureUnit:            string;
    temperatureTrend:           null;
    probabilityOfPrecipitation: Dewpoint;
    dewpoint:                   Dewpoint;
    relativeHumidity:           Dewpoint;
    windSpeed:                  string;
    windDirection:              string;
    icon:                       string;
    shortForecast:              string;
    detailedForecast:           string;
}

export interface Dewpoint {
    unitCode: string;
    value:    number | null;
}



