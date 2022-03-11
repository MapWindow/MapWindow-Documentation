// ReSharper disable UnassignedGetOnlyAutoProperty
// ReSharper disable CheckNamespace

#if nsp
namespace MapWinGIS
{
#endif
    using System;
    using System.Diagnostics;
    using MapWinGIS;

    /// <summary>
    /// Implementation of the GDAL v2 librified functions.
    /// Not all functions are implemented yet.
    /// </summary>
    /// \new495 Added in version 4.9.5
#if nsp
#if upd
    public class GdalUtils : MapWinGIS.IGdalUtils
#else
    public class IGdalUtils
#endif
#else
public class GdalUtils
#endif
{
    /// <summary>
    /// Retrieves the last error generated in the object. 
    /// </summary>
    /// \new495 Added in version 4.9.5
    /// 
    /// \code
    /// // Get the last error code when the method returns false
    /// var gdalUtils = new GdalUtils();
    /// Debug.WriteLine(gdalUtils.ErrorMsg[gdalUtils.LastErrorCode]);
    /// \endcode
    public int LastErrorCode { get; }

    /// <summary>
    /// The global callback is the interface used by MapWinGIS to pass progress and error events to interested applications.
    /// </summary>
    /// \new495 Added in version 4.9.5
    public ICallback GlobalCallback { get; set; }

    /// <summary>
    /// The key may be used by the programmer to store any string data associated with the object.
    /// </summary>
    /// \new495 Added in version 4.9.5
    public string Key { get; set; }

    /// <summary>
    /// Gets the detailed error message.
    /// </summary>
    /// \new495 Added in version 4.9.5
    ///
    /// \code
    /// // Get the last detailed error message when the method returns false
    /// var gdalUtils = new GdalUtils();
    /// Debug.WriteLine(gdalUtils.DetailedErrorMsg);
    /// \endcode
    public string DetailedErrorMsg { get; }

    /// <summary>
    /// Image reprojection and warping utility.
    /// Implementing the librified function of GDAL's <tt>gdalwarp.exe</tt> tool
    /// </summary>
    /// <param name="sourceFilename">The source filename.</param>
    /// <param name="destinationFilename">The destination filename.</param>
    /// <param name="options">The options, as a string array</param>
    /// <remarks>See GDAL's documentation here: https://gdal.org/programs/gdalwarp.html</remarks>
    /// \new495 Added in version 4.9.5
    /// \new510 Renamed from GdalWarp in version 5.1.0
    /// 
    /// \code
    /// // Example of creating VRT file from TIFF file. More options are possible:
    /// var output = Path.GetTempPath() + "GdalWarp.vrt";
    /// var options = new[]
    /// {
    ///     "-of", "vrt",
    ///     "-overwrite"
    /// };
    /// var gdalUtils = new GdalUtils();
    /// if (!gdalUtils.GdalRasterWarp("test.tif", output, options))
    /// {
    ///     Debug.WriteLine("GdalRasterWarp failed: " + gdalUtils.ErrorMsg[gdalUtils.LastErrorCode] + " Detailed error: " + gdalUtils.DetailedErrorMsg);
    /// }
    /// \endcode 
    /// 
    /// \code
    /// // Example of cutting a TIFF file with a border file: 
    /// var output = Path.GetTempPath() + "GdalWarpCutline.vrt";
    /// const string border = @"test.shp";
    /// var options = new[]
    /// {
    ///     "-of", "vrt",
    ///     "-overwrite",
    ///     "-crop_to_cutline",
    ///     "-cutline", border
    /// };
    /// var gdalUtils = new GdalUtils();
    /// if (!gdalUtils.GdalRasterWarp("test.tif", output, options))
    /// {
    ///     Debug.WriteLine("GdalRasterWarp failed: " + gdalUtils.ErrorMsg[gdalUtils.LastErrorCode] + " Detailed error: " + gdalUtils.DetailedErrorMsg);
    /// }
    /// \endcode
    public bool GdalRasterWarp(string sourceFilename, string destinationFilename, string[] options)
    {
        var gdalUtils = new GdalUtilsClass();
        if (!gdalUtils.GdalRasterWarp(sourceFilename, destinationFilename, options))
        {
            Debug.WriteLine("GdalRasterWarp failed: " + gdalUtils.ErrorMsg[gdalUtils.LastErrorCode] + " Detailed error: " + gdalUtils.DetailedErrorMsg);
        }
        throw new NotImplementedException();
    }

    /// <summary>
    /// Build raster overview(s)
    /// Implementing the librified function of GDAL's <tt>gdaladdo.exe</tt> tool
    /// </summary>
    /// <param name="sourceFilename">The source filename</param>
    /// <param name="resamplingMethod">Controlling the downsampling method applied, defaults to grmNearest</param>
    /// <param name="overviewList">A list of integral overview levels to build, as an integer array</param>
    /// <param name="bandList">List of band numbers, band numbering starts from 1, as an integer array</param>
    /// <param name="configOptions">The configuration options, as a string array (<tt>-</tt><tt>-config</tt>)</param>
    /// <remarks>
    /// See GDAL's documentation here: https://gdal.org/programs/gdaladdo.html
    /// A good guide about compressions of GeoTiff: https://kokoalberti.com/articles/geotiff-compression-optimization-guide/
    /// </remarks>
    /// \new510 Added in version 5.1.0
    ///
    /// \code
    ///
    /// // Example of creating overviews for all bands with autogenerated levels:
    /// var configOptions = new[] { "COMPRESS_OVERVIEW DEFLATE", "INTERLEAVE_OVERVIEW PIXEL" };
    /// var gdalUtils = new GdalUtils();
    /// if (!gdalUtils.GdalBuildOverviews("test.tif, tkGDALResamplingMethod.grmCubic, null, null, configOptions);)
    /// {
    ///     Debug.WriteLine("GdalBuildOverviews failed: " + gdalUtils.ErrorMsg[gdalUtils.LastErrorCode] + " Detailed error: " + gdalUtils.DetailedErrorMsg);
    /// }
    /// \endcode
    /// \code
    /// // Example of creating overviews for only the first 3 bands and predefined levels:
    /// // // To produce the smallest possible JPEG-In-TIFF overviews, you should use:
    /// var configOptions = new[] { "COMPRESS_OVERVIEW JPEG", "PHOTOMETRIC_OVERVIEW YCBCR", "INTERLEAVE_OVERVIEW PIXEL" };
    /// var overviewList = new[] { 2, 4, 8, 16, 32, 64, 128 };
    /// var bandList = new[] { 1, 2, 3 };
    /// var gdalUtils = new GdalUtils();
    /// if (!gdalUtils.GdalBuildOverviews("test.tif", tkGDALResamplingMethod.grmAverage, overviewList, bandList, configOptions);)
    /// {
    ///     Debug.WriteLine("GdalBuildOverviews failed: " + gdalUtils.ErrorMsg[gdalUtils.LastErrorCode] + " Detailed error: " + gdalUtils.DetailedErrorMsg);
    /// }
    /// \endcode
    public bool GdalBuildOverviews(string sourceFilename, tkGDALResamplingMethod resamplingMethod, int[] overviewList,
        int[] bandList, string[] configOptions)
    {
        var gdalUtils = new GdalUtilsClass();
        if (!gdalUtils.GdalBuildOverviews(sourceFilename, (MapWinGIS.tkGDALResamplingMethod)resamplingMethod, overviewList, bandList, configOptions))
        {
            Debug.WriteLine("GdalBuildOverviews failed: " + gdalUtils.ErrorMsg[gdalUtils.LastErrorCode] + " Detailed error: " + gdalUtils.DetailedErrorMsg);
        }
        return false;
    }

    /// <summary>
    /// Converts raster data between different formats.
    /// Implementing the librified function of GDAL's <tt>gdal_translate.exe</tt> tool
    /// </summary>
    /// <param name="sourceFilename">The source filename.</param>
    /// <param name="destinationFilename">The destination filename.</param>
    /// <param name="options">The options, as a string array</param>
    /// <remarks>See GDAL's documentation here: https://gdal.org/programs/gdal_translate.html </remarks>
    /// \new510 Added in version 5.1.0
    /// 
    /// \code
    /// // Example of changing the resolution of a TIFF file: 
    /// var output = Path.GetTempPath() + "ChangedResolution.tif";
    /// var options = new[]
    /// {
    ///     "-ot", "Float32",
    ///     "-tr", "0.2", "0.2",
    ///     "-r", "average",
    ///     "-projwin", "-180", "90", "180", "-90"
    /// };
    /// var gdalUtils = new GdalUtils();
    /// if (!gdalUtils.GdalRasterTranslate("test.tif", output, options))
    /// {
    ///     Debug.WriteLine("GdalRasterTranslate failed: " + gdalUtils.ErrorMsg[gdalUtils.LastErrorCode] + " Detailed error: " + gdalUtils.DetailedErrorMsg);
    /// }
    /// \endcode
    public bool GdalRasterTranslate(string sourceFilename, string destinationFilename, string[] options)
    {
        var gdalUtils = new GdalUtilsClass();
        if (!gdalUtils.GdalRasterTranslate(sourceFilename, destinationFilename, options))
        {
            Debug.WriteLine("GdalRasterTranslate failed: " + gdalUtils.ErrorMsg[gdalUtils.LastErrorCode] + " Detailed error: " + gdalUtils.DetailedErrorMsg);
        }
        throw new NotImplementedException();
    }

    /// <summary>
    /// Converts simple features data between file formats.
    /// Implementing the librified function of GDAL's <tt>ogr2ogr.exe</tt> tool
    /// </summary>
    /// <param name="sourceFilename">The source filename.</param>
    /// <param name="destinationFilename">The destination filename.</param>
    /// <param name="options">The options, as a string array</param>
    /// <param name="useSharedConnection">If set to <c>true</c> improves performance but also might make it instable.</param>
    /// <remarks>See GDAL's documentation here: https://gdal.org/programs/ogr2ogr.html</remarks>
    /// \new495 Added in version 4.9.5
    /// 
    /// \code
    /// // Converting shapefile to gml:
    /// var outputFilename = Path.Combine(Path.GetTempPath(), "translated.gml");
    /// var options = new[]
    /// {
    ///     "-f", "GML"
    /// };
    /// var gdalUtils = new GdalUtils();
    /// if (!gdalUtils.GdalVectorTranslate(inputFilename, outputFilename, options, true))
    /// {
    ///     Debug.WriteLine("GdalVectorTranslate failed: " + gdalUtils.ErrorMsg[gdalUtils.LastErrorCode] + " Detailed error: " + gdalUtils.DetailedErrorMsg);
    /// }
    /// \endcode
    public bool GdalVectorTranslate(string sourceFilename, string destinationFilename, string[] options,
        bool useSharedConnection = false)
    {
        var gdalUtils = new GdalUtilsClass();
        if (!gdalUtils.GdalVectorTranslate(sourceFilename, destinationFilename, options, useSharedConnection))
        {
            Debug.WriteLine("GdalVectorTranslate failed: " + gdalUtils.ErrorMsg[gdalUtils.LastErrorCode] + " Detailed error: " + gdalUtils.DetailedErrorMsg);
        }
        throw new NotImplementedException();
    }

    /// <summary>
    /// Helper file to simply reproject a file from an EPSG code to another EPSG code.
    /// Uses GdalVectorTranslate() internally.
    /// If you need more options use GdalVectorTranslate() instead.
    /// </summary>
    /// <param name="sourceFilename">The source filename.</param>
    /// <param name="destinationFilename">The destination filename.</param>
    /// <param name="sourceEpsgCode">The source EPSG code.</param>
    /// <param name="destinationEpsgCode">The destination EPSG code.</param>
    /// <param name="useSharedConnection">If set to <c>true</c> improves performance but also might make it instable.</param>
    /// \new54 Added in version 5.4
    ///
    /// \code
    /// // Reprojecting the source file to another EPSG code
    /// var gdalUtils = new GdalUtils();
    /// var outputFilename = Path.Combine(Path.GetTempPath(), "translated.shp");
    /// if (!gdalUtils.GdalVectorReproject(sourceFilename, outputFilename, 4326, 28992))
    /// {
    ///     Debug.WriteLine("GdalVectorReproject failed: " + gdalUtils.ErrorMsg[gdalUtils.LastErrorCode] + " Detailed error: " + gdalUtils.DetailedErrorMsg);
    /// }
    /// \endcode
    public bool GdalVectorReproject(string sourceFilename, string destinationFilename, int sourceEpsgCode, int destinationEpsgCode,
        bool useSharedConnection = false)
    {
        var gdalUtils = new GdalUtilsClass();
        if (!gdalUtils.GdalVectorReproject(sourceFilename, destinationFilename, sourceEpsgCode, destinationEpsgCode, useSharedConnection))
        {
            Debug.WriteLine("GdalVectorReproject failed: " + gdalUtils.ErrorMsg[gdalUtils.LastErrorCode] + " Detailed error: " + gdalUtils.DetailedErrorMsg);
        }
        throw new NotImplementedException();
    }

    /// <summary>
    /// Clips the vector with another vector.
    /// </summary>
    /// <param name="subjectFilename">The subject filename.</param>
    /// <param name="overlayFilename">The overlay filename.</param>
    /// <param name="destinationFilename">The destination filename.</param>
    /// <param name="useSharedConnection">If set to <c>true</c> improves performance but also might make it instable.</param>
    /// <remarks>Uses GdalUtils.GdalVectorTranslate under the hood.</remarks>
    /// \new495 Added in version 4.9.5
    /// 
    /// \code
    /// // Clipping large shapefile with border file
    /// var outputFilename = Path.Combine(tempFolder, "GdalVectorTranslate.shp");
    /// var gdalUtils = new GdalUtils();
    /// if (!gdalUtils.ClipVectorWithVector("LargeFile.shp", "Border.shp", outputFilename))
    /// {
    ///     Debug.WriteLine("GdalVectorTranslate failed: " + gdalUtils.ErrorMsg[gdalUtils.LastErrorCode] + " Detailed error: " + gdalUtils.DetailedErrorMsg);
    /// }
    /// \endcode
    public bool ClipVectorWithVector(string subjectFilename, string overlayFilename, string destinationFilename,
        bool useSharedConnection = true)
    {
        var gdalUtils = new GdalUtilsClass();
        if (!gdalUtils.ClipVectorWithVector(subjectFilename, overlayFilename, destinationFilename, useSharedConnection))
        {
            Debug.WriteLine("GdalVectorTranslate failed: " + gdalUtils.ErrorMsg[gdalUtils.LastErrorCode] + " Detailed error: " + gdalUtils.DetailedErrorMsg);
        }
        throw new NotImplementedException();
    }

    /// <summary>
    /// Retrieves the error message associated with the specified error code. 
    /// </summary>
    /// <param name="errorCode">The error code for which the error message is required.</param>
    /// <returns>The error message description for the specified error code. </returns>
    /// \new495 Added in version 4.9.5
    ///
    /// \code
    /// // Get the error message when the method returns false
    /// var gdalUtils = new GdalUtils();
    /// Debug.WriteLine(gdalUtils.ErrorMsg[gdalUtils.LastErrorCode]);
    /// \endcode
    public string ErrorMsg(int errorCode)
    {
        var gdalUtils = new GdalUtilsClass();
        Debug.WriteLine(gdalUtils.ErrorMsg[errorCode]);
        throw new NotImplementedException();
    }
}
#if nsp
}
#endif

