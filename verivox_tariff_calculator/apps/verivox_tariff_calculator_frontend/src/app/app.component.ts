import { Component, OnInit } from '@angular/core';
import { RouterModule } from '@angular/router';
import { NxWelcomeComponent } from './nx-welcome.component';
import { HttpClient } from '@angular/common/http';

@Component({
  standalone: true,
  imports: [NxWelcomeComponent, RouterModule],
  providers: [HttpClient],
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss',
})
export class AppComponent implements OnInit {
  title = 'verivox_tariff_calculator_frontend';
   constructor(private http: HttpClient){}

   ngOnInit(): void {
    this.http.get('api/WeatherForecast').subscribe(x => console.info(x));
   }

}
