import { Photo } from './photo';

export interface AppUser {
  id: number;
  userName: string;
  knownAs: string;
  created: Date;
  lastActive: Date;
  gender: string;
  introduction: string;
  lookingFor: string;
  interests: string;
  city: string;
  country: string;
  photos: Photo[];
  photoUrl: string;
  age: number;
}
