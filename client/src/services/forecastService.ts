import axios from "axios";
import { Forecast } from "../types";

export const getForecast = async (city: string): Promise<Forecast[]> => {
  try {
    
    const response = await axios.get<Forecast[]>(`http://localhost:5149/forecast/${city}`);
    const forecast =  response.data;
    return forecast;
  } catch (error) {
    console.log(error)
    return [ ]
  }
}
