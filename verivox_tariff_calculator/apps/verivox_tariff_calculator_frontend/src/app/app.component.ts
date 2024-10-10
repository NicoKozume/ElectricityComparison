import { Component, OnInit } from '@angular/core';
import { RouterModule } from '@angular/router';
import { NxWelcomeComponent } from './nx-welcome.component';
import { HttpClient } from '@angular/common/http';
import { DataService } from '../service/DataService';
import { TariffInformation } from '../dtos/TariffInformation';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  standalone: true,
  imports: [NxWelcomeComponent, RouterModule, CommonModule, FormsModule],
  providers: [HttpClient],
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss',
})
export class AppComponent {
  consumption: number = 0;
  tariffs: TariffInformation[] = [];

   constructor(private dataService: DataService){}


   compareTariffs() {
    this.dataService.getTariffs(this.consumption).subscribe(data => {
      this.tariffs = data;
    });
  }
}
