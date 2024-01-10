# How-to-perform-lazy-loading-in-WPF-Chart-SfChart-
This sample demonstrates how to perform lazy loading in WPF Chart(SfChart).

Here's a step-by-step guide on how to perform lazy loading in a WPF Chart using the Syncfusion SfChart

Step 1: Initialize the SfChart with Primary and Secondary axis.
Step 2: Hook the PanChanged event in SfChart and set the required ZoomFactor on the primary axis.

{% tabs %}

{% highlight xaml %}

<syncfusion:SfChart PanChanged="chart_PanChanged">
<syncfusion:SfChart .PrimaryAxis>
   <syncfusion:NumericalAxis x:name="xAxis" zoomfactor="0.5"/>
</syncfusion:SfChart .PrimaryAxis>

<syncfusion:SfChart .SecondaryAxis>
   <syncfusion:NumericalAxis/>
</syncfusion:SfChart .SecondaryAxis>

.... Add your series here ....
</syncfusion:SfChart>

{% endhighlight %}

{% highlight c# %}

SfChart chart = new SfChart();
chart.PanChanged += chart_PanChanged;
NumericalAxis xAxis = new NumericalAxis();
xAxis.ZoomFactor = 0.5;
chart.PrimaryAxis = xAxis;
NumericalAxis yAxis = new NumericalAxis();
chart.SecondaryAxis = yAxis;
this.Content = chart;

{% endhighlight %}

{% endtabs %}

## Step 3 : 
Initialize the ChartZoomPanBehavior and enable panning by setting EnablePanning to “True”.

{% tabs %}

{% highlight xaml %}

<syncfusion:SfChart.Behaviors>
   <syncfusion:ChartZoomPanBehavior EnablePanning="True"/>
</syncfusion:SfChart.Behaviors>

{% endhighlight %}

{% highlight c# %}

ChartZoomPanBehavior zoomPanBehavior = new ChartZoomPanBehavior();
zoomPanBehavior.EnablePanning = true;

chart.Behaviors.Add(zoomPanBehavior);
{% endhighlight %}

{% endtabs %}

## Step 4: 
Implement the chart_PanChanged method to calculate the end range of the chart. As horizontal scrolling or panning reaches the end of the chart, additional data points are added, then adjust the position of the xAxis range using ZoomPosition.

{% tabs %}

{% highlight c# %}

**// startValue = You can set the last value of the data source in viewModel.**
private void chart_PanChanged(object sender, PanChangedEventArgs e)
{       
 var position = xAxis.ZoomPosition - xAxis.ZoomFactor;
         
 if (e.Axis.Equals(xAxis) && position>=0)
 {
     // Update the data based on your requirement. 
     for (int i = 0; i < 4; i++)
     {   
         viewModel.Data.Add(new Model(startValue, new Random().Next(10, 40)));
         startValue++;                 
     }
     xAxis.ZoomPosition = 1;
 }
}

{% endhighlight %}

{% endtabs %}

## Output

![LazyLoading_Output](https://github.com/SyncfusionExamples/How-to-perform-lazy-loading-in-WPF-Chart-SfChart/assets/113961867/8adee59a-dee8-43dc-8609-c4d529e80873)


