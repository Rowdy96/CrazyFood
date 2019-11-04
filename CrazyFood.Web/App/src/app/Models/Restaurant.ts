import { City } from './City';
import { AverageRating } from './AverageRating';

export class Restaurant{
    Id : number
    Name : string 
    PhoneNumber:string 
    EmailId:string
    AverageCost:number
    OpeningHours:string 
    RestaurantLocation:string 
    HasOnlineBooking:boolean
    CityId : number
    City :City
    AverageRating:AverageRating
}
