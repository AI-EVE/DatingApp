import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import {
  NgxGalleryAnimation,
  NgxGalleryImage,
  NgxGalleryOptions,
} from '@kolkov/ngx-gallery';
import { AppUser } from 'src/app/_models/appUser.model';
import { AppUsersService } from 'src/app/_services/app-users.service';

@Component({
  selector: 'app-member-detail',
  templateUrl: './member-detail.component.html',
  styleUrls: ['./member-detail.component.css'],
})
export class MemberDetailComponent {
  appUser: AppUser | null = null;
  galleryOptions: NgxGalleryOptions[] = [];
  galleryImages: NgxGalleryImage[] = [];

  constructor(
    private appUserService: AppUsersService,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.loadUser();

    this.galleryOptions = [
      {
        width: '500px',
        height: '500px',
        thumbnailsColumns: 4,
        imageAnimation: NgxGalleryAnimation.Slide,
        preview: false,
      },
    ];
  }
  getImages() {
    if (!this.appUser) return [];
    const imagesUrls = [];
    for (const photo of this.appUser.photos) {
      imagesUrls.push({
        small: photo.url,
        medium: photo.url,
        big: photo.url,
      });
    }
    return imagesUrls;
  }

  loadUser() {
    const username = this.route.snapshot.paramMap.get('username');
    if (!username) return;
    this.appUserService.getUser(username).subscribe({
      next: (appUser) => {
        this.appUser = appUser;
        this.galleryImages = this.getImages();
      },
    });
  }
}
