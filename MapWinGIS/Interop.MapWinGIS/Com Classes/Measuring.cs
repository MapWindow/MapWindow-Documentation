﻿using System;
using MapWinGIS;
// ReSharper disable CheckNamespace

#if nsp
namespace MapWinGIS
{
#endif
    /// <summary>
    /// Handles built-in distance and area measuring on the map.
    /// </summary>
    /// <remarks>
    /// To start measuring set AxMap.CursorMode to cmMeasure. Then the following buttons can be used.
    /// - Left-click to add new points;
    /// - Right-click to undo the last point;
    /// - Double-click to finish the path;
    /// - Ctrl-click on one of the preceding vertices in distance mode, to close polygon and measure its area;
    /// - Shift-click to snap to the closest vertex of shapefile.
    ///    
    /// There are 2 modes of measuring:
    /// - distance (a path consisting of a number of points can be measured);
    /// - area (area of single closed polygon can be measured);
    /// .
    /// To toggle to area measuring mode:
    /// \code
    /// axMap1.Measuring.MeasuringType= tkMeasuringType.MeasureArea;
    /// \endcode
    /// Measurements will be performed:
    /// - if geoprojection is not empty - by converting coordinates to decimal degrees and using precise calculation on ellipsoid 
    /// (<a href = "http://geographiclib.sourceforge.net/html/">GeographicLib</a>);
    /// - otherwise - planar calculations using Euclidean geometry and AxMap.MapUnits property;
    /// .
    /// Current implementation support only metric units (meters, kilometers). The abbreviated name of units can be changed to a localized one
    /// using GlobalSettings.set_LocalizedString:
    /// \code
    /// GlobalSettings gs = new GlobalSettings();
    /// gs.set_LocalizedString(tkLocalizedStrings.lsKilometers) = "км";
    /// \endcode
    /// Custom logic to be executed during measuring can be added by handling AxMap.MeasuringChanged event. Area and length 
    /// of measured path are available via Measuring.Length and Measuring.Area (in meters and square meters respectively; or map 
    /// units if no projection is set). Measured points can be accessed using Measuring.get_PointXY and Measuring.PointCount.
    /// Use AxMap.ProjToDegrees to get latitude, longitude in decimal degrees.
    /// \code
    /// axMap1.MeasuringChanged += (s, e) =>
    /// {
    ///     if (e.action  == tkMeasuringAction.PointAdded)
    ///     {
    ///         if (axMap1.Measuring.IsUsingEllipsoid)
    ///         {
    ///             Debug.WriteLine("Calculations on ellipsoid.");
    ///             Debug.WriteLine("Area: " + axMap1.Measuring.Area + "sq.m");
    ///             Debug.WriteLine("Distance: " + axMap1.Measuring.Length + "m");
    ///         }
    ///         else
    ///         {
    ///             Debug.WriteLine("Calculations on plane.");
    ///             Debug.WriteLine("Area: " + axMap1.Measuring.Area + "map units");
    ///             Debug.WriteLine("Distance: " + axMap1.Measuring.Length + "map units");
    ///         }
    ///  
    ///         double x, y;
    ///         Debug.WriteLine("Measured points (in map units.): " + axMap1.Measuring.PointCount);
    ///         for (int i = 0; i < axMap1.Measuring.PointCount; i++)
    ///         {
    ///             if (axMap1.Measuring.get_PointXY(i, out x, out y))
    ///             {
    ///                 Debug.WriteLine("x={0}; y={1}", x, y);
    ///             }
    ///         }
    ///     }
    /// };
    /// \endcode
    /// </remarks>
    /// \new491 Added in version 4.9.1
#if nsp
    #if upd
        public class Measuring : MapWinGIS.IMeasuring
    #else        
        public class IMeasuring
    #endif
#else
    public class Measuring
#endif
    {
        /// <summary>
        /// Gets the measured area (in square meters if WGS84 compatible projection is set for map and in current square map units otherwise).
        /// </summary>
        public double Area
        {
            get { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Clears all measurements.
        /// </summary>
        public void Clear()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Saves the state of the class to the string
        /// </summary>
        /// <returns>A string with the state or an empty string on failure.</returns>
        /// \new493 Added in version 4.9.3
        public string Serialize()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Restores the state of object from the string.
        /// </summary>
        /// <param name="state">A string generated by Measuring.Serialize() method</param>
        /// <returns>True on success.</returns>
        /// \new493 Added in version 4.9.3
        public bool Deserialize(string state)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Finishes measuring. The measured path won't be cleared from map immediately.
        /// </summary>
        public void FinishMeasuring()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets value indicating whether measurement was stopped.
        /// </summary>
        public bool IsStopped
        {
            get { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Gets the length of measured path (in meters if WGS84 compatible projection is set for map and in current map units otherwise).
        /// </summary>
        public double Length
        {
            get { throw new NotImplementedException(); }
        }

        /// <summary>
        /// The type of measurement, either distance or area.
        /// </summary>
        public tkMeasuringType MeasuringType
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the finished path will be preserved on map
        /// when map cursor changes to something other than cmMeasure. 
        /// </summary>
        public bool Persistent
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Gets or sets a value indicating whether bearing of the line segments will be displayed.
        /// </summary>
        /// \new493 Added in version 4.9.3
        public bool ShowBearing
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Gets number of points in the measured path.
        /// </summary>
        public int PointCount
        {
            get { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Undoes entering of the last point in the path.
        /// </summary>
        /// <returns>True on success.</returns>
        public bool UndoPoint()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets an area within the path polygon including an additional point (typically the current position of mouse cursor).
        /// </summary>
        /// <param name="lastPointProjX">X coordinate of the last point (in map coordinates).</param>
        /// <param name="lastPointProjY">Y coordinate of the last point (in map coordinates).</param>
        /// <returns>Area in square meters if WGS84 compatible projection is set for map and in current square map units otherwise.</returns>
        public double get_AreaWithClosingVertex(double lastPointProjX, double lastPointProjY)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets coordinates of specified point in the path.
        /// </summary>
        /// <param name="PointIndex">Index of a point.</param>
        /// <param name="x">X coordinate of the point in map coordinates.</param>
        /// <param name="y">Y coordinate of the point in map coordinates.</param>
        /// <returns>True on success.</returns>
        public bool get_PointXY(int PointIndex, out double x, out double y)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets a value indicating whether calculations are performed taking into account the shape of Earth 
        /// (when map projection is defined), or on 2D plane (Euclidean geometry).
        /// </summary>
        /// \new491 Added in version 4.9.1
        public bool IsUsingEllipsoid
        {
            get { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Gets or sets a Callback object which handles progress and error messages.
        /// </summary>
        /// \new493 Added in version 4.9.3
        /// \deprecated v4.9.3 Use GlobalSettings.ApplicationCallback instead.
        public ICallback GlobalCallback
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Returns true if measured path contains at least one point.
        /// </summary>
        /// \new493 Added in version 4.9.3
        public bool IsEmpty
        {
            get { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Gets or sets type of the bearing to be display for line segments.
        /// </summary>
        /// \new493 Added in version 4.9.3
        public tkBearingType BearingType
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Gets or sets a value indicating whether length of the line segments will be displayed.
        /// </summary>
        /// \new493 Added in version 4.9.3
        public bool ShowLength
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Gets or sets type of the length units to be displayed.
        /// </summary>
        /// \new493 Added in version 4.9.3
        public tkLengthDisplayMode LengthUnits
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Gets or sets the area units to be displayed.
        /// </summary>
        /// \new493 Added in version 4.9.3
        public tkAreaDisplayMode AreaUnits
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Gets or sets angle format to be used to display bearing.
        /// </summary>
        /// \new493 Added in version 4.9.3
        public tkAngleFormat AngleFormat
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Gets or sets the number of decimal degrees to be used to display bearing.
        /// </summary>
        /// <remarks>This setting is not used when AngleFormat is set to minutes or seconds.</remarks>
        /// \new493 Added in version 4.9.3
        public int AnglePrecision
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Gets or sets the number of decimal degrees to be used to display area.
        /// </summary>
        /// \new493 Added in version 4.9.3
        public int AreaPrecision
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Gets or sets the number of decimal degrees to be used to display length.
        /// </summary>
        /// \new493 Added in version 4.9.3
        public int LengthPrecision
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Gets or sets a value indicating whether vertices of the measured path will be visible.
        /// </summary>
        /// \new493 Added in version 4.9.3
        public bool PointsVisible
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Gets or sets line color to display measured path.
        /// </summary>
        /// \new493 Added in version 4.9.3
        public uint LineColor
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Gets or sets fill color for polygon display.
        /// </summary>
        /// \new493 Added in version 4.9.3
        public uint FillColor
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Gets or sets fill transparency for polygon display.
        /// </summary>
        /// \new493 Added in version 4.9.3
        public byte FillTransparency
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Gets or sets line width to display measured path.
        /// </summary>
        /// \new493 Added in version 4.9.3
        public float LineWidth
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Gets or sets line style to display measured path.
        /// </summary>
        /// \new493 Added in version 4.9.3
        public tkDashStyle LineStyle
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Gets or sets a value indicating whether labels with indices of points will be visible near the vertices.
        /// </summary>
        /// \new493 Added in version 4.9.3
        public bool PointLabelsVisible
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Gets or sets a value indicating whether accumulated length will be shown in brackets for each line segment.
        /// </summary>
        /// \new493 Added in version 4.9.3
        public bool ShowTotalLength
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Gets or sets the type of user input to be used to undo the last point of the measured path.
        /// </summary>
        /// \new493 Added in version 4.9.3
        public tkUndoShortcut UndoButton
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        /// <summary>
        /// A text string associated with object. Any value can be stored by developer in this property.
        /// </summary>
        /// \new493 Added in version 4.9.3
        public string Key
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Gets the code of last error which took place inside this object.
        /// </summary>
        /// \new493 Added in version 4.9.3
        public int LastErrorCode
        {
            get { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Gets the description of the specific error code.
        /// </summary>
        /// <param name="ErrorCode">The error code returned by LastErrorCode property.</param>
        /// <returns>String with the description.</returns>
        /// \new493 Added in version 4.9.3
        public string get_ErrorMsg(int ErrorCode)
        {
            throw new NotImplementedException();
        }
    }
#if nsp
}
#endif
