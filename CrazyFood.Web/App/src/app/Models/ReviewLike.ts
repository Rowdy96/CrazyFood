import { UserAC } from './UserAC';

export class ReviewLike {
  Id: number;
  UserId: string;
  ReviewId: number;
  //public Review Review{ get; set; }
  User: UserAC;
}
