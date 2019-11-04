import { UserAC } from './UserAC';

export class FollowAC {
  Id: number
  FollowingUserId: string
  FollowingUser: UserAC
  FollowedUserId: string
  FollowedUser: UserAC
  IsFollowed: boolean
}
