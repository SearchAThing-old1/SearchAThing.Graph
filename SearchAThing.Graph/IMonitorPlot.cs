#region SearchAThing.Graph, Copyright(C) 2015-2016 Lorenzo Delana, License under MIT
/*
* The MIT License(MIT)
* Copyright(c) 2016 Lorenzo Delana, https://searchathing.com
*
* Permission is hereby granted, free of charge, to any person obtaining a
* copy of this software and associated documentation files (the "Software"),
* to deal in the Software without restriction, including without limitation
* the rights to use, copy, modify, merge, publish, distribute, sublicense,
* and/or sell copies of the Software, and to permit persons to whom the
* Software is furnished to do so, subject to the following conditions:
*
* The above copyright notice and this permission notice shall be included in
* all copies or substantial portions of the Software.
*
* THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
* IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
* FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
* AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
* LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
* FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
* DEALINGS IN THE SOFTWARE.
*/
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAThing.Graph
{

    /// <summary>
    /// Manage the insertion and retrival of monitoring plot data.
    /// </summary>    
    public interface IMonitorPlot
    {

        /// <summary>
        /// Add the given sampling data to the monitor plot.
        /// </summary>        
        /// <param name="currentTime">If not null allow to override current time (used primarly by unit tests).</param>
        void Add(IMonitorData data, DateTime? currentTime = null);

        /// <summary>
        /// Gets the width of the plot area.
        /// </summary>
        int PlotWidth { get; }

        /// <summary>
        /// Retrieve the list of available datasets.
        /// Foreach dataset is a [PlotWidth] dataset recorded as a result of the mean data.
        /// </summary>
        IEnumerable<IMonitorDataSet> DataSets { get; }

        /// <summary>
        /// Add a dataset window to keep track of gathered data in the timespan back to now.
        /// </summary>        
        IMonitorDataSet AddDataSet(string name, TimeSpan timespan);        

    }

}
