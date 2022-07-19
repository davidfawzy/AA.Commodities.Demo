import { Component, OnInit, ViewChild } from '@angular/core';
import { ChartConfiguration, ChartType } from 'chart.js';
import { BaseChartDirective } from 'ng2-charts';
import { CommodityService } from 'src/app/core/services/commodity/commodity.service';

@Component({
  selector: 'app-historical-pnl',
  templateUrl: './historical-pnl.component.html',
  styleUrls: ['./historical-pnl.component.css']
})
export class HistoricalPnlComponent implements OnInit {
  @ViewChild(BaseChartDirective) chart: BaseChartDirective | undefined;
  public lineChartType: ChartType = 'line';
  public lineChartData: ChartConfiguration['data'] = {
    datasets: [
      {
        data: [],
        label: '',
        backgroundColor: 'rgba(148,159,177,0.2)',
        borderColor: 'rgba(148,159,177,1)',
        pointBackgroundColor: 'rgba(148,159,177,1)',
        pointBorderColor: '#fff',
        pointHoverBackgroundColor: '#fff',
        pointHoverBorderColor: 'rgba(148,159,177,0.8)',
        fill: 'origin',
      },
      {
        data: [],
        label: '',
        backgroundColor: 'rgba(77,83,96,0.2)',
        borderColor: 'rgba(77,83,96,1)',
        pointBackgroundColor: 'rgba(77,83,96,1)',
        pointBorderColor: '#fff',
        pointHoverBackgroundColor: '#fff',
        pointHoverBorderColor: 'rgba(77,83,96,1)',
        fill: 'origin',
      },
      {
        data: [],
        label: '',
        yAxisID: 'y-axis-1',
        backgroundColor: 'rgba(255,0,0,0.3)',
        borderColor: 'red',
        pointBackgroundColor: 'rgba(148,159,177,1)',
        pointBorderColor: '#fff',
        pointHoverBackgroundColor: '#fff',
        pointHoverBorderColor: 'rgba(148,159,177,0.8)',
        fill: 'origin',
      }
    ],
    labels: []
  };

  public lineChartOptions: ChartConfiguration['options'] = {
    elements: {
      line: {
        tension: 0.5
      }
    },
    scales: {
      // We use this empty structure as a placeholder for dynamic theming.
      x: {},
      'y-axis-0':
      {
        position: 'left',
      },
      'y-axis-1': {
        position: 'right',
        grid: {
          color: 'rgba(255,0,0,0.3)',
        },
        ticks: {
          color: 'red'
        }
      }
    },
    plugins: {
      legend: { display: true }
    }
  };
  constructor(private commodityService: CommodityService) { }

  ngOnInit() {
    this.commodityService.getPnlYTDMetrics().subscribe((response) => {
      let labels: any[] = [];
      response.forEach((element, index)=>{
        for (var i = 0; i < element.metrics.length; i++) {
          for (var j = 0; j < element.metrics[i].modelResults.length; j++) {
            let date = element.metrics[i].modelResults[j].date;
            let pnl = parseInt(element.metrics[i].modelResults[j].pnlDaily)
            this.lineChartData.datasets[index].data.push(pnl);

            if (!labels.some(x => x == date)) {
               labels.push(date);
             }
          }
        }
      });

      labels.map((e) => this.lineChartData.labels?.push(e));
      this.chart?.update();
    });
  }

}
