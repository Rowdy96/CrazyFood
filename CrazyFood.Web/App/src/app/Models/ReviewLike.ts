import { UserAC } from './UserAC';

export class ReviewLike {
  id: number;
  userId: string;
  reviewId: number;
  //public Review Review{ get; set; }
  user: UserAC;
}
