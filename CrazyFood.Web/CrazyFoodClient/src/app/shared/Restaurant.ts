import { City } from '../shared/City';
import { AverageRating } from '../shared/AverageRating';

export class Restaurant{
    id: number;
    name:string ;
    PhoneNumber :string ;
    emailId: string ;
    averageCost:number;
    openingHours :string ;
    restaurantLocation:string ;
    hasOnlineBooking:boolean;
    cityId:number;
    city : City;
    averageRating:AverageRating;
}