import { City } from './City';
import { AverageRating } from './AverageRating';

export class Restaurant{
    id : number
    name : string 
    phoneNumber:string 
    emailId:string
    averageCost:number
    openingHours:string 
    restaurantLocation:string 
    hasOnlineBooking:boolean
    cityId : number
    city :City
    averageRating:AverageRating
}
