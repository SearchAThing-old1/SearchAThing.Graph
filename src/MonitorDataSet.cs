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

using SearchAThing.Collections;
using System;
using System.Collections.Generic;

namespace SearchAThing.Graph
{

    public class MonitorDataSet : IMonitorDataSet
    {
        CircularList<IMonitorData> points;

        public string Name { get; private set; }
        public TimeSpan? TimespanTotal { get; private set; }
        public IEnumerable<IMonitorData> Points { get { return points.Items; } }
        public int SizeMax { get; private set; }
        public TimeSpan? TimespanInterval { get; private set; }

        /// <summary>
        /// Add the given data and store in the dataset computing the mean value if needed.
        /// </summary>        
        public void Add(IMonitorData data, DateTime? currentTime)
        {
            if (!TimespanTotal.HasValue || points.Count == 0) // add points without mean average for default set or if empty set
            {
                points.Add(data.Clone());
            }
            else
            {
                var last = points.GetItem(points.Count - 1);
                var ct = currentTime.HasValue ? currentTime.Value : DateTime.Now;

                // checks if last point timespan not yet overcome
                if (last.Timestamp + TimespanInterval.Value > ct)
                {
                    last.MeanAdd(data);
                }
                else // aggregate data
                {
                    points.Add(data.Clone());
                }         
            }
        }

        internal MonitorDataSet(int sizeMax, string name, TimeSpan? timespan)
        {
            points = new CircularList<IMonitorData>(sizeMax);
            Name = name;
            TimespanTotal = timespan;
            SizeMax = sizeMax;
            if (timespan.HasValue) TimespanInterval = new TimeSpan(timespan.Value.Ticks / sizeMax);
        }
    }

}
