import { preserveWhitespacesDefault } from '@angular/compiler';
import { Component, OnInit, ViewChild } from '@angular/core';
import { ChartConfiguration, ChartData, ChartType } from 'chart.js';
import { BaseChartDirective } from 'ng2-charts';
import { CommodityService } from 'src/app/core/services/commodity/commodity.service';

@Component({
  selector: 'app-commodity-metrics',
  templateUrl: './commodity-metrics.component.html',
  styleUrls: ['./commodity-metrics.component.scss']
})
export class CommodityMetricsComponent implements OnInit {
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
      response.forEach((element, index) => {
        this.lineChartData.datasets[index].label = element.name;
        for (var i = 0; i < element.metrics.length; i++) {
          let year = element.metrics[i].year;
          let pnl = parseInt(element.metrics[i].cummulativePnl)
          if (!labels.some(x => x == year)) {
            labels.push(year);
          }
          this.lineChartData.datasets[index].data.push(pnl);
        }
      });
      labels.map((e) => this.lineChartData.labels?.push(e));
      this.chart?.update();
    });
  }

}
