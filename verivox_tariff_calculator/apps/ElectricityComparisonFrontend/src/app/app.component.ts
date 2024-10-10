import { Component, OnInit } from '@angular/core';
import { RouterModule } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { DataService } from '../service/DataService';
import { TariffInformation } from '../dtos/TariffInformation';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { MatCardModule } from '@angular/material/card'
import { MatFormFieldModule } from '@angular/material/form-field'
import { MatListModule } from '@angular/material/list'
import { MatButtonModule } from '@angular/material/button'
import { MatInputModule } from '@angular/material/input'

const appImports = [
  RouterModule, 
  CommonModule, 
  FormsModule,
  MatCardModule,
  MatFormFieldModule,
  MatListModule,
  MatButtonModule,
  MatInputModule
]
@Component({
  standalone: true,
  imports: appImports,
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

