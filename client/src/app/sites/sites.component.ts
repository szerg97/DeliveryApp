import { Component, OnInit } from '@angular/core';
import { Site } from '../_models/site';
import { SiteService } from '../_services/site.service';

@Component({
  selector: 'app-sites',
  templateUrl: './sites.component.html',
  styleUrls: ['./sites.component.css']
})
export class SitesComponent implements OnInit {
  sites: Site[];

  constructor(private siteService: SiteService) { }

  ngOnInit(): void {
    this.getSites();
  }

  getSites(){
    this.siteService.getSites().subscribe(sites => {
      this.sites = sites;
      console.log(sites);
    })
  }

}
