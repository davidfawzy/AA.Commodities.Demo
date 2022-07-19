import { Component, OnInit, ViewChild } from '@angular/core';
import { ChartData, ChartType } from 'chart.js';
import { BaseChartDirective } from 'ng2-charts';
import { ModelService } from 'src/app/core/services/model/model.service';

@Component({
  selector: 'app-model-commodities',
  templateUrl: './model-commodities.component.html',
  styleUrls: ['./model-commodities.component.css']
})
export class ModelCommoditiesComponent implements OnInit {
  @ViewChild(BaseChartDirective) chart: BaseChartDirective | undefined;
  public pnlYear: string = "";
  public pieChartType: ChartType = 'pie';
  public pieChartLabels: any = [];
  public pieChartsDataItems: any = [];
  public pieChartData: ChartData<'pie', number[], string | string[]> = {
    labels: [],
    datasets: [{
      data: []
    }]
  };
  constructor(private modelService: ModelService) { }

  ngOnInit() {
    this.modelService.getYearlyPnLPriceMetrics().subscribe((response) => {

      response.forEach((element, index) => {
        this.pieChartData.labels?.push(element.name);
        if (element.prices.length > 0) {
          this.pnlYear = element.prices[2].year;
          let price = parseInt(element.prices[2].cummulativePrice)
          this.pieChartData.datasets[0].data.push(price);
        } else {
          this.pieChartData.datasets[0].data.push(0);
        }
      });
      this.chart?.update();
    });
  }
}
