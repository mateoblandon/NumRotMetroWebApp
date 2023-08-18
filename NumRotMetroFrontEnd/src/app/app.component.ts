import { Component, OnInit, ViewChild } from '@angular/core';
import { Chart } from 'chart.js/auto';
import { ApiService } from './services/api/api.service';
import { RegistroDeBaseDeDatosI } from './Models/registro-de-base-de-datos.model';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent implements OnInit {
  title = 'NumRotMetroFrontEnd';
  
  constructor(private apiService:ApiService) {}

  ngOnInit(): void {
    this.apiService.RecuperarRegistros().subscribe(data => {console.log(data)});
  }

  canvas: any;
    ctx: any;
    @ViewChild('mychart') mychart: any;

    ngAfterViewInit() {
        this.canvas = this.mychart.nativeElement;
        this.ctx = this.canvas.getContext('2d');

        new Chart(this.ctx, {
            type: 'doughnut',
            options: {
              cutout: "70%"
            },
            data: {
                datasets: [{
                  label: 'My First Dataset',
                  data: [300, 50, 100],
                  backgroundColor: [
                    'rgb(255, 99, 132)',
                    'rgb(54, 162, 235)',
                    'rgb(255, 205, 86)'
                  ],
                }],
                labels: ['Red',
                'Blue',
                'Yellow'],
            },
        });
    }

}