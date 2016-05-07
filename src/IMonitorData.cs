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
    /// Monitor plot point with its timestamp and value.
    /// </summary>    
    public interface IMonitorData
    {

        /// <summary>
        /// Time of sampling.
        /// </summary>
        DateTime Timestamp { get; }

        /// <summary>
        /// Value sampled ad the timestamp.
        /// </summary>
        double Value { get; }

        /// <summary>
        /// Retrieve the count of mean items that formed Value and Timestamp.
        /// </summary>
        int MeanValueCount { get; }

        /// <summary>
        /// Retrieve the timespan from the [Timestamp] over which the Value is computed as mean.
        /// </summary>
        TimeSpan MeanTimespan { get; }

        /// <summary>
        /// Add the given data to mean at this one.
        /// Pre: Timestamp of given data must greather than this.
        /// </summary>        
        void MeanAdd(IMonitorData data);

        /// <summary>
        /// Clone this object.
        /// </summary>        
        IMonitorData Clone();

    }

}
