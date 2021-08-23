namespace Plotly.NET

open DynamicObj
open System

/// <summary>Various axes that can be used to add scales to your plots.</summary>
module Axis =

    /// <summary>Linear axes can be used as x and y scales on 2D plots, and as x,y, and z scales on 3D plots.</summary>
    type LinearAxis () =
        inherit DynamicObj ()

        /// <summary>
        /// Initialize a LinearAxis object that can be used as a positional scale for Y, X or Z coordinates.
        /// </summary>
        /// <param name="Visible">A single toggle to hide the axis while preserving interaction like dragging. Default is true when a cheater plot is present on the axis, otherwise false</param>
        /// <param name="Color">Sets default for all colors associated with this axis all at once: line, font, tick, and grid colors. Grid color is lightened by blending this with the plot background Individual pieces can override this.</param>
        /// <param name="Title">Sets the axis title.</param>
        /// <param name="AxisType">Sets the axis type. By default, plotly attempts to determined the axis type by looking into the data of the traces that referenced the axis in question.</param>
        /// <param name="AutoTypeNumbers">Using "strict" a numeric string in trace data is not converted to a number. Using "convert types" a numeric string in trace data may be treated as a number during automatic axis `type` detection. Defaults to layout.autotypenumbers.</param>
        /// <param name="AutoRange">Determines whether or not the range of this axis is computed in relation to the input data. See `rangemode` for more info. If `range` is provided, then `autorange` is set to "false".</param>
        /// <param name="RangeMode">If "normal", the range is computed in relation to the extrema of the input data. If "tozero"`, the range extends to 0, regardless of the input data If "nonnegative", the range is non-negative, regardless of the input data. Applies only to linear axes.</param>
        /// <param name="Range">Sets the range of this axis. If the axis `type` is "log", then you must take the log of your desired range (e.g. to set the range from 1 to 100, set the range from 0 to 2). If the axis `type` is "date", it should be date strings, like date data, though Date objects and unix milliseconds will be accepted and converted to strings. If the axis `type` is "category", it should be numbers, using the scale where each category is assigned a serial number from zero in the order it appears.</param>
        /// <param name="FixedRange">Determines whether or not this axis is zoom-able. If true, then zoom is disabled.</param>
        /// <param name="ScaleAnchor">If set to another axis id (e.g. `x2`, `y`), the range of this axis changes together with the range of the corresponding axis such that the scale of pixels per unit is in a constant ratio. Both axes are still zoomable, but when you zoom one, the other will zoom the same amount, keeping a fixed midpoint. `constrain` and `constraintoward` determine how we enforce the constraint. You can chain these, ie `yaxis: {scaleanchor: "x"}, xaxis2: {scaleanchor: "y"}` but you can only link axes of the same `type`. The linked axis can have the opposite letter (to constrain the aspect ratio) or the same letter (to match scales across subplots). Loops (`yaxis: {scaleanchor: "x"}, xaxis: {scaleanchor: "y"}` or longer) are redundant and the last constraint encountered will be ignored to avoid possible inconsistent constraints via `scaleratio`. Note that setting axes simultaneously in both a `scaleanchor` and a `matches` constraint is currently forbidden.</param>
        /// <param name="ScaleRatio">If this axis is linked to another by `scaleanchor`, this determines the pixel to unit scale ratio. For example, if this value is 10, then every unit on this axis spans 10 times the number of pixels as a unit on the linked axis. Use this for example to create an elevation profile where the vertical scale is exaggerated a fixed amount with respect to the horizontal.</param>
        /// <param name="Constrain">If this axis needs to be compressed (either due to its own `scaleanchor` and `scaleratio` or those of the other axis), determines how that happens: by increasing the "range", or by decreasing the "domain". Default is "domain" for axes containing image traces, "range" otherwise.</param>
        /// <param name="ConstrainToward">If this axis needs to be compressed (either due to its own `scaleanchor` and `scaleratio` or those of the other axis), determines which direction we push the originally specified plot area. Options are "left", "center" (default), and "right" for x axes, and "top", "middle" (default), and "bottom" for y axes.</param>
        /// <param name="Matches">If set to another axis id (e.g. `x2`, `y`), the range of this axis will match the range of the corresponding axis in data-coordinates space. Moreover, matching axes share auto-range values, category lists and histogram auto-bins. Note that setting axes simultaneously in both a `scaleanchor` and a `matches` constraint is currently forbidden. Moreover, note that matching axes must have the same `type`.</param>
        /// <param name="Rangebreaks">Sets breaks in the axis range</param>
        /// <param name="TickMode">Sets the tick mode for this axis. If "auto", the number of ticks is set via `nticks`. If "linear", the placement of the ticks is determined by a starting position `tick0` and a tick step `dtick` ("linear" is the default value if `tick0` and `dtick` are provided). If "array", the placement of the ticks is set via `TickVals` and the tick text is `TickText`. ("array" is the default value if `TickVals` is provided).</param>
        /// <param name="NTicks">Specifies the maximum number of ticks for the particular axis. The actual number of ticks will be chosen automatically to be less than or equal to `nticks`. Has an effect only if `tickmode` is set to "auto".</param>
        /// <param name="Tick0">Sets the placement of the first tick on this axis. Use with `dtick`. If the axis `type` is "log", then you must take the log of your starting tick (e.g. to set the starting tick to 100, set the `tick0` to 2) except when `dtick`="L&lt;f&gt;" (see `dtick` for more info). If the axis `type` is "date", it should be a date string, like date data. If the axis `type` is "category", it should be a number, using the scale where each category is assigned a serial number from zero in the order it appears.</param>
        /// <param name="DTick">Sets the step in-between ticks on this axis. Use with `tick0`. Must be a positive number, or special strings available to "log" and "date" axes. If the axis `type` is "log", then ticks are set every 10^(n"dtick) where n is the tick number. For example, to set a tick mark at 1, 10, 100, 1000, ... set dtick to 1. To set tick marks at 1, 100, 10000, ... set dtick to 2. To set tick marks at 1, 5, 25, 125, 625, 3125, ... set dtick to log_10(5), or 0.69897000433. "log" has several special values; "L&lt;f&gt;", where `f` is a positive number, gives ticks linearly spaced in value (but not position). For example `tick0` = 0.1, `dtick` = "L0.5" will put ticks at 0.1, 0.6, 1.1, 1.6 etc. To show powers of 10 plus small digits between, use "D1" (all digits) or "D2" (only 2 and 5). `tick0` is ignored for "D1" and "D2". If the axis `type` is "date", then you must convert the time to milliseconds. For example, to set the interval between ticks to one day, set `dtick` to 86400000.0. "date" also has special values "M&lt;n&gt;" gives ticks spaced by a number of months. `n` must be a positive integer. To set ticks on the 15th of every third month, set `tick0` to "2000-01-15" and `dtick` to "M3". To set ticks every 4 years, set `dtick` to "M48"</param>
        /// <param name="TickVals">Sets the values at which ticks on this axis appear. Only has an effect if `tickmode` is set to "array". Used with `TickText`.</param>
        /// <param name="TickText">Sets the text displayed at the ticks position via `TickVals`. Only has an effect if `tickmode` is set to "array". Used with `TickVals`.</param>
        /// <param name="Ticks">Determines whether ticks are drawn or not. If "", this axis' ticks are not drawn. If "outside" ("inside"), this axis' are drawn outside (inside) the axis lines.</param>
        /// <param name="TicksOn">Determines where ticks and grid lines are drawn with respect to their corresponding tick labels. Only has an effect for axes of `type` "category" or "multicategory". When set to "boundaries", ticks and grid lines are drawn half a category to the left/bottom of labels.</param>
        /// <param name="TickLabelMode">Determines where tick labels are drawn with respect to their corresponding ticks and grid lines. Only has an effect for axes of `type` "date" When set to "period", tick labels are drawn in the middle of the period between ticks.</param>
        /// <param name="TickLabelPosition">Determines where tick labels are drawn with respect to the axis Please note that top or bottom has no effect on x axes or when `ticklabelmode` is set to "period". Similarly left or right has no effect on y axes or when `ticklabelmode` is set to "period". Has no effect on "multicategory" axes or when `tickson` is set to "boundaries". When used on axes linked by `matches` or `scaleanchor`, no extra padding for inside labels would be added by autorange, so that the scales could match.</param>
        /// <param name="TickLabelOverflow">Determines how we handle tick labels that would overflow either the graph div or the domain of the axis. The default value for inside tick labels is "hide past domain". Otherwise on "category" and "multicategory" axes the default is "allow". In other cases the default is "hide past div".</param>
        /// <param name="Mirror">Determines if the axis lines or/and ticks are mirrored to the opposite side of the plotting area. If "true", the axis lines are mirrored. If "ticks", the axis lines and ticks are mirrored. If "false", mirroring is disable. If "all", axis lines are mirrored on all shared-axes subplots. If "allticks", axis lines and ticks are mirrored on all shared-axes subplots.</param>
        /// <param name="TickLen">Sets the tick length (in px).</param>
        /// <param name="TickWidth">Sets the tick width (in px).</param>
        /// <param name="TickColor">Sets the tick color.</param>
        /// <param name="ShowTickLabels">Determines whether or not the tick labels are drawn.</param>
        /// <param name="AutoMargin">Determines whether long tick labels automatically grow the figure margins.</param>
        /// <param name="ShowSpikes">Determines whether or not spikes (aka droplines) are drawn for this axis. Note: This only takes affect when hovermode = closest</param>
        /// <param name="SpikeColor">Sets the spike color. If undefined, will use the series color</param>
        /// <param name="SpikeThickness">Sets the width (in px) of the zero line.</param>
        /// <param name="SpikeDash">Sets the dash style of lines</param>
        /// <param name="SpikeMode">Determines the drawing mode for the spike line If "toaxis", the line is drawn from the data point to the axis the series is plotted on. If "across", the line is drawn across the entire plot area, and supercedes "toaxis". If "marker", then a marker dot is drawn on the axis the series is plotted on</param>
        /// <param name="SpikeSnap">Determines whether spikelines are stuck to the cursor or to the closest datapoints.</param>
        /// <param name="TickFont">Sets the tick font.</param>
        /// <param name="TickAngle">Sets the angle of the tick labels with respect to the horizontal. For example, a `tickangle` of -90 draws the tick labels vertically.</param>
        /// <param name="ShowTickPrefix">If "all", all tick labels are displayed with a prefix. If "first", only the first tick is displayed with a prefix. If "last", only the last tick is displayed with a suffix. If "none", tick prefixes are hidden.</param>
        /// <param name="TickPrefix">Sets a tick label prefix.</param>
        /// <param name="ShowTickSuffix">Same as `showtickprefix` but for tick suffixes.</param>
        /// <param name="TickSuffix">Sets a tick label suffix.</param>
        /// <param name="ShowExponent">If "all", all exponents are shown besides their significands. If "first", only the exponent of the first tick is shown. If "last", only the exponent of the last tick is shown. If "none", no exponents appear.</param>
        /// <param name="ExponentFormat">Determines a formatting rule for the tick exponents. For example, consider the number 1,000,000,000. If "none", it appears as 1,000,000,000. If "e", 1e+9. If "E", 1E+9. If "power", 1x10^9 (with 9 in a super script). If "SI", 1G. If "B", 1B.</param>
        /// <param name="MinExponent">Hide SI prefix for 10^n if |n| is below this number. This only has an effect when `TickFormat` is "SI" or "B".</param>
        /// <param name="SeparateThousands">If "true", even 4-digit integers are separated</param>
        /// <param name="TickFormat">Sets the tick label formatting rule using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-3.x-api-reference/blob/master/Formatting.md#d3_format. And for dates see: https://github.com/d3/d3-time-format#locale_format. We add two items to d3's date formatter: "%h" for half of the year as a decimal number as well as "%{n}f" for fractional seconds with n digits. For example, "2016-10-13 09:15:23.456" with TickFormat "%H~%M~%S.%2f" would display "09~15~23.46"</param>
        /// <param name="TickFormatStops">Set rules for customizing TickFormat on different zoom levels</param>
        /// <param name="HoverFormat">Sets the hover text formatting rule using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-3.x-api-reference/blob/master/Formatting.md#d3_format. And for dates see: https://github.com/d3/d3-time-format#locale_format. We add two items to d3's date formatter: "%h" for half of the year as a decimal number as well as "%{n}f" for fractional seconds with n digits. For example, "2016-10-13 09:15:23.456" with TickFormat "%H~%M~%S.%2f" would display "09~15~23.46"</param>
        /// <param name="ShowLine">Determines whether or not a line bounding this axis is drawn.</param>
        /// <param name="LineColor">Sets the axis line color.</param>
        /// <param name="LineWidth">Sets the width (in px) of the axis line.</param>
        /// <param name="ShowGrid">Determines whether or not grid lines are drawn. If "true", the grid lines are drawn at every tick mark.</param>
        /// <param name="GridColor">Sets the color of the grid lines.</param>
        /// <param name="GridWidth">Sets the width (in px) of the grid lines.</param>
        /// <param name="ZeroLine">Determines whether or not a line is drawn at along the 0 value of this axis. If "true", the zero line is drawn on top of the grid lines.</param>
        /// <param name="ZeroLineColor">Sets the line color of the zero line.</param>
        /// <param name="ZeroLineWidth">Sets the width (in px) of the zero line.</param>
        /// <param name="ShowDividers">Determines whether or not a dividers are drawn between the category levels of this axis. Only has an effect on "multicategory" axes.</param>
        /// <param name="DividerColor">Sets the color of the dividers Only has an effect on "multicategory" axes.</param>
        /// <param name="DividerWidth">Sets the width (in px) of the dividers Only has an effect on "multicategory" axes.</param>
        /// <param name="Anchor">If set to an opposite-letter axis id (e.g. `x2`, `y`), this axis is bound to the corresponding opposite-letter axis. If set to "free", this axis' position is determined by `position`.</param>
        /// <param name="Side">Determines whether a x (y) axis is positioned at the "bottom" ("left") or "top" ("right") of the plotting area.</param>
        /// <param name="Overlaying">If set a same-letter axis id, this axis is overlaid on top of the corresponding same-letter axis, with traces and axes visible for both axes. If "false", this axis does not overlay any same-letter axes. In this case, for axes with overlapping domains only the highest-numbered axis will be visible.</param>
        /// <param name="Layer">Sets the layer on which this axis is displayed. If "above traces", this axis is displayed above all the subplot's traces If "below traces", this axis is displayed below all the subplot's traces, but above the grid lines. Useful when used together with scatter-like traces with `cliponaxis` set to "false" to show markers and/or text nodes above this axis.</param>
        /// <param name="Domain">Sets the domain of this axis (in plot fraction).</param>
        /// <param name="Position">Sets the position of this axis in the plotting space (in normalized coordinates). Only has an effect if `anchor` is set to "free".</param>
        /// <param name="CategoryOrder">Specifies the ordering logic for the case of categorical variables. By default, plotly uses "trace", which specifies the order that is present in the data supplied. Set `categoryorder` to "category ascending" or "category descending" if order should be determined by the alphanumerical order of the category names. Set `categoryorder` to "array" to derive the ordering from the attribute `categoryarray`. If a category is not found in the `categoryarray` array, the sorting behavior for that attribute will be identical to the "trace" mode. The unspecified categories will follow the categories in `categoryarray`. Set `categoryorder` to "total ascending" or "total descending" if order should be determined by the numerical order of the values. Similarly, the order can be determined by the min, max, sum, mean or median of all the values.</param>
        /// <param name="CategoryArray">Sets the order in which categories on this axis appear. Only has an effect if `categoryorder` is set to "array". Used with `categoryorder`.</param>
        /// <param name="UIRevision">Controls persistence of user-driven changes in axis `range`, `autorange`, and `title` if in `editable: true` configuration. Defaults to `layout.uirevision`.</param>
        /// <param name="RangeSlider">Sets a range slider for this axis</param>
        /// <param name="RangeSelector">Sets a range selector for this axis. This object contains toggable presets for the rangeslider.</param>
        /// <param name="Calendar">Sets the calendar system to use for `range` and `tick0` if this is a date axis. This does not set the calendar for interpreting data on this axis, that's specified in the trace or via the global `layout.calendar`</param>
        static member init
            (
                ?Visible            : bool,
                ?Color              : string,
                ?Title              : Title,            
                ?AxisType           : StyleParam.AxisType, 
                ?AutoTypeNumbers    : StyleParam.AutoTypeNumbers,
                ?AutoRange          : StyleParam.AutoRange,        
                ?RangeMode          : StyleParam.RangeMode,        
                ?Range              : StyleParam.Range,            
                ?FixedRange         : bool,       
                ?ScaleAnchor        : StyleParam.LinearAxisId,
                ?ScaleRatio         : float,
                ?Constrain          : StyleParam.AxisConstraint,
                ?ConstrainToward    : StyleParam.AxisConstraintDirection,
                ?Matches            : StyleParam.LinearAxisId,
                ?Rangebreaks        : seq<Rangebreak>,
                ?TickMode           : StyleParam.TickMode,         
                ?NTicks             : int,           
                ?Tick0              : #IConvertible,            
                ?DTick              : #IConvertible,            
                ?TickVals           : seq<#IConvertible>,         
                ?TickText           : seq<#IConvertible>,         
                ?Ticks              : StyleParam.TickOptions,            
                ?TicksOn            : StyleParam.CategoryTickAnchor,
                ?TickLabelMode      : StyleParam.TickLabelMode,
                ?TickLabelPosition  : StyleParam.TickLabelPosition,
                ?TickLabelOverflow  : StyleParam.TickLabelOverflow,
                ?Mirror             : StyleParam.Mirror,           
                ?TickLen            : float,
                ?TickWidth          : float,        
                ?TickColor          : string,        
                ?ShowTickLabels     : bool,   
                ?AutoMargin         : bool,
                ?ShowSpikes         : bool,       
                ?SpikeColor         : string,       
                ?SpikeThickness     : int,   
                ?SpikeDash          : StyleParam.DrawingStyle,
                ?SpikeMode          : StyleParam.SpikeMode,
                ?SpikeSnap          : StyleParam.SpikeSnap,
                ?TickFont           : Font,         
                ?TickAngle          : int,        
                ?ShowTickPrefix     : StyleParam.ShowTickOption,   
                ?TickPrefix         : string,
                ?ShowTickSuffix     : StyleParam.ShowTickOption,
                ?TickSuffix         : string,
                ?ShowExponent       : StyleParam.ShowExponent,
                ?ExponentFormat     : StyleParam.ExponentFormat,
                ?MinExponent        : float,
                ?SeparateThousands  : bool,
                ?TickFormat         : string,       
                ?TickFormatStops    : seq<TickFormatStop>,
                ?HoverFormat        : string,
                ?ShowLine           : bool,         
                ?LineColor          : string,        
                ?LineWidth          : float,        
                ?ShowGrid           : bool,         
                ?GridColor          : string,        
                ?GridWidth          : float,        
                ?ZeroLine           : bool,         
                ?ZeroLineColor      : string,    
                ?ZeroLineWidth      : float,    
                ?ShowDividers       : bool,
                ?DividerColor       : string,
                ?DividerWidth       : int,
                ?Anchor             : StyleParam.LinearAxisId,
                ?Side               : StyleParam.Side,
                ?Overlaying         : StyleParam.LinearAxisId,
                ?Layer              : StyleParam.Layer,
                ?Domain             : StyleParam.Range,
                ?Position           : float,         
                ?CategoryOrder      : StyleParam.CategoryOrder,
                ?CategoryArray      : seq<#IConvertible>,
                ?UIRevision         : #IConvertible,
                ?RangeSlider        : RangeSlider,
                ?RangeSelector      : RangeSelector,
                ?Calendar           : StyleParam.Calendar

            ) =
                LinearAxis() 
                |> LinearAxis.style
                    (
                        ?Visible            = Visible            ,
                        ?Color              = Color              ,
                        ?Title              = Title              ,
                        ?AxisType           = AxisType           ,
                        ?AutoTypeNumbers    = AutoTypeNumbers    ,
                        ?AutoRange          = AutoRange          ,
                        ?RangeMode          = RangeMode          ,
                        ?Range              = Range              ,
                        ?FixedRange         = FixedRange         ,
                        ?ScaleAnchor        = ScaleAnchor        ,
                        ?ScaleRatio         = ScaleRatio         ,
                        ?Constrain          = Constrain          ,
                        ?ConstrainToward    = ConstrainToward    ,
                        ?Matches            = Matches            ,
                        ?Rangebreaks        = Rangebreaks        ,
                        ?TickMode           = TickMode           ,
                        ?NTicks             = NTicks             ,
                        ?Tick0              = Tick0              ,
                        ?DTick              = DTick              ,
                        ?TickVals           = TickVals           ,
                        ?TickText           = TickText           ,
                        ?Ticks              = Ticks              ,
                        ?TicksOn            = TicksOn            ,
                        ?TickLabelMode      = TickLabelMode      ,
                        ?TickLabelPosition  = TickLabelPosition  ,
                        ?TickLabelOverflow  = TickLabelOverflow  ,
                        ?Mirror             = Mirror             ,
                        ?TickLen            = TickLen            ,
                        ?TickWidth          = TickWidth          ,
                        ?TickColor          = TickColor          ,
                        ?ShowTickLabels     = ShowTickLabels     ,
                        ?AutoMargin         = AutoMargin         ,
                        ?ShowSpikes         = ShowSpikes         ,
                        ?SpikeColor         = SpikeColor         ,
                        ?SpikeThickness     = SpikeThickness     ,
                        ?SpikeDash          = SpikeDash          ,
                        ?SpikeMode          = SpikeMode          ,
                        ?SpikeSnap          = SpikeSnap          ,
                        ?TickFont           = TickFont           ,
                        ?TickAngle          = TickAngle          ,
                        ?ShowTickPrefix     = ShowTickPrefix     ,
                        ?TickPrefix         = TickPrefix         ,
                        ?ShowTickSuffix     = ShowTickSuffix     ,
                        ?TickSuffix         = TickSuffix         ,
                        ?ShowExponent       = ShowExponent       ,
                        ?ExponentFormat     = ExponentFormat     ,
                        ?MinExponent        = MinExponent        ,
                        ?SeparateThousands  = SeparateThousands  ,
                        ?TickFormat         = TickFormat         ,
                        ?TickFormatStops    = TickFormatStops    ,
                        ?HoverFormat        = HoverFormat        ,
                        ?ShowLine           = ShowLine           ,
                        ?LineColor          = LineColor          ,
                        ?LineWidth          = LineWidth          ,
                        ?ShowGrid           = ShowGrid           ,
                        ?GridColor          = GridColor          ,
                        ?GridWidth          = GridWidth          ,
                        ?ZeroLine           = ZeroLine           ,
                        ?ZeroLineColor      = ZeroLineColor      ,
                        ?ZeroLineWidth      = ZeroLineWidth      ,
                        ?ShowDividers       = ShowDividers       ,
                        ?DividerColor       = DividerColor       ,
                        ?DividerWidth       = DividerWidth       ,
                        ?Anchor             = Anchor             ,
                        ?Side               = Side               ,
                        ?Overlaying         = Overlaying         ,
                        ?Layer              = Layer              ,
                        ?Domain             = Domain             ,
                        ?Position           = Position           ,
                        ?CategoryOrder      = CategoryOrder      ,
                        ?CategoryArray      = CategoryArray      ,
                        ?UIRevision         = UIRevision         ,
                        ?RangeSlider        = RangeSlider        ,
                        ?RangeSelector      = RangeSelector      ,
                        ?Calendar           = Calendar           
                    )

        /// <summary>
        /// Initialize a categorical LinearAxis object that can be used as a positional scale for Y, X or Z coordinates.
        /// </summary>
        /// <param name="categoryOrder">Specifies the ordering logic for the case of categorical variables. By default, plotly uses "trace", which specifies the order that is present in the data supplied. Set `categoryorder` to "category ascending" or "category descending" if order should be determined by the alphanumerical order of the category names. Set `categoryorder` to "array" to derive the ordering from the attribute `categoryarray`. If a category is not found in the `categoryarray` array, the sorting behavior for that attribute will be identical to the "trace" mode. The unspecified categories will follow the categories in `categoryarray`. Set `categoryorder` to "total ascending" or "total descending" if order should be determined by the numerical order of the values. Similarly, the order can be determined by the min, max, sum, mean or median of all the values.</param>
        /// <param name="Visible">A single toggle to hide the axis while preserving interaction like dragging. Default is true when a cheater plot is present on the axis, otherwise false</param>
        /// <param name="Color">Sets default for all colors associated with this axis all at once: line, font, tick, and grid colors. Grid color is lightened by blending this with the plot background Individual pieces can override this.</param>
        /// <param name="Title">Sets the axis title.</param>
        /// <param name="AutoTypeNumbers">Using "strict" a numeric string in trace data is not converted to a number. Using "convert types" a numeric string in trace data may be treated as a number during automatic axis `type` detection. Defaults to layout.autotypenumbers.</param>
        /// <param name="AutoRange">Determines whether or not the range of this axis is computed in relation to the input data. See `rangemode` for more info. If `range` is provided, then `autorange` is set to "false".</param>
        /// <param name="RangeMode">If "normal", the range is computed in relation to the extrema of the input data. If "tozero"`, the range extends to 0, regardless of the input data If "nonnegative", the range is non-negative, regardless of the input data. Applies only to linear axes.</param>
        /// <param name="Range">Sets the range of this axis. If the axis `type` is "log", then you must take the log of your desired range (e.g. to set the range from 1 to 100, set the range from 0 to 2). If the axis `type` is "date", it should be date strings, like date data, though Date objects and unix milliseconds will be accepted and converted to strings. If the axis `type` is "category", it should be numbers, using the scale where each category is assigned a serial number from zero in the order it appears.</param>
        /// <param name="FixedRange">Determines whether or not this axis is zoom-able. If true, then zoom is disabled.</param>
        /// <param name="ScaleAnchor">If set to another axis id (e.g. `x2`, `y`), the range of this axis changes together with the range of the corresponding axis such that the scale of pixels per unit is in a constant ratio. Both axes are still zoomable, but when you zoom one, the other will zoom the same amount, keeping a fixed midpoint. `constrain` and `constraintoward` determine how we enforce the constraint. You can chain these, ie `yaxis: {scaleanchor: "x"}, xaxis2: {scaleanchor: "y"}` but you can only link axes of the same `type`. The linked axis can have the opposite letter (to constrain the aspect ratio) or the same letter (to match scales across subplots). Loops (`yaxis: {scaleanchor: "x"}, xaxis: {scaleanchor: "y"}` or longer) are redundant and the last constraint encountered will be ignored to avoid possible inconsistent constraints via `scaleratio`. Note that setting axes simultaneously in both a `scaleanchor` and a `matches` constraint is currently forbidden.</param>
        /// <param name="ScaleRatio">If this axis is linked to another by `scaleanchor`, this determines the pixel to unit scale ratio. For example, if this value is 10, then every unit on this axis spans 10 times the number of pixels as a unit on the linked axis. Use this for example to create an elevation profile where the vertical scale is exaggerated a fixed amount with respect to the horizontal.</param>
        /// <param name="Constrain">If this axis needs to be compressed (either due to its own `scaleanchor` and `scaleratio` or those of the other axis), determines how that happens: by increasing the "range", or by decreasing the "domain". Default is "domain" for axes containing image traces, "range" otherwise.</param>
        /// <param name="ConstrainToward">If this axis needs to be compressed (either due to its own `scaleanchor` and `scaleratio` or those of the other axis), determines which direction we push the originally specified plot area. Options are "left", "center" (default), and "right" for x axes, and "top", "middle" (default), and "bottom" for y axes.</param>
        /// <param name="Matches">If set to another axis id (e.g. `x2`, `y`), the range of this axis will match the range of the corresponding axis in data-coordinates space. Moreover, matching axes share auto-range values, category lists and histogram auto-bins. Note that setting axes simultaneously in both a `scaleanchor` and a `matches` constraint is currently forbidden. Moreover, note that matching axes must have the same `type`.</param>
        /// <param name="Rangebreaks">Sets breaks in the axis range</param>
        /// <param name="TickMode">Sets the tick mode for this axis. If "auto", the number of ticks is set via `nticks`. If "linear", the placement of the ticks is determined by a starting position `tick0` and a tick step `dtick` ("linear" is the default value if `tick0` and `dtick` are provided). If "array", the placement of the ticks is set via `TickVals` and the tick text is `TickText`. ("array" is the default value if `TickVals` is provided).</param>
        /// <param name="NTicks">Specifies the maximum number of ticks for the particular axis. The actual number of ticks will be chosen automatically to be less than or equal to `nticks`. Has an effect only if `tickmode` is set to "auto".</param>
        /// <param name="Tick0">Sets the placement of the first tick on this axis. Use with `dtick`. If the axis `type` is "log", then you must take the log of your starting tick (e.g. to set the starting tick to 100, set the `tick0` to 2) except when `dtick`="L&lt;f&gt;" (see `dtick` for more info). If the axis `type` is "date", it should be a date string, like date data. If the axis `type` is "category", it should be a number, using the scale where each category is assigned a serial number from zero in the order it appears.</param>
        /// <param name="DTick">Sets the step in-between ticks on this axis. Use with `tick0`. Must be a positive number, or special strings available to "log" and "date" axes. If the axis `type` is "log", then ticks are set every 10^(n"dtick) where n is the tick number. For example, to set a tick mark at 1, 10, 100, 1000, ... set dtick to 1. To set tick marks at 1, 100, 10000, ... set dtick to 2. To set tick marks at 1, 5, 25, 125, 625, 3125, ... set dtick to log_10(5), or 0.69897000433. "log" has several special values; "L&lt;f&gt;", where `f` is a positive number, gives ticks linearly spaced in value (but not position). For example `tick0` = 0.1, `dtick` = "L0.5" will put ticks at 0.1, 0.6, 1.1, 1.6 etc. To show powers of 10 plus small digits between, use "D1" (all digits) or "D2" (only 2 and 5). `tick0` is ignored for "D1" and "D2". If the axis `type` is "date", then you must convert the time to milliseconds. For example, to set the interval between ticks to one day, set `dtick` to 86400000.0. "date" also has special values "M&lt;n&gt;" gives ticks spaced by a number of months. `n` must be a positive integer. To set ticks on the 15th of every third month, set `tick0` to "2000-01-15" and `dtick` to "M3". To set ticks every 4 years, set `dtick` to "M48"</param>
        /// <param name="TickVals">Sets the values at which ticks on this axis appear. Only has an effect if `tickmode` is set to "array". Used with `TickText`.</param>
        /// <param name="TickText">Sets the text displayed at the ticks position via `TickVals`. Only has an effect if `tickmode` is set to "array". Used with `TickVals`.</param>
        /// <param name="Ticks">Determines whether ticks are drawn or not. If "", this axis' ticks are not drawn. If "outside" ("inside"), this axis' are drawn outside (inside) the axis lines.</param>
        /// <param name="TicksOn">Determines where ticks and grid lines are drawn with respect to their corresponding tick labels. Only has an effect for axes of `type` "category" or "multicategory". When set to "boundaries", ticks and grid lines are drawn half a category to the left/bottom of labels.</param>
        /// <param name="TickLabelMode">Determines where tick labels are drawn with respect to their corresponding ticks and grid lines. Only has an effect for axes of `type` "date" When set to "period", tick labels are drawn in the middle of the period between ticks.</param>
        /// <param name="TickLabelPosition">Determines where tick labels are drawn with respect to the axis Please note that top or bottom has no effect on x axes or when `ticklabelmode` is set to "period". Similarly left or right has no effect on y axes or when `ticklabelmode` is set to "period". Has no effect on "multicategory" axes or when `tickson` is set to "boundaries". When used on axes linked by `matches` or `scaleanchor`, no extra padding for inside labels would be added by autorange, so that the scales could match.</param>
        /// <param name="TickLabelOverflow">Determines how we handle tick labels that would overflow either the graph div or the domain of the axis. The default value for inside tick labels is "hide past domain". Otherwise on "category" and "multicategory" axes the default is "allow". In other cases the default is "hide past div".</param>
        /// <param name="Mirror">Determines if the axis lines or/and ticks are mirrored to the opposite side of the plotting area. If "true", the axis lines are mirrored. If "ticks", the axis lines and ticks are mirrored. If "false", mirroring is disable. If "all", axis lines are mirrored on all shared-axes subplots. If "allticks", axis lines and ticks are mirrored on all shared-axes subplots.</param>
        /// <param name="TickLen">Sets the tick length (in px).</param>
        /// <param name="TickWidth">Sets the tick width (in px).</param>
        /// <param name="TickColor">Sets the tick color.</param>
        /// <param name="ShowTickLabels">Determines whether or not the tick labels are drawn.</param>
        /// <param name="AutoMargin">Determines whether long tick labels automatically grow the figure margins.</param>
        /// <param name="ShowSpikes">Determines whether or not spikes (aka droplines) are drawn for this axis. Note: This only takes affect when hovermode = closest</param>
        /// <param name="SpikeColor">Sets the spike color. If undefined, will use the series color</param>
        /// <param name="SpikeThickness">Sets the width (in px) of the zero line.</param>
        /// <param name="SpikeDash">Sets the dash style of lines</param>
        /// <param name="SpikeMode">Determines the drawing mode for the spike line If "toaxis", the line is drawn from the data point to the axis the series is plotted on. If "across", the line is drawn across the entire plot area, and supercedes "toaxis". If "marker", then a marker dot is drawn on the axis the series is plotted on</param>
        /// <param name="SpikeSnap">Determines whether spikelines are stuck to the cursor or to the closest datapoints.</param>
        /// <param name="TickFont">Sets the tick font.</param>
        /// <param name="TickAngle">Sets the angle of the tick labels with respect to the horizontal. For example, a `tickangle` of -90 draws the tick labels vertically.</param>
        /// <param name="ShowTickPrefix">If "all", all tick labels are displayed with a prefix. If "first", only the first tick is displayed with a prefix. If "last", only the last tick is displayed with a suffix. If "none", tick prefixes are hidden.</param>
        /// <param name="TickPrefix">Sets a tick label prefix.</param>
        /// <param name="ShowTickSuffix">Same as `showtickprefix` but for tick suffixes.</param>
        /// <param name="TickSuffix">Sets a tick label suffix.</param>
        /// <param name="ShowExponent">If "all", all exponents are shown besides their significands. If "first", only the exponent of the first tick is shown. If "last", only the exponent of the last tick is shown. If "none", no exponents appear.</param>
        /// <param name="ExponentFormat">Determines a formatting rule for the tick exponents. For example, consider the number 1,000,000,000. If "none", it appears as 1,000,000,000. If "e", 1e+9. If "E", 1E+9. If "power", 1x10^9 (with 9 in a super script). If "SI", 1G. If "B", 1B.</param>
        /// <param name="MinExponent">Hide SI prefix for 10^n if |n| is below this number. This only has an effect when `TickFormat` is "SI" or "B".</param>
        /// <param name="SeparateThousands">If "true", even 4-digit integers are separated</param>
        /// <param name="TickFormat">Sets the tick label formatting rule using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-3.x-api-reference/blob/master/Formatting.md#d3_format. And for dates see: https://github.com/d3/d3-time-format#locale_format. We add two items to d3's date formatter: "%h" for half of the year as a decimal number as well as "%{n}f" for fractional seconds with n digits. For example, "2016-10-13 09:15:23.456" with TickFormat "%H~%M~%S.%2f" would display "09~15~23.46"</param>
        /// <param name="TickFormatStops">Set rules for customizing TickFormat on different zoom levels</param>
        /// <param name="HoverFormat">Sets the hover text formatting rule using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-3.x-api-reference/blob/master/Formatting.md#d3_format. And for dates see: https://github.com/d3/d3-time-format#locale_format. We add two items to d3's date formatter: "%h" for half of the year as a decimal number as well as "%{n}f" for fractional seconds with n digits. For example, "2016-10-13 09:15:23.456" with TickFormat "%H~%M~%S.%2f" would display "09~15~23.46"</param>
        /// <param name="ShowLine">Determines whether or not a line bounding this axis is drawn.</param>
        /// <param name="LineColor">Sets the axis line color.</param>
        /// <param name="LineWidth">Sets the width (in px) of the axis line.</param>
        /// <param name="ShowGrid">Determines whether or not grid lines are drawn. If "true", the grid lines are drawn at every tick mark.</param>
        /// <param name="GridColor">Sets the color of the grid lines.</param>
        /// <param name="GridWidth">Sets the width (in px) of the grid lines.</param>
        /// <param name="ZeroLine">Determines whether or not a line is drawn at along the 0 value of this axis. If "true", the zero line is drawn on top of the grid lines.</param>
        /// <param name="ZeroLineColor">Sets the line color of the zero line.</param>
        /// <param name="ZeroLineWidth">Sets the width (in px) of the zero line.</param>
        /// <param name="ShowDividers">Determines whether or not a dividers are drawn between the category levels of this axis. Only has an effect on "multicategory" axes.</param>
        /// <param name="DividerColor">Sets the color of the dividers Only has an effect on "multicategory" axes.</param>
        /// <param name="DividerWidth">Sets the width (in px) of the dividers Only has an effect on "multicategory" axes.</param>
        /// <param name="Anchor">If set to an opposite-letter axis id (e.g. `x2`, `y`), this axis is bound to the corresponding opposite-letter axis. If set to "free", this axis' position is determined by `position`.</param>
        /// <param name="Side">Determines whether a x (y) axis is positioned at the "bottom" ("left") or "top" ("right") of the plotting area.</param>
        /// <param name="Overlaying">If set a same-letter axis id, this axis is overlaid on top of the corresponding same-letter axis, with traces and axes visible for both axes. If "false", this axis does not overlay any same-letter axes. In this case, for axes with overlapping domains only the highest-numbered axis will be visible.</param>
        /// <param name="Layer">Sets the layer on which this axis is displayed. If "above traces", this axis is displayed above all the subplot's traces If "below traces", this axis is displayed below all the subplot's traces, but above the grid lines. Useful when used together with scatter-like traces with `cliponaxis` set to "false" to show markers and/or text nodes above this axis.</param>
        /// <param name="Domain">Sets the domain of this axis (in plot fraction).</param>
        /// <param name="Position">Sets the position of this axis in the plotting space (in normalized coordinates). Only has an effect if `anchor` is set to "free".</param>
        /// <param name="CategoryArray">Sets the order in which categories on this axis appear. Only has an effect if `categoryorder` is set to "array". Used with `categoryorder`.</param>
        /// <param name="UIRevision">Controls persistence of user-driven changes in axis `range`, `autorange`, and `title` if in `editable: true` configuration. Defaults to `layout.uirevision`.</param>
        /// <param name="RangeSlider">Sets a range slider for this axis</param>
        /// <param name="RangeSelector">Sets a range selector for this axis. This object contains toggable presets for the rangeslider.</param>
        /// <param name="Calendar">Sets the calendar system to use for `range` and `tick0` if this is a date axis. This does not set the calendar for interpreting data on this axis, that's specified in the trace or via the global `layout.calendar`</param>
        static member initCategorical
            (
                categoryOrder       : StyleParam.CategoryOrder,
                ?Visible            : bool,
                ?Color              : string,
                ?Title              : Title,            
                ?AutoTypeNumbers    : StyleParam.AutoTypeNumbers,
                ?AutoRange          : StyleParam.AutoRange,        
                ?RangeMode          : StyleParam.RangeMode,        
                ?Range              : StyleParam.Range,            
                ?FixedRange         : bool,       
                ?ScaleAnchor        : StyleParam.LinearAxisId,
                ?ScaleRatio         : float,
                ?Constrain          : StyleParam.AxisConstraint,
                ?ConstrainToward    : StyleParam.AxisConstraintDirection,
                ?Matches            : StyleParam.LinearAxisId,
                ?Rangebreaks        : seq<Rangebreak>,
                ?TickMode           : StyleParam.TickMode,         
                ?NTicks             : int,           
                ?Tick0              : #IConvertible,            
                ?DTick              : #IConvertible,            
                ?TickVals           : seq<#IConvertible>,         
                ?TickText           : seq<#IConvertible>,         
                ?Ticks              : StyleParam.TickOptions,            
                ?TicksOn            : StyleParam.CategoryTickAnchor,
                ?TickLabelMode      : StyleParam.TickLabelMode,
                ?TickLabelPosition  : StyleParam.TickLabelPosition,
                ?TickLabelOverflow  : StyleParam.TickLabelOverflow,
                ?Mirror             : StyleParam.Mirror,           
                ?TickLen            : float,
                ?TickWidth          : float,        
                ?TickColor          : string,        
                ?ShowTickLabels     : bool,   
                ?AutoMargin         : bool,
                ?ShowSpikes         : bool,       
                ?SpikeColor         : string,       
                ?SpikeThickness     : int,   
                ?SpikeDash          : StyleParam.DrawingStyle,
                ?SpikeMode          : StyleParam.SpikeMode,
                ?SpikeSnap          : StyleParam.SpikeSnap,
                ?TickFont           : Font,         
                ?TickAngle          : int,        
                ?ShowTickPrefix     : StyleParam.ShowTickOption,   
                ?TickPrefix         : string,
                ?ShowTickSuffix     : StyleParam.ShowTickOption,
                ?TickSuffix         : string,
                ?ShowExponent       : StyleParam.ShowExponent,
                ?ExponentFormat     : StyleParam.ExponentFormat,
                ?MinExponent        : float,
                ?SeparateThousands  : bool,
                ?TickFormat         : string,       
                ?TickFormatStops    : seq<TickFormatStop>,
                ?HoverFormat        : string,
                ?ShowLine           : bool,         
                ?LineColor          : string,        
                ?LineWidth          : float,        
                ?ShowGrid           : bool,         
                ?GridColor          : string,        
                ?GridWidth          : float,        
                ?ZeroLine           : bool,         
                ?ZeroLineColor      : string,    
                ?ZeroLineWidth      : float,    
                ?ShowDividers       : bool,
                ?DividerColor       : string,
                ?DividerWidth       : int,
                ?Anchor             : StyleParam.LinearAxisId,
                ?Side               : StyleParam.Side,
                ?Overlaying         : StyleParam.LinearAxisId,
                ?Layer              : StyleParam.Layer,
                ?Domain             : StyleParam.Range,
                ?Position           : float,         
                ?CategoryArray      : seq<#IConvertible>,
                ?UIRevision         : #IConvertible,
                ?RangeSlider        : RangeSlider,
                ?RangeSelector      : RangeSelector,
                ?Calendar           : StyleParam.Calendar
            ) =
                LinearAxis() 
                |> LinearAxis.style
                    (
                        CategoryOrder       = categoryOrder,
                        AxisType            = StyleParam.AxisType.Category,
                        ?Visible            = Visible            ,
                        ?Color              = Color              ,
                        ?Title              = Title              ,
                        ?AutoTypeNumbers    = AutoTypeNumbers    ,
                        ?AutoRange          = AutoRange          ,
                        ?RangeMode          = RangeMode          ,
                        ?Range              = Range              ,
                        ?FixedRange         = FixedRange         ,
                        ?ScaleAnchor        = ScaleAnchor        ,
                        ?ScaleRatio         = ScaleRatio         ,
                        ?Constrain          = Constrain          ,
                        ?ConstrainToward    = ConstrainToward    ,
                        ?Matches            = Matches            ,
                        ?Rangebreaks        = Rangebreaks        ,
                        ?TickMode           = TickMode           ,
                        ?NTicks             = NTicks             ,
                        ?Tick0              = Tick0              ,
                        ?DTick              = DTick              ,
                        ?TickVals           = TickVals           ,
                        ?TickText           = TickText           ,
                        ?Ticks              = Ticks              ,
                        ?TicksOn            = TicksOn            ,
                        ?TickLabelMode      = TickLabelMode      ,
                        ?TickLabelPosition  = TickLabelPosition  ,
                        ?TickLabelOverflow  = TickLabelOverflow  ,
                        ?Mirror             = Mirror             ,
                        ?TickLen            = TickLen            ,
                        ?TickWidth          = TickWidth          ,
                        ?TickColor          = TickColor          ,
                        ?ShowTickLabels     = ShowTickLabels     ,
                        ?AutoMargin         = AutoMargin         ,
                        ?ShowSpikes         = ShowSpikes         ,
                        ?SpikeColor         = SpikeColor         ,
                        ?SpikeThickness     = SpikeThickness     ,
                        ?SpikeDash          = SpikeDash          ,
                        ?SpikeMode          = SpikeMode          ,
                        ?SpikeSnap          = SpikeSnap          ,
                        ?TickFont           = TickFont           ,
                        ?TickAngle          = TickAngle          ,
                        ?ShowTickPrefix     = ShowTickPrefix     ,
                        ?TickPrefix         = TickPrefix         ,
                        ?ShowTickSuffix     = ShowTickSuffix     ,
                        ?TickSuffix         = TickSuffix         ,
                        ?ShowExponent       = ShowExponent       ,
                        ?ExponentFormat     = ExponentFormat     ,
                        ?MinExponent        = MinExponent        ,
                        ?SeparateThousands  = SeparateThousands  ,
                        ?TickFormat         = TickFormat         ,
                        ?TickFormatStops    = TickFormatStops    ,
                        ?HoverFormat        = HoverFormat        ,
                        ?ShowLine           = ShowLine           ,
                        ?LineColor          = LineColor          ,
                        ?LineWidth          = LineWidth          ,
                        ?ShowGrid           = ShowGrid           ,
                        ?GridColor          = GridColor          ,
                        ?GridWidth          = GridWidth          ,
                        ?ZeroLine           = ZeroLine           ,
                        ?ZeroLineColor      = ZeroLineColor      ,
                        ?ZeroLineWidth      = ZeroLineWidth      ,
                        ?ShowDividers       = ShowDividers       ,
                        ?DividerColor       = DividerColor       ,
                        ?DividerWidth       = DividerWidth       ,
                        ?Anchor             = Anchor             ,
                        ?Side               = Side               ,
                        ?Overlaying         = Overlaying         ,
                        ?Layer              = Layer              ,
                        ?Domain             = Domain             ,
                        ?Position           = Position           ,
                        ?CategoryArray      = CategoryArray      ,
                        ?UIRevision         = UIRevision         ,
                        ?RangeSlider        = RangeSlider        ,
                        ?RangeSelector      = RangeSelector      ,
                        ?Calendar           = Calendar           
                    )

        /// <summary>
        /// Create a function that applies the given style parameters to a LinearAxis object
        /// </summary>
        /// <param name="Visible">A single toggle to hide the axis while preserving interaction like dragging. Default is true when a cheater plot is present on the axis, otherwise false</param>
        /// <param name="Color">Sets default for all colors associated with this axis all at once: line, font, tick, and grid colors. Grid color is lightened by blending this with the plot background Individual pieces can override this.</param>
        /// <param name="Title">Sets the axis title.</param>
        /// <param name="AxisType">Sets the axis type. By default, plotly attempts to determined the axis type by looking into the data of the traces that referenced the axis in question.</param>
        /// <param name="AutoTypeNumbers">Using "strict" a numeric string in trace data is not converted to a number. Using "convert types" a numeric string in trace data may be treated as a number during automatic axis `type` detection. Defaults to layout.autotypenumbers.</param>
        /// <param name="AutoRange">Determines whether or not the range of this axis is computed in relation to the input data. See `rangemode` for more info. If `range` is provided, then `autorange` is set to "false".</param>
        /// <param name="RangeMode">If "normal", the range is computed in relation to the extrema of the input data. If "tozero"`, the range extends to 0, regardless of the input data If "nonnegative", the range is non-negative, regardless of the input data. Applies only to linear axes.</param>
        /// <param name="Range">Sets the range of this axis. If the axis `type` is "log", then you must take the log of your desired range (e.g. to set the range from 1 to 100, set the range from 0 to 2). If the axis `type` is "date", it should be date strings, like date data, though Date objects and unix milliseconds will be accepted and converted to strings. If the axis `type` is "category", it should be numbers, using the scale where each category is assigned a serial number from zero in the order it appears.</param>
        /// <param name="FixedRange">Determines whether or not this axis is zoom-able. If true, then zoom is disabled.</param>
        /// <param name="ScaleAnchor">If set to another axis id (e.g. `x2`, `y`), the range of this axis changes together with the range of the corresponding axis such that the scale of pixels per unit is in a constant ratio. Both axes are still zoomable, but when you zoom one, the other will zoom the same amount, keeping a fixed midpoint. `constrain` and `constraintoward` determine how we enforce the constraint. You can chain these, ie `yaxis: {scaleanchor: "x"}, xaxis2: {scaleanchor: "y"}` but you can only link axes of the same `type`. The linked axis can have the opposite letter (to constrain the aspect ratio) or the same letter (to match scales across subplots). Loops (`yaxis: {scaleanchor: "x"}, xaxis: {scaleanchor: "y"}` or longer) are redundant and the last constraint encountered will be ignored to avoid possible inconsistent constraints via `scaleratio`. Note that setting axes simultaneously in both a `scaleanchor` and a `matches` constraint is currently forbidden.</param>
        /// <param name="ScaleRatio">If this axis is linked to another by `scaleanchor`, this determines the pixel to unit scale ratio. For example, if this value is 10, then every unit on this axis spans 10 times the number of pixels as a unit on the linked axis. Use this for example to create an elevation profile where the vertical scale is exaggerated a fixed amount with respect to the horizontal.</param>
        /// <param name="Constrain">If this axis needs to be compressed (either due to its own `scaleanchor` and `scaleratio` or those of the other axis), determines how that happens: by increasing the "range", or by decreasing the "domain". Default is "domain" for axes containing image traces, "range" otherwise.</param>
        /// <param name="ConstrainToward">If this axis needs to be compressed (either due to its own `scaleanchor` and `scaleratio` or those of the other axis), determines which direction we push the originally specified plot area. Options are "left", "center" (default), and "right" for x axes, and "top", "middle" (default), and "bottom" for y axes.</param>
        /// <param name="Matches">If set to another axis id (e.g. `x2`, `y`), the range of this axis will match the range of the corresponding axis in data-coordinates space. Moreover, matching axes share auto-range values, category lists and histogram auto-bins. Note that setting axes simultaneously in both a `scaleanchor` and a `matches` constraint is currently forbidden. Moreover, note that matching axes must have the same `type`.</param>
        /// <param name="Rangebreaks">Sets breaks in the axis range</param>
        /// <param name="TickMode">Sets the tick mode for this axis. If "auto", the number of ticks is set via `nticks`. If "linear", the placement of the ticks is determined by a starting position `tick0` and a tick step `dtick` ("linear" is the default value if `tick0` and `dtick` are provided). If "array", the placement of the ticks is set via `TickVals` and the tick text is `TickText`. ("array" is the default value if `TickVals` is provided).</param>
        /// <param name="NTicks">Specifies the maximum number of ticks for the particular axis. The actual number of ticks will be chosen automatically to be less than or equal to `nticks`. Has an effect only if `tickmode` is set to "auto".</param>
        /// <param name="Tick0">Sets the placement of the first tick on this axis. Use with `dtick`. If the axis `type` is "log", then you must take the log of your starting tick (e.g. to set the starting tick to 100, set the `tick0` to 2) except when `dtick`="L&lt;f&gt;" (see `dtick` for more info). If the axis `type` is "date", it should be a date string, like date data. If the axis `type` is "category", it should be a number, using the scale where each category is assigned a serial number from zero in the order it appears.</param>
        /// <param name="DTick">Sets the step in-between ticks on this axis. Use with `tick0`. Must be a positive number, or special strings available to "log" and "date" axes. If the axis `type` is "log", then ticks are set every 10^(n"dtick) where n is the tick number. For example, to set a tick mark at 1, 10, 100, 1000, ... set dtick to 1. To set tick marks at 1, 100, 10000, ... set dtick to 2. To set tick marks at 1, 5, 25, 125, 625, 3125, ... set dtick to log_10(5), or 0.69897000433. "log" has several special values; "L&lt;f&gt;", where `f` is a positive number, gives ticks linearly spaced in value (but not position). For example `tick0` = 0.1, `dtick` = "L0.5" will put ticks at 0.1, 0.6, 1.1, 1.6 etc. To show powers of 10 plus small digits between, use "D1" (all digits) or "D2" (only 2 and 5). `tick0` is ignored for "D1" and "D2". If the axis `type` is "date", then you must convert the time to milliseconds. For example, to set the interval between ticks to one day, set `dtick` to 86400000.0. "date" also has special values "M&lt;n&gt;" gives ticks spaced by a number of months. `n` must be a positive integer. To set ticks on the 15th of every third month, set `tick0` to "2000-01-15" and `dtick` to "M3". To set ticks every 4 years, set `dtick` to "M48"</param>
        /// <param name="TickVals">Sets the values at which ticks on this axis appear. Only has an effect if `tickmode` is set to "array". Used with `TickText`.</param>
        /// <param name="TickText">Sets the text displayed at the ticks position via `TickVals`. Only has an effect if `tickmode` is set to "array". Used with `TickVals`.</param>
        /// <param name="Ticks">Determines whether ticks are drawn or not. If "", this axis' ticks are not drawn. If "outside" ("inside"), this axis' are drawn outside (inside) the axis lines.</param>
        /// <param name="TicksOn">Determines where ticks and grid lines are drawn with respect to their corresponding tick labels. Only has an effect for axes of `type` "category" or "multicategory". When set to "boundaries", ticks and grid lines are drawn half a category to the left/bottom of labels.</param>
        /// <param name="TickLabelMode">Determines where tick labels are drawn with respect to their corresponding ticks and grid lines. Only has an effect for axes of `type` "date" When set to "period", tick labels are drawn in the middle of the period between ticks.</param>
        /// <param name="TickLabelPosition">Determines where tick labels are drawn with respect to the axis Please note that top or bottom has no effect on x axes or when `ticklabelmode` is set to "period". Similarly left or right has no effect on y axes or when `ticklabelmode` is set to "period". Has no effect on "multicategory" axes or when `tickson` is set to "boundaries". When used on axes linked by `matches` or `scaleanchor`, no extra padding for inside labels would be added by autorange, so that the scales could match.</param>
        /// <param name="TickLabelOverflow">Determines how we handle tick labels that would overflow either the graph div or the domain of the axis. The default value for inside tick labels is "hide past domain". Otherwise on "category" and "multicategory" axes the default is "allow". In other cases the default is "hide past div".</param>
        /// <param name="Mirror">Determines if the axis lines or/and ticks are mirrored to the opposite side of the plotting area. If "true", the axis lines are mirrored. If "ticks", the axis lines and ticks are mirrored. If "false", mirroring is disable. If "all", axis lines are mirrored on all shared-axes subplots. If "allticks", axis lines and ticks are mirrored on all shared-axes subplots.</param>
        /// <param name="TickLen">Sets the tick length (in px).</param>
        /// <param name="TickWidth">Sets the tick width (in px).</param>
        /// <param name="TickColor">Sets the tick color.</param>
        /// <param name="ShowTickLabels">Determines whether or not the tick labels are drawn.</param>
        /// <param name="AutoMargin">Determines whether long tick labels automatically grow the figure margins.</param>
        /// <param name="ShowSpikes">Determines whether or not spikes (aka droplines) are drawn for this axis. Note: This only takes affect when hovermode = closest</param>
        /// <param name="SpikeColor">Sets the spike color. If undefined, will use the series color</param>
        /// <param name="SpikeThickness">Sets the width (in px) of the zero line.</param>
        /// <param name="SpikeDash">Sets the dash style of lines</param>
        /// <param name="SpikeMode">Determines the drawing mode for the spike line If "toaxis", the line is drawn from the data point to the axis the series is plotted on. If "across", the line is drawn across the entire plot area, and supercedes "toaxis". If "marker", then a marker dot is drawn on the axis the series is plotted on</param>
        /// <param name="SpikeSnap">Determines whether spikelines are stuck to the cursor or to the closest datapoints.</param>
        /// <param name="TickFont">Sets the tick font.</param>
        /// <param name="TickAngle">Sets the angle of the tick labels with respect to the horizontal. For example, a `tickangle` of -90 draws the tick labels vertically.</param>
        /// <param name="ShowTickPrefix">If "all", all tick labels are displayed with a prefix. If "first", only the first tick is displayed with a prefix. If "last", only the last tick is displayed with a suffix. If "none", tick prefixes are hidden.</param>
        /// <param name="TickPrefix">Sets a tick label prefix.</param>
        /// <param name="ShowTickSuffix">Same as `showtickprefix` but for tick suffixes.</param>
        /// <param name="TickSuffix">Sets a tick label suffix.</param>
        /// <param name="ShowExponent">If "all", all exponents are shown besides their significands. If "first", only the exponent of the first tick is shown. If "last", only the exponent of the last tick is shown. If "none", no exponents appear.</param>
        /// <param name="ExponentFormat">Determines a formatting rule for the tick exponents. For example, consider the number 1,000,000,000. If "none", it appears as 1,000,000,000. If "e", 1e+9. If "E", 1E+9. If "power", 1x10^9 (with 9 in a super script). If "SI", 1G. If "B", 1B.</param>
        /// <param name="MinExponent">Hide SI prefix for 10^n if |n| is below this number. This only has an effect when `TickFormat` is "SI" or "B".</param>
        /// <param name="SeparateThousands">If "true", even 4-digit integers are separated</param>
        /// <param name="TickFormat">Sets the tick label formatting rule using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-3.x-api-reference/blob/master/Formatting.md#d3_format. And for dates see: https://github.com/d3/d3-time-format#locale_format. We add two items to d3's date formatter: "%h" for half of the year as a decimal number as well as "%{n}f" for fractional seconds with n digits. For example, "2016-10-13 09:15:23.456" with TickFormat "%H~%M~%S.%2f" would display "09~15~23.46"</param>
        /// <param name="TickFormatStops">Set rules for customizing TickFormat on different zoom levels</param>
        /// <param name="HoverFormat">Sets the hover text formatting rule using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-3.x-api-reference/blob/master/Formatting.md#d3_format. And for dates see: https://github.com/d3/d3-time-format#locale_format. We add two items to d3's date formatter: "%h" for half of the year as a decimal number as well as "%{n}f" for fractional seconds with n digits. For example, "2016-10-13 09:15:23.456" with TickFormat "%H~%M~%S.%2f" would display "09~15~23.46"</param>
        /// <param name="ShowLine">Determines whether or not a line bounding this axis is drawn.</param>
        /// <param name="LineColor">Sets the axis line color.</param>
        /// <param name="LineWidth">Sets the width (in px) of the axis line.</param>
        /// <param name="ShowGrid">Determines whether or not grid lines are drawn. If "true", the grid lines are drawn at every tick mark.</param>
        /// <param name="GridColor">Sets the color of the grid lines.</param>
        /// <param name="GridWidth">Sets the width (in px) of the grid lines.</param>
        /// <param name="ZeroLine">Determines whether or not a line is drawn at along the 0 value of this axis. If "true", the zero line is drawn on top of the grid lines.</param>
        /// <param name="ZeroLineColor">Sets the line color of the zero line.</param>
        /// <param name="ZeroLineWidth">Sets the width (in px) of the zero line.</param>
        /// <param name="ShowDividers">Determines whether or not a dividers are drawn between the category levels of this axis. Only has an effect on "multicategory" axes.</param>
        /// <param name="DividerColor">Sets the color of the dividers Only has an effect on "multicategory" axes.</param>
        /// <param name="DividerWidth">Sets the width (in px) of the dividers Only has an effect on "multicategory" axes.</param>
        /// <param name="Anchor">If set to an opposite-letter axis id (e.g. `x2`, `y`), this axis is bound to the corresponding opposite-letter axis. If set to "free", this axis' position is determined by `position`.</param>
        /// <param name="Side">Determines whether a x (y) axis is positioned at the "bottom" ("left") or "top" ("right") of the plotting area.</param>
        /// <param name="Overlaying">If set a same-letter axis id, this axis is overlaid on top of the corresponding same-letter axis, with traces and axes visible for both axes. If "false", this axis does not overlay any same-letter axes. In this case, for axes with overlapping domains only the highest-numbered axis will be visible.</param>
        /// <param name="Layer">Sets the layer on which this axis is displayed. If "above traces", this axis is displayed above all the subplot's traces If "below traces", this axis is displayed below all the subplot's traces, but above the grid lines. Useful when used together with scatter-like traces with `cliponaxis` set to "false" to show markers and/or text nodes above this axis.</param>
        /// <param name="Domain">Sets the domain of this axis (in plot fraction).</param>
        /// <param name="Position">Sets the position of this axis in the plotting space (in normalized coordinates). Only has an effect if `anchor` is set to "free".</param>
        /// <param name="CategoryOrder">Specifies the ordering logic for the case of categorical variables. By default, plotly uses "trace", which specifies the order that is present in the data supplied. Set `categoryorder` to "category ascending" or "category descending" if order should be determined by the alphanumerical order of the category names. Set `categoryorder` to "array" to derive the ordering from the attribute `categoryarray`. If a category is not found in the `categoryarray` array, the sorting behavior for that attribute will be identical to the "trace" mode. The unspecified categories will follow the categories in `categoryarray`. Set `categoryorder` to "total ascending" or "total descending" if order should be determined by the numerical order of the values. Similarly, the order can be determined by the min, max, sum, mean or median of all the values.</param>
        /// <param name="CategoryArray">Sets the order in which categories on this axis appear. Only has an effect if `categoryorder` is set to "array". Used with `categoryorder`.</param>
        /// <param name="UIRevision">Controls persistence of user-driven changes in axis `range`, `autorange`, and `title` if in `editable: true` configuration. Defaults to `layout.uirevision`.</param>
        /// <param name="RangeSlider">Sets a range slider for this axis</param>
        /// <param name="RangeSelector">Sets a range selector for this axis. This object contains toggable presets for the rangeslider.</param>
        /// <param name="Calendar">Sets the calendar system to use for `range` and `tick0` if this is a date axis. This does not set the calendar for interpreting data on this axis, that's specified in the trace or via the global `layout.calendar`</param>
        static member style
            (
                ?Visible            : bool,
                ?Color              : string,
                ?Title              : Title,            
                ?AxisType           : StyleParam.AxisType, 
                ?AutoTypeNumbers    : StyleParam.AutoTypeNumbers,
                ?AutoRange          : StyleParam.AutoRange,        
                ?RangeMode          : StyleParam.RangeMode,        
                ?Range              : StyleParam.Range,            
                ?FixedRange         : bool,       
                ?ScaleAnchor        : StyleParam.LinearAxisId,
                ?ScaleRatio         : float,
                ?Constrain          : StyleParam.AxisConstraint,
                ?ConstrainToward    : StyleParam.AxisConstraintDirection,
                ?Matches            : StyleParam.LinearAxisId,
                ?Rangebreaks        : seq<Rangebreak>,
                ?TickMode           : StyleParam.TickMode,         
                ?NTicks             : int,           
                ?Tick0              : #IConvertible,            
                ?DTick              : #IConvertible,            
                ?TickVals           : seq<#IConvertible>,         
                ?TickText           : seq<#IConvertible>,         
                ?Ticks              : StyleParam.TickOptions,            
                ?TicksOn            : StyleParam.CategoryTickAnchor,
                ?TickLabelMode      : StyleParam.TickLabelMode,
                ?TickLabelPosition  : StyleParam.TickLabelPosition,
                ?TickLabelOverflow  : StyleParam.TickLabelOverflow,
                ?Mirror             : StyleParam.Mirror,           
                ?TickLen            : float,
                ?TickWidth          : float,        
                ?TickColor          : string,        
                ?ShowTickLabels     : bool,   
                ?AutoMargin         : bool,
                ?ShowSpikes         : bool,       
                ?SpikeColor         : string,       
                ?SpikeThickness     : int,   
                ?SpikeDash          : StyleParam.DrawingStyle,
                ?SpikeMode          : StyleParam.SpikeMode,
                ?SpikeSnap          : StyleParam.SpikeSnap,
                ?TickFont           : Font,         
                ?TickAngle          : int,        
                ?ShowTickPrefix     : StyleParam.ShowTickOption,   
                ?TickPrefix         : string,
                ?ShowTickSuffix     : StyleParam.ShowTickOption,
                ?TickSuffix         : string,
                ?ShowExponent       : StyleParam.ShowExponent,
                ?ExponentFormat     : StyleParam.ExponentFormat,
                ?MinExponent        : float,
                ?SeparateThousands  : bool,
                ?TickFormat         : string,       
                ?TickFormatStops    : seq<TickFormatStop>,
                ?HoverFormat        : string,
                ?ShowLine           : bool,         
                ?LineColor          : string,        
                ?LineWidth          : float,        
                ?ShowGrid           : bool,         
                ?GridColor          : string,        
                ?GridWidth          : float,        
                ?ZeroLine           : bool,         
                ?ZeroLineColor      : string,    
                ?ZeroLineWidth      : float,    
                ?ShowDividers       : bool,
                ?DividerColor       : string,
                ?DividerWidth       : int,
                ?Anchor             : StyleParam.LinearAxisId,
                ?Side               : StyleParam.Side,
                ?Overlaying         : StyleParam.LinearAxisId,
                ?Layer              : StyleParam.Layer,
                ?Domain             : StyleParam.Range,
                ?Position           : float,         
                ?CategoryOrder      : StyleParam.CategoryOrder,
                ?CategoryArray      : seq<#IConvertible>,
                ?UIRevision         : #IConvertible,
                ?RangeSlider        : RangeSlider,
                ?RangeSelector      : RangeSelector,
                ?Calendar           : StyleParam.Calendar
            ) =
                (fun (axis:LinearAxis) -> 
                    
                    Visible            |> DynObj.setValueOpt axis   "visible" 
                    Color              |> DynObj.setValueOpt axis   "color" 
                    Title              |> DynObj.setValueOpt axis   "title" 
                    AxisType           |> DynObj.setValueOptBy axis "axistype" StyleParam.AxisType.convert
                    AutoTypeNumbers    |> DynObj.setValueOptBy axis "autotypenumbers" StyleParam.AutoTypeNumbers.convert
                    AutoRange          |> DynObj.setValueOptBy axis "autorange" StyleParam.AutoRange.convert
                    RangeMode          |> DynObj.setValueOptBy axis "rangemode" StyleParam.RangeMode.convert
                    Range              |> DynObj.setValueOptBy axis "range" StyleParam.Range.convert
                    FixedRange         |> DynObj.setValueOpt axis   "fixedrange" 
                    ScaleAnchor        |> DynObj.setValueOptBy axis "scaleanchor" StyleParam.LinearAxisId.convert
                    ScaleRatio         |> DynObj.setValueOpt axis   "scaleratio" 
                    Constrain          |> DynObj.setValueOptBy axis "constrain" StyleParam.AxisConstraint.convert
                    ConstrainToward    |> DynObj.setValueOptBy axis "constraitoward" StyleParam.AxisConstraintDirection.convert
                    Matches            |> DynObj.setValueOptBy axis "matches" StyleParam.LinearAxisId.convert
                    Rangebreaks        |> DynObj.setValueOpt axis   "rangebreaks" 
                    TickMode           |> DynObj.setValueOptBy axis "tickmode" StyleParam.TickMode.convert
                    NTicks             |> DynObj.setValueOpt axis   "nticks" 
                    Tick0              |> DynObj.setValueOpt axis   "tick0" 
                    DTick              |> DynObj.setValueOpt axis   "dtick" 
                    TickVals           |> DynObj.setValueOpt axis   "tickvals" 
                    TickText           |> DynObj.setValueOpt axis   "ticktext" 
                    Ticks              |> DynObj.setValueOptBy axis "ticks" StyleParam.TickOptions.convert
                    TicksOn            |> DynObj.setValueOptBy axis "tickson" StyleParam.CategoryTickAnchor.convert
                    TickLabelMode      |> DynObj.setValueOptBy axis "ticklabelmode" StyleParam.TickLabelMode.convert
                    TickLabelPosition  |> DynObj.setValueOptBy axis "ticklabelposition" StyleParam.TickLabelPosition.convert
                    TickLabelOverflow  |> DynObj.setValueOptBy axis "ticklabeloverflow" StyleParam.TickLabelOverflow.convert
                    Mirror             |> DynObj.setValueOptBy axis "mirror" StyleParam.Mirror.convert
                    TickLen            |> DynObj.setValueOpt axis   "ticklen" 
                    TickWidth          |> DynObj.setValueOpt axis   "tickwidth" 
                    TickColor          |> DynObj.setValueOpt axis   "tickcolor" 
                    ShowTickLabels     |> DynObj.setValueOpt axis   "showticklabels" 
                    AutoMargin         |> DynObj.setValueOpt axis   "automargin" 
                    ShowSpikes         |> DynObj.setValueOpt axis   "showspikes" 
                    SpikeColor         |> DynObj.setValueOpt axis   "spikecolor" 
                    SpikeThickness     |> DynObj.setValueOpt axis   "spikethickness" 
                    SpikeDash          |> DynObj.setValueOptBy axis "spikedash" StyleParam.DrawingStyle.convert
                    SpikeMode          |> DynObj.setValueOptBy axis "spikemode" StyleParam.SpikeMode.convert
                    SpikeSnap          |> DynObj.setValueOptBy axis "spikesnap" StyleParam.SpikeSnap.convert
                    TickFont           |> DynObj.setValueOpt axis   "tickfont" 
                    TickAngle          |> DynObj.setValueOpt axis   "tickangle" 
                    ShowTickPrefix     |> DynObj.setValueOptBy axis "showtickprefix" StyleParam.ShowTickOption.convert
                    TickPrefix         |> DynObj.setValueOpt axis   "tickprefix" 
                    ShowTickSuffix     |> DynObj.setValueOptBy axis "showticksuffix" StyleParam.ShowTickOption.convert
                    TickSuffix         |> DynObj.setValueOpt axis   "ticksuffix" 
                    ShowExponent       |> DynObj.setValueOptBy axis "showexponent" StyleParam.ShowExponent.convert
                    ExponentFormat     |> DynObj.setValueOptBy axis "exponentformat" StyleParam.ExponentFormat.convert
                    MinExponent        |> DynObj.setValueOpt axis   "minexponent" 
                    SeparateThousands  |> DynObj.setValueOpt axis   "separatethousands" 
                    TickFormat         |> DynObj.setValueOpt axis   "tickformat" 
                    TickFormatStops    |> DynObj.setValueOpt axis   "tickformatstops"
                    HoverFormat        |> DynObj.setValueOpt axis   "hoverformat" 
                    ShowLine           |> DynObj.setValueOpt axis   "showline" 
                    LineColor          |> DynObj.setValueOpt axis   "linecolor" 
                    LineWidth          |> DynObj.setValueOpt axis   "linewidth" 
                    ShowGrid           |> DynObj.setValueOpt axis   "showgrid" 
                    GridColor          |> DynObj.setValueOpt axis   "gridcolor" 
                    GridWidth          |> DynObj.setValueOpt axis   "gridwidth" 
                    ZeroLine           |> DynObj.setValueOpt axis   "zeroline" 
                    ZeroLineColor      |> DynObj.setValueOpt axis   "zerolinecolor" 
                    ZeroLineWidth      |> DynObj.setValueOpt axis   "zerolinewidth" 
                    ShowDividers       |> DynObj.setValueOpt axis   "showdividers" 
                    DividerColor       |> DynObj.setValueOpt axis   "dividercolor" 
                    DividerWidth       |> DynObj.setValueOpt axis   "dividerwidth" 
                    Anchor             |> DynObj.setValueOptBy axis "anchor" StyleParam.LinearAxisId.convert
                    Side               |> DynObj.setValueOptBy axis "side" StyleParam.Side.convert
                    Overlaying         |> DynObj.setValueOptBy axis "overlaying" StyleParam.LinearAxisId.convert
                    Layer              |> DynObj.setValueOptBy axis "layer" StyleParam.Layer.convert
                    Domain             |> DynObj.setValueOptBy axis "domain" StyleParam.Range.convert
                    Position           |> DynObj.setValueOpt axis   "position" 
                    CategoryOrder      |> DynObj.setValueOptBy axis "categoryorder" StyleParam.CategoryOrder.convert
                    CategoryArray      |> DynObj.setValueOpt axis   "categoryarray" 
                    UIRevision         |> DynObj.setValueOpt axis   "uirevision" 
                    RangeSlider        |> DynObj.setValueOpt axis   "rangeslider" 
                    RangeSelector      |> DynObj.setValueOpt axis   "rangeselector" 
                    Calendar           |> DynObj.setValueOptBy axis "calendar" StyleParam.Calendar.convert

                    axis
                )

    /// <summary>Radial axes can be used as a scale for the radial coordinates in polar plots.</summary>
    type RadialAxis () =
        inherit DynamicObj ()

        /// <summary>
        /// Initialize an AngularAxis object that can be used as a angular scale for polar coordinates.
        /// </summary>
        /// <param name="Visible">A single toggle to hide the axis while preserving interaction like dragging. Default is true when a cheater plot is present on the axis, otherwise false</param>
        /// <param name="AxisType">Sets the angular axis type. If "linear", set `thetaunit` to determine the unit in which axis value are shown. If "category, use `period` to set the number of integer coordinates around polar axis.</param>
        /// <param name="AutoTypeNumbers">Using "strict" a numeric string in trace data is not converted to a number. Using "convert types" a numeric string in trace data may be treated as a number during automatic axis `type` detection. Defaults to layout.autotypenumbers.</param>
        /// <param name="AutoRange">Determines whether or not the range of this axis is computed in relation to the input data. See `rangemode` for more info. If `range` is provided, then `autorange` is set to "false".</param>
        /// <param name="RangeMode">If "tozero"`, the range extends to 0, regardless of the input data If "nonnegative", the range is non-negative, regardless of the input data. If "normal", the range is computed in relation to the extrema of the input data (same behavior as for cartesian axes).</param>
        /// <param name="Range">Sets the range of this axis. If the axis `type` is "log", then you must take the log of your desired range (e.g. to set the range from 1 to 100, set the range from 0 to 2). If the axis `type` is "date", it should be date strings, like date data, though Date objects and unix milliseconds will be accepted and converted to strings. If the axis `type` is "category", it should be numbers, using the scale where each category is assigned a serial number from zero in the order it appears.</param>
        /// <param name="CategoryOrder">Specifies the ordering logic for the case of categorical variables. By default, plotly uses "trace", which specifies the order that is present in the data supplied. Set `categoryorder` to "category ascending" or "category descending" if order should be determined by the alphanumerical order of the category names. Set `categoryorder` to "array" to derive the ordering from the attribute `categoryarray`. If a category is not found in the `categoryarray` array, the sorting behavior for that attribute will be identical to the "trace" mode. The unspecified categories will follow the categories in `categoryarray`. Set `categoryorder` to "total ascending" or "total descending" if order should be determined by the numerical order of the values. Similarly, the order can be determined by the min, max, sum, mean or median of all the values.</param>
        /// <param name="CategoryArray">Sets the order in which categories on this axis appear. Only has an effect if `categoryorder` is set to "array". Used with `categoryorder`.</param>
        /// <param name="Angle">Sets the angle (in degrees) from which the radial axis is drawn. Note that by default, radial axis line on the theta=0 line corresponds to a line pointing right (like what mathematicians prefer). Defaults to the first `polar.sector` angle.</param>
        /// <param name="Side">Determines on which side of radial axis line the tick and tick labels appear.</param>
        /// <param name="Title">Sets the title of the Radial Axis.</param>
        /// <param name="HoverFormat">Sets the hover text formatting rule using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-3.x-api-reference/blob/master/Formatting.md#d3_format. And for dates see: https://github.com/d3/d3-time-format#locale_format. We add two items to d3's date formatter: "%h" for half of the year as a decimal number as well as "%{n}f" for fractional seconds with n digits. For example, "2016-10-13 09:15:23.456" with TickFormat "%H~%M~%S.%2f" would display "09~15~23.46"</param>
        /// <param name="UIRevision">Controls persistence of user-driven changes in axis `rotation`. Defaults to `polar&lt;N&gt;.uirevision`.</param>
        /// <param name="Color">Sets default for all colors associated with this axis all at once: line, font, tick, and grid colors. Grid color is lightened by blending this with the plot background Individual pieces can override this.</param>
        /// <param name="ShowLine">Determines whether or not a line bounding this axis is drawn.</param>
        /// <param name="LineColor">Sets the axis line color.</param>
        /// <param name="LineWidth">Sets the width (in px) of the axis line.</param>
        /// <param name="ShowGrid">Determines whether or not grid lines are drawn. If "true", the grid lines are drawn at every tick mark.</param>
        /// <param name="GridColor">Sets the color of the grid lines.</param>
        /// <param name="GridWidth">Sets the width (in px) of the grid lines.</param>
        /// <param name="TickMode">Sets the tick mode for this axis. If "auto", the number of ticks is set via `nticks`. If "linear", the placement of the ticks is determined by a starting position `tick0` and a tick step `dtick` ("linear" is the default value if `tick0` and `dtick` are provided). If "array", the placement of the ticks is set via `TickVals` and the tick text is `TickText`. ("array" is the default value if `TickVals` is provided).</param>
        /// <param name="NTicks">Specifies the maximum number of ticks for the particular axis. The actual number of ticks will be chosen automatically to be less than or equal to `nticks`. Has an effect only if `tickmode` is set to "auto".</param>
        /// <param name="Tick0">Sets the placement of the first tick on this axis. Use with `dtick`. If the axis `type` is "log", then you must take the log of your starting tick (e.g. to set the starting tick to 100, set the `tick0` to 2) except when `dtick`="L&lt;f&gt;" (see `dtick` for more info). If the axis `type` is "date", it should be a date string, like date data. If the axis `type` is "category", it should be a number, using the scale where each category is assigned a serial number from zero in the order it appears.</param>
        /// <param name="DTick">Sets the step in-between ticks on this axis. Use with `tick0`. Must be a positive number, or special strings available to "log" and "date" axes. If the axis `type` is "log", then ticks are set every 10^(n"dtick) where n is the tick number. For example, to set a tick mark at 1, 10, 100, 1000, ... set dtick to 1. To set tick marks at 1, 100, 10000, ... set dtick to 2. To set tick marks at 1, 5, 25, 125, 625, 3125, ... set dtick to log_10(5), or 0.69897000433. "log" has several special values; "L&lt;f&gt;", where `f` is a positive number, gives ticks linearly spaced in value (but not position). For example `tick0` = 0.1, `dtick` = "L0.5" will put ticks at 0.1, 0.6, 1.1, 1.6 etc. To show powers of 10 plus small digits between, use "D1" (all digits) or "D2" (only 2 and 5). `tick0` is ignored for "D1" and "D2". If the axis `type` is "date", then you must convert the time to milliseconds. For example, to set the interval between ticks to one day, set `dtick` to 86400000.0. "date" also has special values "M&lt;n&gt;" gives ticks spaced by a number of months. `n` must be a positive integer. To set ticks on the 15th of every third month, set `tick0` to "2000-01-15" and `dtick` to "M3". To set ticks every 4 years, set `dtick` to "M48"</param>
        /// <param name="TickVals">Sets the values at which ticks on this axis appear. Only has an effect if `tickmode` is set to "array". Used with `TickText`.</param>
        /// <param name="TickText">Sets the text displayed at the ticks position via `TickVals`. Only has an effect if `tickmode` is set to "array". Used with `TickVals`.</param>
        /// <param name="Ticks">Determines whether ticks are drawn or not. If "", this axis' ticks are not drawn. If "outside" ("inside"), this axis' are drawn outside (inside) the axis lines.</param>
        /// <param name="TickLen">Sets the tick length (in px).</param>
        /// <param name="TickWidth">Sets the tick width (in px).</param>
        /// <param name="TickColor">Sets the tick color.</param>
        /// <param name="ShowTickLabels">Determines whether or not the tick labels are drawn.</param>
        /// <param name="ShowTickPrefix">If "all", all tick labels are displayed with a prefix. If "first", only the first tick is displayed with a prefix. If "last", only the last tick is displayed with a suffix. If "none", tick prefixes are hidden.</param>
        /// <param name="TickPrefix">Sets a tick label prefix.</param>
        /// <param name="ShowTickSuffix">Same as `showtickprefix` but for tick suffixes.</param>
        /// <param name="TickSuffix">Sets a tick label suffix.</param>
        /// <param name="ShowExponent">If "all", all exponents are shown besides their significands. If "first", only the exponent of the first tick is shown. If "last", only the exponent of the last tick is shown. If "none", no exponents appear.</param>
        /// <param name="ExponentFormat">Determines a formatting rule for the tick exponents. For example, consider the number 1,000,000,000. If "none", it appears as 1,000,000,000. If "e", 1e+9. If "E", 1E+9. If "power", 1x10^9 (with 9 in a super script). If "SI", 1G. If "B", 1B.</param>
        /// <param name="MinExponent">Hide SI prefix for 10^n if |n| is below this number. This only has an effect when `TickFormat` is "SI" or "B".</param>
        /// <param name="SeparateThousands">If "true", even 4-digit integers are separated</param>
        /// <param name="TickFont">Sets the tick font.</param>
        /// <param name="TickAngle">Sets the angle of the tick labels with respect to the horizontal. For example, a `tickangle` of -90 draws the tick labels vertically.</param>
        /// <param name="TickFormat">Sets the tick label formatting rule using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-3.x-api-reference/blob/master/Formatting.md#d3_format. And for dates see: https://github.com/d3/d3-time-format#locale_format. We add two items to d3's date formatter: "%h" for half of the year as a decimal number as well as "%{n}f" for fractional seconds with n digits. For example, "2016-10-13 09:15:23.456" with TickFormat "%H~%M~%S.%2f" would display "09~15~23.46"</param>
        /// <param name="TickFormatStops">Set rules for customizing TickFormat on different zoom levels</param>
        /// <param name="Layer">Sets the layer on which this axis is displayed. If "above traces", this axis is displayed above all the subplot's traces If "below traces", this axis is displayed below all the subplot's traces, but above the grid lines. Useful when used together with scatter-like traces with `cliponaxis` set to "false" to show markers and/or text nodes above this axis.</param>
        /// <param name="Calendar">Sets the calendar system to use for `range` and `tick0` if this is a date axis. This does not set the calendar for interpreting data on this axis, that's specified in the trace or via the global `layout.calendar`</param>
        static member init 
            (
                ?Visible            : bool,
                ?AxisType           : StyleParam.AxisType,
                ?AutoTypeNumbers    : StyleParam.AutoTypeNumbers,
                ?AutoRange          : StyleParam.AutoRange,
                ?RangeMode          : StyleParam.RangeMode,
                ?Range              : StyleParam.Range,
                ?CategoryOrder      : StyleParam.CategoryOrder,
                ?CategoryArray      : seq<#IConvertible>,
                ?Angle              : float,
                ?Side               : StyleParam.Direction,
                ?Title              : Title,
                ?HoverFormat        : string,
                ?UIRevision         : #IConvertible,
                ?Color              : string,
                ?ShowLine           : bool,
                ?LineColor          : string,
                ?LineWidth          : int,
                ?ShowGrid           : bool,
                ?GridColor          : string,
                ?GridWidth          : int,
                ?TickMode           : StyleParam.TickMode,
                ?NTicks             : int,
                ?Tick0              : #IConvertible,
                ?DTick              : #IConvertible,
                ?TickVals           : seq<#IConvertible>,
                ?TickText           : seq<#IConvertible>,
                ?Ticks              : StyleParam.TickOptions,
                ?TickLen            : int,
                ?TickWidth          : int,
                ?TickColor          : string,
                ?ShowTickLabels     : bool,
                ?ShowTickPrefix     : StyleParam.ShowTickOption,
                ?TickPrefix         : string,
                ?ShowTickSuffix     : StyleParam.ShowTickOption,
                ?TickSuffix         : string,
                ?ShowExponent       : StyleParam.ShowExponent,
                ?ExponentFormat     : StyleParam.ExponentFormat,
                ?MinExponent        : float,
                ?SeparateThousands  : bool,
                ?TickFont           : Font,
                ?TickAngle          : int,
                ?TickFormat         : string,
                ?TickFormatStops    : seq<TickFormatStop>,
                ?Layer              : StyleParam.Layer,
                ?Calendar           : StyleParam.Calendar
            ) =
                RadialAxis() 
                |> RadialAxis.style 
                    (
                        ?Visible            = Visible            ,
                        ?AxisType           = AxisType           ,
                        ?AutoTypeNumbers    = AutoTypeNumbers    ,
                        ?AutoRange          = AutoRange          ,
                        ?RangeMode          = RangeMode          ,
                        ?Range              = Range              ,
                        ?CategoryOrder      = CategoryOrder      ,
                        ?CategoryArray      = CategoryArray      ,
                        ?Angle              = Angle              ,
                        ?Side               = Side               ,
                        ?Title              = Title              ,
                        ?HoverFormat        = HoverFormat        ,
                        ?UIRevision         = UIRevision         ,
                        ?Color              = Color              ,
                        ?ShowLine           = ShowLine           ,
                        ?LineColor          = LineColor          ,
                        ?LineWidth          = LineWidth          ,
                        ?ShowGrid           = ShowGrid           ,
                        ?GridColor          = GridColor          ,
                        ?GridWidth          = GridWidth          ,
                        ?TickMode           = TickMode           ,
                        ?NTicks             = NTicks             ,
                        ?Tick0              = Tick0              ,
                        ?DTick              = DTick              ,
                        ?TickVals           = TickVals           ,
                        ?TickText           = TickText           ,
                        ?Ticks              = Ticks              ,
                        ?TickLen            = TickLen            ,
                        ?TickWidth          = TickWidth          ,
                        ?TickColor          = TickColor          ,
                        ?ShowTickLabels     = ShowTickLabels     ,
                        ?ShowTickPrefix     = ShowTickPrefix     ,
                        ?TickPrefix         = TickPrefix         ,
                        ?ShowTickSuffix     = ShowTickSuffix     ,
                        ?TickSuffix         = TickSuffix         ,
                        ?ShowExponent       = ShowExponent       ,
                        ?ExponentFormat     = ExponentFormat     ,
                        ?MinExponent        = MinExponent        ,
                        ?SeparateThousands  = SeparateThousands  ,
                        ?TickFont           = TickFont           ,
                        ?TickAngle          = TickAngle          ,
                        ?TickFormat         = TickFormat         ,
                        ?TickFormatStops    = TickFormatStops    ,
                        ?Layer              = Layer              ,
                        ?Calendar           = Calendar           
                    )

        /// <summary>
        /// Creates a function that applies the given style parameters to a RadialAxis object
        /// </summary>
        /// <param name="Visible">A single toggle to hide the axis while preserving interaction like dragging. Default is true when a cheater plot is present on the axis, otherwise false</param>
        /// <param name="AxisType">Sets the angular axis type. If "linear", set `thetaunit` to determine the unit in which axis value are shown. If "category, use `period` to set the number of integer coordinates around polar axis.</param>
        /// <param name="AutoTypeNumbers">Using "strict" a numeric string in trace data is not converted to a number. Using "convert types" a numeric string in trace data may be treated as a number during automatic axis `type` detection. Defaults to layout.autotypenumbers.</param>
        /// <param name="AutoRange">Determines whether or not the range of this axis is computed in relation to the input data. See `rangemode` for more info. If `range` is provided, then `autorange` is set to "false".</param>
        /// <param name="RangeMode">If "tozero"`, the range extends to 0, regardless of the input data If "nonnegative", the range is non-negative, regardless of the input data. If "normal", the range is computed in relation to the extrema of the input data (same behavior as for cartesian axes).</param>
        /// <param name="Range">Sets the range of this axis. If the axis `type` is "log", then you must take the log of your desired range (e.g. to set the range from 1 to 100, set the range from 0 to 2). If the axis `type` is "date", it should be date strings, like date data, though Date objects and unix milliseconds will be accepted and converted to strings. If the axis `type` is "category", it should be numbers, using the scale where each category is assigned a serial number from zero in the order it appears.</param>
        /// <param name="CategoryOrder">Specifies the ordering logic for the case of categorical variables. By default, plotly uses "trace", which specifies the order that is present in the data supplied. Set `categoryorder` to "category ascending" or "category descending" if order should be determined by the alphanumerical order of the category names. Set `categoryorder` to "array" to derive the ordering from the attribute `categoryarray`. If a category is not found in the `categoryarray` array, the sorting behavior for that attribute will be identical to the "trace" mode. The unspecified categories will follow the categories in `categoryarray`. Set `categoryorder` to "total ascending" or "total descending" if order should be determined by the numerical order of the values. Similarly, the order can be determined by the min, max, sum, mean or median of all the values.</param>
        /// <param name="CategoryArray">Sets the order in which categories on this axis appear. Only has an effect if `categoryorder` is set to "array". Used with `categoryorder`.</param>
        /// <param name="Angle">Sets the angle (in degrees) from which the radial axis is drawn. Note that by default, radial axis line on the theta=0 line corresponds to a line pointing right (like what mathematicians prefer). Defaults to the first `polar.sector` angle.</param>
        /// <param name="Side">Determines on which side of radial axis line the tick and tick labels appear.</param>
        /// <param name="Title">Sets the title of the Radial Axis.</param>
        /// <param name="HoverFormat">Sets the hover text formatting rule using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-3.x-api-reference/blob/master/Formatting.md#d3_format. And for dates see: https://github.com/d3/d3-time-format#locale_format. We add two items to d3's date formatter: "%h" for half of the year as a decimal number as well as "%{n}f" for fractional seconds with n digits. For example, "2016-10-13 09:15:23.456" with TickFormat "%H~%M~%S.%2f" would display "09~15~23.46"</param>
        /// <param name="UIRevision">Controls persistence of user-driven changes in axis `rotation`. Defaults to `polar&lt;N&gt;.uirevision`.</param>
        /// <param name="Color">Sets default for all colors associated with this axis all at once: line, font, tick, and grid colors. Grid color is lightened by blending this with the plot background Individual pieces can override this.</param>
        /// <param name="ShowLine">Determines whether or not a line bounding this axis is drawn.</param>
        /// <param name="LineColor">Sets the axis line color.</param>
        /// <param name="LineWidth">Sets the width (in px) of the axis line.</param>
        /// <param name="ShowGrid">Determines whether or not grid lines are drawn. If "true", the grid lines are drawn at every tick mark.</param>
        /// <param name="GridColor">Sets the color of the grid lines.</param>
        /// <param name="GridWidth">Sets the width (in px) of the grid lines.</param>
        /// <param name="TickMode">Sets the tick mode for this axis. If "auto", the number of ticks is set via `nticks`. If "linear", the placement of the ticks is determined by a starting position `tick0` and a tick step `dtick` ("linear" is the default value if `tick0` and `dtick` are provided). If "array", the placement of the ticks is set via `TickVals` and the tick text is `TickText`. ("array" is the default value if `TickVals` is provided).</param>
        /// <param name="NTicks">Specifies the maximum number of ticks for the particular axis. The actual number of ticks will be chosen automatically to be less than or equal to `nticks`. Has an effect only if `tickmode` is set to "auto".</param>
        /// <param name="Tick0">Sets the placement of the first tick on this axis. Use with `dtick`. If the axis `type` is "log", then you must take the log of your starting tick (e.g. to set the starting tick to 100, set the `tick0` to 2) except when `dtick`="L&lt;f&gt;" (see `dtick` for more info). If the axis `type` is "date", it should be a date string, like date data. If the axis `type` is "category", it should be a number, using the scale where each category is assigned a serial number from zero in the order it appears.</param>
        /// <param name="DTick">Sets the step in-between ticks on this axis. Use with `tick0`. Must be a positive number, or special strings available to "log" and "date" axes. If the axis `type` is "log", then ticks are set every 10^(n"dtick) where n is the tick number. For example, to set a tick mark at 1, 10, 100, 1000, ... set dtick to 1. To set tick marks at 1, 100, 10000, ... set dtick to 2. To set tick marks at 1, 5, 25, 125, 625, 3125, ... set dtick to log_10(5), or 0.69897000433. "log" has several special values; "L&lt;f&gt;", where `f` is a positive number, gives ticks linearly spaced in value (but not position). For example `tick0` = 0.1, `dtick` = "L0.5" will put ticks at 0.1, 0.6, 1.1, 1.6 etc. To show powers of 10 plus small digits between, use "D1" (all digits) or "D2" (only 2 and 5). `tick0` is ignored for "D1" and "D2". If the axis `type` is "date", then you must convert the time to milliseconds. For example, to set the interval between ticks to one day, set `dtick` to 86400000.0. "date" also has special values "M&lt;n&gt;" gives ticks spaced by a number of months. `n` must be a positive integer. To set ticks on the 15th of every third month, set `tick0` to "2000-01-15" and `dtick` to "M3". To set ticks every 4 years, set `dtick` to "M48"</param>
        /// <param name="TickVals">Sets the values at which ticks on this axis appear. Only has an effect if `tickmode` is set to "array". Used with `TickText`.</param>
        /// <param name="TickText">Sets the text displayed at the ticks position via `TickVals`. Only has an effect if `tickmode` is set to "array". Used with `TickVals`.</param>
        /// <param name="Ticks">Determines whether ticks are drawn or not. If "", this axis' ticks are not drawn. If "outside" ("inside"), this axis' are drawn outside (inside) the axis lines.</param>
        /// <param name="TickLen">Sets the tick length (in px).</param>
        /// <param name="TickWidth">Sets the tick width (in px).</param>
        /// <param name="TickColor">Sets the tick color.</param>
        /// <param name="ShowTickLabels">Determines whether or not the tick labels are drawn.</param>
        /// <param name="ShowTickPrefix">If "all", all tick labels are displayed with a prefix. If "first", only the first tick is displayed with a prefix. If "last", only the last tick is displayed with a suffix. If "none", tick prefixes are hidden.</param>
        /// <param name="TickPrefix">Sets a tick label prefix.</param>
        /// <param name="ShowTickSuffix">Same as `showtickprefix` but for tick suffixes.</param>
        /// <param name="TickSuffix">Sets a tick label suffix.</param>
        /// <param name="ShowExponent">If "all", all exponents are shown besides their significands. If "first", only the exponent of the first tick is shown. If "last", only the exponent of the last tick is shown. If "none", no exponents appear.</param>
        /// <param name="ExponentFormat">Determines a formatting rule for the tick exponents. For example, consider the number 1,000,000,000. If "none", it appears as 1,000,000,000. If "e", 1e+9. If "E", 1E+9. If "power", 1x10^9 (with 9 in a super script). If "SI", 1G. If "B", 1B.</param>
        /// <param name="MinExponent">Hide SI prefix for 10^n if |n| is below this number. This only has an effect when `TickFormat` is "SI" or "B".</param>
        /// <param name="SeparateThousands">If "true", even 4-digit integers are separated</param>
        /// <param name="TickFont">Sets the tick font.</param>
        /// <param name="TickAngle">Sets the angle of the tick labels with respect to the horizontal. For example, a `tickangle` of -90 draws the tick labels vertically.</param>
        /// <param name="TickFormat">Sets the tick label formatting rule using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-3.x-api-reference/blob/master/Formatting.md#d3_format. And for dates see: https://github.com/d3/d3-time-format#locale_format. We add two items to d3's date formatter: "%h" for half of the year as a decimal number as well as "%{n}f" for fractional seconds with n digits. For example, "2016-10-13 09:15:23.456" with TickFormat "%H~%M~%S.%2f" would display "09~15~23.46"</param>
        /// <param name="TickFormatStops">Set rules for customizing TickFormat on different zoom levels</param>
        /// <param name="Layer">Sets the layer on which this axis is displayed. If "above traces", this axis is displayed above all the subplot's traces If "below traces", this axis is displayed below all the subplot's traces, but above the grid lines. Useful when used together with scatter-like traces with `cliponaxis` set to "false" to show markers and/or text nodes above this axis.</param>
        /// <param name="Calendar">Sets the calendar system to use for `range` and `tick0` if this is a date axis. This does not set the calendar for interpreting data on this axis, that's specified in the trace or via the global `layout.calendar`</param>
        static member style 
            (
                ?Visible            : bool,
                ?AxisType           : StyleParam.AxisType,
                ?AutoTypeNumbers    : StyleParam.AutoTypeNumbers,
                ?AutoRange          : StyleParam.AutoRange,
                ?RangeMode          : StyleParam.RangeMode,
                ?Range              : StyleParam.Range,
                ?CategoryOrder      : StyleParam.CategoryOrder,
                ?CategoryArray      : seq<#IConvertible>,
                ?Angle              : float,
                ?Side               : StyleParam.Direction,
                ?Title              : Title,
                ?HoverFormat        : string,
                ?UIRevision         : #IConvertible,
                ?Color              : string,
                ?ShowLine           : bool,
                ?LineColor          : string,
                ?LineWidth          : int,
                ?ShowGrid           : bool,
                ?GridColor          : string,
                ?GridWidth          : int,
                ?TickMode           : StyleParam.TickMode,
                ?NTicks             : int,
                ?Tick0              : #IConvertible,
                ?DTick              : #IConvertible,
                ?TickVals           : seq<#IConvertible>,
                ?TickText           : seq<#IConvertible>,
                ?Ticks              : StyleParam.TickOptions,
                ?TickLen            : int,
                ?TickWidth          : int,
                ?TickColor          : string,
                ?ShowTickLabels     : bool,
                ?ShowTickPrefix     : StyleParam.ShowTickOption,
                ?TickPrefix         : string,
                ?ShowTickSuffix     : StyleParam.ShowTickOption,
                ?TickSuffix         : string,
                ?ShowExponent       : StyleParam.ShowExponent,
                ?ExponentFormat     : StyleParam.ExponentFormat,
                ?MinExponent        : float,
                ?SeparateThousands  : bool,
                ?TickFont           : Font,
                ?TickAngle          : int,
                ?TickFormat         : string,
                ?TickFormatStops    : seq<TickFormatStop>,
                ?Layer              : StyleParam.Layer,
                ?Calendar           : StyleParam.Calendar
            ) =
                fun (radialAxis:RadialAxis) ->

                    Visible            |> DynObj.setValueOpt radialAxis "visible"
                    AxisType           |> DynObj.setValueOptBy radialAxis "type" StyleParam.AxisType.convert
                    AutoTypeNumbers    |> DynObj.setValueOptBy radialAxis "autotypenumbers" StyleParam.AutoTypeNumbers.convert
                    AutoRange          |> DynObj.setValueOptBy radialAxis "autorange" StyleParam.AutoRange.convert
                    RangeMode          |> DynObj.setValueOptBy radialAxis "rangemode" StyleParam.RangeMode.convert
                    Range              |> DynObj.setValueOptBy radialAxis "range" StyleParam.Range.convert
                    CategoryOrder      |> DynObj.setValueOptBy radialAxis "categoryorder" StyleParam.CategoryOrder.convert
                    CategoryArray      |> DynObj.setValueOpt radialAxis "categoryarray"
                    Angle              |> DynObj.setValueOpt radialAxis "angle"
                    Side               |> DynObj.setValueOptBy radialAxis "side" StyleParam.Direction.convert
                    Title              |> DynObj.setValueOpt radialAxis "title"
                    HoverFormat        |> DynObj.setValueOpt radialAxis "hoverformat"
                    UIRevision         |> DynObj.setValueOpt radialAxis "uirevision"
                    Color              |> DynObj.setValueOpt radialAxis "color"
                    ShowLine           |> DynObj.setValueOpt radialAxis "showline"
                    LineColor          |> DynObj.setValueOpt radialAxis "linecolor"
                    LineWidth          |> DynObj.setValueOpt radialAxis "linewidth"
                    ShowGrid           |> DynObj.setValueOpt radialAxis "showgrid"
                    GridColor          |> DynObj.setValueOpt radialAxis "gridcolor"
                    GridWidth          |> DynObj.setValueOpt radialAxis "gridwidth"
                    TickMode           |> DynObj.setValueOptBy radialAxis "tickmode" StyleParam.TickMode.convert
                    NTicks             |> DynObj.setValueOpt radialAxis "nticks"
                    Tick0              |> DynObj.setValueOpt radialAxis "tick0"
                    DTick              |> DynObj.setValueOpt radialAxis "dtick"
                    TickVals           |> DynObj.setValueOpt radialAxis "TickVals"
                    TickText           |> DynObj.setValueOpt radialAxis "TickText"
                    Ticks              |> DynObj.setValueOptBy radialAxis "ticks" StyleParam.TickOptions.convert
                    TickLen            |> DynObj.setValueOpt radialAxis "ticklen"
                    TickWidth          |> DynObj.setValueOpt radialAxis "tickwidth"
                    TickColor          |> DynObj.setValueOpt radialAxis "tickcolor"
                    ShowTickLabels     |> DynObj.setValueOpt radialAxis "showticklabels"
                    ShowTickPrefix     |> DynObj.setValueOptBy radialAxis "showtickprefix" StyleParam.ShowTickOption.convert
                    TickPrefix         |> DynObj.setValueOpt radialAxis "tickprefix"
                    ShowTickSuffix     |> DynObj.setValueOptBy radialAxis "showticksuffix" StyleParam.ShowTickOption.convert
                    TickSuffix         |> DynObj.setValueOpt radialAxis "ticksuffix"
                    ShowExponent       |> DynObj.setValueOptBy radialAxis "showexponent" StyleParam.ShowExponent.convert
                    ExponentFormat     |> DynObj.setValueOptBy radialAxis "exponentformat" StyleParam.ExponentFormat.convert
                    MinExponent        |> DynObj.setValueOpt radialAxis "minexponent"
                    SeparateThousands  |> DynObj.setValueOpt radialAxis "separatethousands"
                    TickFont           |> DynObj.setValueOpt radialAxis "tickfont"
                    TickAngle          |> DynObj.setValueOpt radialAxis "tickangle"
                    TickFormat         |> DynObj.setValueOpt radialAxis "TickFormat"
                    TickFormatStops    |> DynObj.setValueOpt radialAxis "tickformatstops"
                    Layer              |> DynObj.setValueOptBy radialAxis "layer" StyleParam.Layer.convert
                    Calendar           |> DynObj.setValueOptBy radialAxis "calendar" StyleParam.Calendar.convert

                    radialAxis

    /// <summary>Angular axes can be used as a scale for the angular coordinates in polar plots.</summary>
    type AngularAxis () =
        inherit DynamicObj ()

        /// <summary>
        /// Initialize an AngularAxis object that can be used as a angular scale for polar coordinates.
        /// </summary>
        /// <param name="Visible">A single toggle to hide the axis while preserving interaction like dragging. Default is true when a cheater plot is present on the axis, otherwise false</param>
        /// <param name="AxisType">Sets the angular axis type. If "linear", set `thetaunit` to determine the unit in which axis value are shown. If "category, use `period` to set the number of integer coordinates around polar axis.</param>
        /// <param name="AutoTypeNumbers">Using "strict" a numeric string in trace data is not converted to a number. Using "convert types" a numeric string in trace data may be treated as a number during automatic axis `type` detection. Defaults to layout.autotypenumbers.</param>
        /// <param name="CategoryOrder">Specifies the ordering logic for the case of categorical variables. By default, plotly uses "trace", which specifies the order that is present in the data supplied. Set `categoryorder` to "category ascending" or "category descending" if order should be determined by the alphanumerical order of the category names. Set `categoryorder` to "array" to derive the ordering from the attribute `categoryarray`. If a category is not found in the `categoryarray` array, the sorting behavior for that attribute will be identical to the "trace" mode. The unspecified categories will follow the categories in `categoryarray`. Set `categoryorder` to "total ascending" or "total descending" if order should be determined by the numerical order of the values. Similarly, the order can be determined by the min, max, sum, mean or median of all the values.</param>
        /// <param name="CategoryArray">Sets the order in which categories on this axis appear. Only has an effect if `categoryorder` is set to "array". Used with `categoryorder`.</param>
        /// <param name="ThetaUnit">Sets the format unit of the formatted "theta" values. Has an effect only when `angularaxis.type` is "linear".</param>
        /// <param name="Period">Set the angular period. Has an effect only when `angularaxis.type` is "category".</param>
        /// <param name="Direction">Sets the direction corresponding to positive angles.</param>
        /// <param name="Rotation">Sets that start position (in degrees) of the angular axis By default, polar subplots with `direction` set to "counterclockwise" get a `rotation` of "0" which corresponds to due East (like what mathematicians prefer). In turn, polar with `direction` set to "clockwise" get a rotation of "90" which corresponds to due North (like on a compass),</param>
        /// <param name="HoverFormat">Sets the hover text formatting rule using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-3.x-api-reference/blob/master/Formatting.md#d3_format. And for dates see: https://github.com/d3/d3-time-format#locale_format. We add two items to d3's date formatter: "%h" for half of the year as a decimal number as well as "%{n}f" for fractional seconds with n digits. For example, "2016-10-13 09:15:23.456" with TickFormat "%H~%M~%S.%2f" would display "09~15~23.46"</param>
        /// <param name="UIRevision">Controls persistence of user-driven changes in axis `rotation`. Defaults to `polar&lt;N&gt;.uirevision`.</param>
        /// <param name="Color">Sets default for all colors associated with this axis all at once: line, font, tick, and grid colors. Grid color is lightened by blending this with the plot background Individual pieces can override this.</param>
        /// <param name="ShowLine">Determines whether or not a line bounding this axis is drawn.</param>
        /// <param name="LineColor">Sets the axis line color.</param>
        /// <param name="LineWidth">Sets the width (in px) of the axis line.</param>
        /// <param name="ShowGrid">Determines whether or not grid lines are drawn. If "true", the grid lines are drawn at every tick mark.</param>
        /// <param name="GridColor">Sets the color of the grid lines.</param>
        /// <param name="GridWidth">Sets the width (in px) of the grid lines.</param>
        /// <param name="TickMode">Sets the tick mode for this axis. If "auto", the number of ticks is set via `nticks`. If "linear", the placement of the ticks is determined by a starting position `tick0` and a tick step `dtick` ("linear" is the default value if `tick0` and `dtick` are provided). If "array", the placement of the ticks is set via `TickVals` and the tick text is `TickText`. ("array" is the default value if `TickVals` is provided).</param>
        /// <param name="NTicks">Specifies the maximum number of ticks for the particular axis. The actual number of ticks will be chosen automatically to be less than or equal to `nticks`. Has an effect only if `tickmode` is set to "auto".</param>
        /// <param name="Tick0">Sets the placement of the first tick on this axis. Use with `dtick`. If the axis `type` is "log", then you must take the log of your starting tick (e.g. to set the starting tick to 100, set the `tick0` to 2) except when `dtick`="L&lt;f&gt;" (see `dtick` for more info). If the axis `type` is "date", it should be a date string, like date data. If the axis `type` is "category", it should be a number, using the scale where each category is assigned a serial number from zero in the order it appears.</param>
        /// <param name="DTick">Sets the step in-between ticks on this axis. Use with `tick0`. Must be a positive number, or special strings available to "log" and "date" axes. If the axis `type` is "log", then ticks are set every 10^(n"dtick) where n is the tick number. For example, to set a tick mark at 1, 10, 100, 1000, ... set dtick to 1. To set tick marks at 1, 100, 10000, ... set dtick to 2. To set tick marks at 1, 5, 25, 125, 625, 3125, ... set dtick to log_10(5), or 0.69897000433. "log" has several special values; "L&lt;f&gt;", where `f` is a positive number, gives ticks linearly spaced in value (but not position). For example `tick0` = 0.1, `dtick` = "L0.5" will put ticks at 0.1, 0.6, 1.1, 1.6 etc. To show powers of 10 plus small digits between, use "D1" (all digits) or "D2" (only 2 and 5). `tick0` is ignored for "D1" and "D2". If the axis `type` is "date", then you must convert the time to milliseconds. For example, to set the interval between ticks to one day, set `dtick` to 86400000.0. "date" also has special values "M&lt;n&gt;" gives ticks spaced by a number of months. `n` must be a positive integer. To set ticks on the 15th of every third month, set `tick0` to "2000-01-15" and `dtick` to "M3". To set ticks every 4 years, set `dtick` to "M48"</param>
        /// <param name="TickVals">Sets the values at which ticks on this axis appear. Only has an effect if `tickmode` is set to "array". Used with `TickText`.</param>
        /// <param name="TickText">Sets the text displayed at the ticks position via `TickVals`. Only has an effect if `tickmode` is set to "array". Used with `TickVals`.</param>
        /// <param name="Ticks">Determines whether ticks are drawn or not. If "", this axis' ticks are not drawn. If "outside" ("inside"), this axis' are drawn outside (inside) the axis lines.</param>
        /// <param name="TickLen">Sets the tick length (in px).</param>
        /// <param name="TickWidth">Sets the tick width (in px).</param>
        /// <param name="TickColor">Sets the tick color.</param>
        /// <param name="ShowTickLabels">Determines whether or not the tick labels are drawn.</param>
        /// <param name="ShowTickPrefix">If "all", all tick labels are displayed with a prefix. If "first", only the first tick is displayed with a prefix. If "last", only the last tick is displayed with a suffix. If "none", tick prefixes are hidden.</param>
        /// <param name="TickPrefix">Sets a tick label prefix.</param>
        /// <param name="ShowTickSuffix">Same as `showtickprefix` but for tick suffixes.</param>
        /// <param name="TickSuffix">Sets a tick label suffix.</param>
        /// <param name="ShowExponent">If "all", all exponents are shown besides their significands. If "first", only the exponent of the first tick is shown. If "last", only the exponent of the last tick is shown. If "none", no exponents appear.</param>
        /// <param name="ExponentFormat">Determines a formatting rule for the tick exponents. For example, consider the number 1,000,000,000. If "none", it appears as 1,000,000,000. If "e", 1e+9. If "E", 1E+9. If "power", 1x10^9 (with 9 in a super script). If "SI", 1G. If "B", 1B.</param>
        /// <param name="MinExponent">Hide SI prefix for 10^n if |n| is below this number. This only has an effect when `TickFormat` is "SI" or "B".</param>
        /// <param name="SeparateThousands">If "true", even 4-digit integers are separated</param>
        /// <param name="TickFont">Sets the tick font.</param>
        /// <param name="TickAngle">Sets the angle of the tick labels with respect to the horizontal. For example, a `tickangle` of -90 draws the tick labels vertically.</param>
        /// <param name="TickFormat">Sets the tick label formatting rule using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-3.x-api-reference/blob/master/Formatting.md#d3_format. And for dates see: https://github.com/d3/d3-time-format#locale_format. We add two items to d3's date formatter: "%h" for half of the year as a decimal number as well as "%{n}f" for fractional seconds with n digits. For example, "2016-10-13 09:15:23.456" with TickFormat "%H~%M~%S.%2f" would display "09~15~23.46"</param>
        /// <param name="TickFormatStops">Set rules for customizing TickFormat on different zoom levels</param>
        /// <param name="Layer">Sets the layer on which this axis is displayed. If "above traces", this axis is displayed above all the subplot's traces If "below traces", this axis is displayed below all the subplot's traces, but above the grid lines. Useful when used together with scatter-like traces with `cliponaxis` set to "false" to show markers and/or text nodes above this axis.</param>
        static member init 
            (
                ?Visible            : bool,
                ?AxisType           : StyleParam.AxisType,
                ?AutoTypeNumbers    : StyleParam.AutoTypeNumbers,
                ?CategoryOrder      : StyleParam.CategoryOrder,
                ?CategoryArray      : seq<#IConvertible>,
                ?ThetaUnit          : StyleParam.AngularUnit,
                ?Period             : float,
                ?Direction          : StyleParam.Direction,
                ?Rotation           : int,
                ?HoverFormat        : string,
                ?UIRevision         : #IConvertible,
                ?Color              : string,
                ?ShowLine           : bool,
                ?LineColor          : string,
                ?LineWidth          : int,
                ?ShowGrid           : bool,
                ?GridColor          : string,
                ?GridWidth          : int,
                ?TickMode           : StyleParam.TickMode,
                ?NTicks             : int,
                ?Tick0              : #IConvertible,
                ?DTick              : #IConvertible,
                ?TickVals           : seq<#IConvertible>,
                ?TickText           : seq<#IConvertible>,
                ?Ticks              : StyleParam.TickOptions,
                ?TickLen            : int,
                ?TickWidth          : int,
                ?TickColor          : string,
                ?ShowTickLabels     : bool,
                ?ShowTickPrefix     : StyleParam.ShowTickOption,
                ?TickPrefix         : string,
                ?ShowTickSuffix     : StyleParam.ShowTickOption,
                ?TickSuffix         : string,
                ?ShowExponent       : StyleParam.ShowExponent,
                ?ExponentFormat     : StyleParam.ExponentFormat,
                ?MinExponent        : float,
                ?SeparateThousands  : bool,
                ?TickFont           : Font,
                ?TickAngle          : int,
                ?TickFormat         : string,
                ?TickFormatStops    : seq<TickFormatStop>,
                ?Layer              : StyleParam.Layer
            ) =
                AngularAxis() 
                |> AngularAxis.style 
                    (
                        ?Visible            = Visible          ,
                        ?AxisType           = AxisType         ,
                        ?AutoTypeNumbers    = AutoTypeNumbers  ,
                        ?CategoryOrder      = CategoryOrder    ,
                        ?CategoryArray      = CategoryArray    ,
                        ?ThetaUnit          = ThetaUnit        ,
                        ?Period             = Period           ,
                        ?Direction          = Direction        ,
                        ?Rotation           = Rotation         ,
                        ?HoverFormat        = HoverFormat      ,
                        ?UIRevision         = UIRevision       ,
                        ?Color              = Color            ,
                        ?ShowLine           = ShowLine         ,
                        ?LineColor          = LineColor        ,
                        ?LineWidth          = LineWidth        ,
                        ?ShowGrid           = ShowGrid         ,
                        ?GridColor          = GridColor        ,
                        ?GridWidth          = GridWidth        ,
                        ?TickMode           = TickMode         ,
                        ?NTicks             = NTicks           ,
                        ?Tick0              = Tick0            ,
                        ?DTick              = DTick            ,
                        ?TickVals           = TickVals         ,
                        ?TickText           = TickText         ,
                        ?Ticks              = Ticks            ,
                        ?TickLen            = TickLen          ,
                        ?TickWidth          = TickWidth        ,
                        ?TickColor          = TickColor        ,
                        ?ShowTickLabels     = ShowTickLabels   ,
                        ?ShowTickPrefix     = ShowTickPrefix   ,
                        ?TickPrefix         = TickPrefix       ,
                        ?ShowTickSuffix     = ShowTickSuffix   ,
                        ?TickSuffix         = TickSuffix       ,
                        ?ShowExponent       = ShowExponent     ,
                        ?ExponentFormat     = ExponentFormat   ,
                        ?MinExponent        = MinExponent      ,
                        ?SeparateThousands  = SeparateThousands,
                        ?TickFont           = TickFont         ,
                        ?TickAngle          = TickAngle        ,
                        ?TickFormat         = TickFormat       ,
                        ?TickFormatStops    = TickFormatStops  ,
                        ?Layer              = Layer            
                    )
        
        /// <summary>
        /// Creates a function that applies the given style parameters to a AngularAxis object
        /// </summary>
        /// <param name="Visible">A single toggle to hide the axis while preserving interaction like dragging. Default is true when a cheater plot is present on the axis, otherwise false</param>
        /// <param name="AxisType">Sets the angular axis type. If "linear", set `thetaunit` to determine the unit in which axis value are shown. If "category, use `period` to set the number of integer coordinates around polar axis.</param>
        /// <param name="AutoTypeNumbers">Using "strict" a numeric string in trace data is not converted to a number. Using "convert types" a numeric string in trace data may be treated as a number during automatic axis `type` detection. Defaults to layout.autotypenumbers.</param>
        /// <param name="CategoryOrder">Specifies the ordering logic for the case of categorical variables. By default, plotly uses "trace", which specifies the order that is present in the data supplied. Set `categoryorder` to "category ascending" or "category descending" if order should be determined by the alphanumerical order of the category names. Set `categoryorder` to "array" to derive the ordering from the attribute `categoryarray`. If a category is not found in the `categoryarray` array, the sorting behavior for that attribute will be identical to the "trace" mode. The unspecified categories will follow the categories in `categoryarray`. Set `categoryorder` to "total ascending" or "total descending" if order should be determined by the numerical order of the values. Similarly, the order can be determined by the min, max, sum, mean or median of all the values.</param>
        /// <param name="CategoryArray">Sets the order in which categories on this axis appear. Only has an effect if `categoryorder` is set to "array". Used with `categoryorder`.</param>
        /// <param name="ThetaUnit">Sets the format unit of the formatted "theta" values. Has an effect only when `angularaxis.type` is "linear".</param>
        /// <param name="Period">Set the angular period. Has an effect only when `angularaxis.type` is "category".</param>
        /// <param name="Direction">Sets the direction corresponding to positive angles.</param>
        /// <param name="Rotation">Sets that start position (in degrees) of the angular axis By default, polar subplots with `direction` set to "counterclockwise" get a `rotation` of "0" which corresponds to due East (like what mathematicians prefer). In turn, polar with `direction` set to "clockwise" get a rotation of "90" which corresponds to due North (like on a compass),</param>
        /// <param name="HoverFormat">Sets the hover text formatting rule using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-3.x-api-reference/blob/master/Formatting.md#d3_format. And for dates see: https://github.com/d3/d3-time-format#locale_format. We add two items to d3's date formatter: "%h" for half of the year as a decimal number as well as "%{n}f" for fractional seconds with n digits. For example, "2016-10-13 09:15:23.456" with TickFormat "%H~%M~%S.%2f" would display "09~15~23.46"</param>
        /// <param name="UIRevision">Controls persistence of user-driven changes in axis `rotation`. Defaults to `polar&lt;N&gt;.uirevision`.</param>
        /// <param name="Color">Sets default for all colors associated with this axis all at once: line, font, tick, and grid colors. Grid color is lightened by blending this with the plot background Individual pieces can override this.</param>
        /// <param name="ShowLine">Determines whether or not a line bounding this axis is drawn.</param>
        /// <param name="LineColor">Sets the axis line color.</param>
        /// <param name="LineWidth">Sets the width (in px) of the axis line.</param>
        /// <param name="ShowGrid">Determines whether or not grid lines are drawn. If "true", the grid lines are drawn at every tick mark.</param>
        /// <param name="GridColor">Sets the color of the grid lines.</param>
        /// <param name="GridWidth">Sets the width (in px) of the grid lines.</param>
        /// <param name="TickMode">Sets the tick mode for this axis. If "auto", the number of ticks is set via `nticks`. If "linear", the placement of the ticks is determined by a starting position `tick0` and a tick step `dtick` ("linear" is the default value if `tick0` and `dtick` are provided). If "array", the placement of the ticks is set via `TickVals` and the tick text is `TickText`. ("array" is the default value if `TickVals` is provided).</param>
        /// <param name="NTicks">Specifies the maximum number of ticks for the particular axis. The actual number of ticks will be chosen automatically to be less than or equal to `nticks`. Has an effect only if `tickmode` is set to "auto".</param>
        /// <param name="Tick0">Sets the placement of the first tick on this axis. Use with `dtick`. If the axis `type` is "log", then you must take the log of your starting tick (e.g. to set the starting tick to 100, set the `tick0` to 2) except when `dtick`="L&lt;f&gt;" (see `dtick` for more info). If the axis `type` is "date", it should be a date string, like date data. If the axis `type` is "category", it should be a number, using the scale where each category is assigned a serial number from zero in the order it appears.</param>
        /// <param name="DTick">Sets the step in-between ticks on this axis. Use with `tick0`. Must be a positive number, or special strings available to "log" and "date" axes. If the axis `type` is "log", then ticks are set every 10^(n"dtick) where n is the tick number. For example, to set a tick mark at 1, 10, 100, 1000, ... set dtick to 1. To set tick marks at 1, 100, 10000, ... set dtick to 2. To set tick marks at 1, 5, 25, 125, 625, 3125, ... set dtick to log_10(5), or 0.69897000433. "log" has several special values; "L&lt;f&gt;", where `f` is a positive number, gives ticks linearly spaced in value (but not position). For example `tick0` = 0.1, `dtick` = "L0.5" will put ticks at 0.1, 0.6, 1.1, 1.6 etc. To show powers of 10 plus small digits between, use "D1" (all digits) or "D2" (only 2 and 5). `tick0` is ignored for "D1" and "D2". If the axis `type` is "date", then you must convert the time to milliseconds. For example, to set the interval between ticks to one day, set `dtick` to 86400000.0. "date" also has special values "M&lt;n&gt;" gives ticks spaced by a number of months. `n` must be a positive integer. To set ticks on the 15th of every third month, set `tick0` to "2000-01-15" and `dtick` to "M3". To set ticks every 4 years, set `dtick` to "M48"</param>
        /// <param name="TickVals">Sets the values at which ticks on this axis appear. Only has an effect if `tickmode` is set to "array". Used with `TickText`.</param>
        /// <param name="TickText">Sets the text displayed at the ticks position via `TickVals`. Only has an effect if `tickmode` is set to "array". Used with `TickVals`.</param>
        /// <param name="Ticks">Determines whether ticks are drawn or not. If "", this axis' ticks are not drawn. If "outside" ("inside"), this axis' are drawn outside (inside) the axis lines.</param>
        /// <param name="TickLen">Sets the tick length (in px).</param>
        /// <param name="TickWidth">Sets the tick width (in px).</param>
        /// <param name="TickColor">Sets the tick color.</param>
        /// <param name="ShowTickLabels">Determines whether or not the tick labels are drawn.</param>
        /// <param name="ShowTickPrefix">If "all", all tick labels are displayed with a prefix. If "first", only the first tick is displayed with a prefix. If "last", only the last tick is displayed with a suffix. If "none", tick prefixes are hidden.</param>
        /// <param name="TickPrefix">Sets a tick label prefix.</param>
        /// <param name="ShowTickSuffix">Same as `showtickprefix` but for tick suffixes.</param>
        /// <param name="TickSuffix">Sets a tick label suffix.</param>
        /// <param name="ShowExponent">If "all", all exponents are shown besides their significands. If "first", only the exponent of the first tick is shown. If "last", only the exponent of the last tick is shown. If "none", no exponents appear.</param>
        /// <param name="ExponentFormat">Determines a formatting rule for the tick exponents. For example, consider the number 1,000,000,000. If "none", it appears as 1,000,000,000. If "e", 1e+9. If "E", 1E+9. If "power", 1x10^9 (with 9 in a super script). If "SI", 1G. If "B", 1B.</param>
        /// <param name="MinExponent">Hide SI prefix for 10^n if |n| is below this number. This only has an effect when `TickFormat` is "SI" or "B".</param>
        /// <param name="SeparateThousands">If "true", even 4-digit integers are separated</param>
        /// <param name="TickFont">Sets the tick font.</param>
        /// <param name="TickAngle">Sets the angle of the tick labels with respect to the horizontal. For example, a `tickangle` of -90 draws the tick labels vertically.</param>
        /// <param name="TickFormat">Sets the tick label formatting rule using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-3.x-api-reference/blob/master/Formatting.md#d3_format. And for dates see: https://github.com/d3/d3-time-format#locale_format. We add two items to d3's date formatter: "%h" for half of the year as a decimal number as well as "%{n}f" for fractional seconds with n digits. For example, "2016-10-13 09:15:23.456" with TickFormat "%H~%M~%S.%2f" would display "09~15~23.46"</param>
        /// <param name="TickFormatStops">Set rules for customizing TickFormat on different zoom levels</param>
        /// <param name="Layer">Sets the layer on which this axis is displayed. If "above traces", this axis is displayed above all the subplot's traces If "below traces", this axis is displayed below all the subplot's traces, but above the grid lines. Useful when used together with scatter-like traces with `cliponaxis` set to "false" to show markers and/or text nodes above this axis.</param>
        static member style 
            (
                ?Visible            : bool,
                ?AxisType           : StyleParam.AxisType,
                ?AutoTypeNumbers    : StyleParam.AutoTypeNumbers,
                ?CategoryOrder      : StyleParam.CategoryOrder,
                ?CategoryArray      : seq<#IConvertible>,
                ?ThetaUnit          : StyleParam.AngularUnit,
                ?Period             : float,
                ?Direction          : StyleParam.Direction,
                ?Rotation           : int,
                ?HoverFormat        : string,
                ?UIRevision         : #IConvertible,
                ?Color              : string,
                ?ShowLine           : bool,
                ?LineColor          : string,
                ?LineWidth          : int,
                ?ShowGrid           : bool,
                ?GridColor          : string,
                ?GridWidth          : int,
                ?TickMode           : StyleParam.TickMode,
                ?NTicks             : int,
                ?Tick0              : #IConvertible,
                ?DTick              : #IConvertible,
                ?TickVals           : seq<#IConvertible>,
                ?TickText           : seq<#IConvertible>,
                ?Ticks              : StyleParam.TickOptions,
                ?TickLen            : int,
                ?TickWidth          : int,
                ?TickColor          : string,
                ?ShowTickLabels     : bool,
                ?ShowTickPrefix     : StyleParam.ShowTickOption,
                ?TickPrefix         : string,
                ?ShowTickSuffix     : StyleParam.ShowTickOption,
                ?TickSuffix         : string,
                ?ShowExponent       : StyleParam.ShowExponent,
                ?ExponentFormat     : StyleParam.ExponentFormat,
                ?MinExponent        : float,
                ?SeparateThousands  : bool,
                ?TickFont           : Font,
                ?TickAngle          : int,
                ?TickFormat         : string,
                ?TickFormatStops    : seq<TickFormatStop>,
                ?Layer              : StyleParam.Layer
            ) =
                fun (angularAxis: AngularAxis) ->
                    
                    Visible             |> DynObj.setValueOpt angularAxis "visible"
                    AxisType            |> DynObj.setValueOptBy angularAxis "type" StyleParam.AxisType.convert
                    AutoTypeNumbers     |> DynObj.setValueOptBy angularAxis "autotypenumbers" StyleParam.AutoTypeNumbers.convert
                    CategoryOrder       |> DynObj.setValueOptBy angularAxis "categoryorder" StyleParam.CategoryOrder.convert
                    CategoryArray       |> DynObj.setValueOpt angularAxis "categoryarray"
                    ThetaUnit           |> DynObj.setValueOpt angularAxis "thetaunit"
                    Period              |> DynObj.setValueOpt angularAxis "Period"
                    Direction           |> DynObj.setValueOpt angularAxis "Direction"
                    Rotation            |> DynObj.setValueOpt angularAxis "Rotation"
                    HoverFormat         |> DynObj.setValueOpt angularAxis "hoverformat"
                    UIRevision          |> DynObj.setValueOpt angularAxis "uirevision"
                    Color               |> DynObj.setValueOpt angularAxis "color"
                    ShowLine            |> DynObj.setValueOpt angularAxis "showline"
                    LineColor           |> DynObj.setValueOpt angularAxis "linecolor"
                    LineWidth           |> DynObj.setValueOpt angularAxis "linewidth"
                    ShowGrid            |> DynObj.setValueOpt angularAxis "showgrid"
                    GridColor           |> DynObj.setValueOpt angularAxis "gridcolor"
                    GridWidth           |> DynObj.setValueOpt angularAxis "gridwidth"
                    TickMode            |> DynObj.setValueOptBy angularAxis "tickmode" StyleParam.TickMode.convert
                    NTicks              |> DynObj.setValueOpt angularAxis "nticks"
                    Tick0               |> DynObj.setValueOpt angularAxis "tick0"
                    DTick               |> DynObj.setValueOpt angularAxis "dtick"
                    TickVals            |> DynObj.setValueOpt angularAxis "TickVals"
                    TickText            |> DynObj.setValueOpt angularAxis "TickText"
                    Ticks               |> DynObj.setValueOptBy angularAxis "ticks" StyleParam.TickOptions.convert
                    TickLen             |> DynObj.setValueOpt angularAxis "ticklen"
                    TickWidth           |> DynObj.setValueOpt angularAxis "tickwidth"
                    TickColor           |> DynObj.setValueOpt angularAxis "tickcolor"
                    ShowTickLabels      |> DynObj.setValueOpt angularAxis "showticklabels"
                    ShowTickPrefix      |> DynObj.setValueOptBy angularAxis "showtickprefix" StyleParam.ShowTickOption.convert
                    TickPrefix          |> DynObj.setValueOpt angularAxis "tickprefix"
                    ShowTickSuffix      |> DynObj.setValueOptBy angularAxis "showticksuffix" StyleParam.ShowTickOption.convert
                    TickSuffix          |> DynObj.setValueOpt angularAxis "ticksuffix"
                    ShowExponent        |> DynObj.setValueOptBy angularAxis "showexponent" StyleParam.ShowExponent.convert
                    ExponentFormat      |> DynObj.setValueOptBy angularAxis "exponentformat" StyleParam.ExponentFormat.convert
                    MinExponent         |> DynObj.setValueOpt angularAxis "minexponent"
                    SeparateThousands   |> DynObj.setValueOpt angularAxis "separatethousands"
                    TickFont            |> DynObj.setValueOpt angularAxis "tickfont"
                    TickAngle           |> DynObj.setValueOpt angularAxis "tickangle"
                    TickFormat          |> DynObj.setValueOpt angularAxis "TickFormat"
                    TickFormatStops     |> DynObj.setValueOpt angularAxis "tickformatstops"
                    Layer               |> DynObj.setValueOptBy angularAxis "layer" StyleParam.Layer.convert

                    angularAxis

    type ColorAxis() =
        inherit DynamicObj()

        /// <summary>
        /// Initializes a ColorAxis object
        /// </summary>
        /// <param name="AutoColorScale">Determines whether the colorscale is a default palette (`autocolorscale: true`) or the palette determined by `colorscale`. In case `colorscale` is unspecified or `autocolorscale` is true, the default palette will be chosen according to whether numbers in the `color` array are all positive, all negative or mixed.</param>
        /// <param name="CAuto">Determines whether or not the color domain is computed with respect to the input data (here corresponding trace color array(s)) or the bounds set in `cmin` and `cmax` Defaults to `false` when `cmin` and `cmax` are set by the user.</param>
        /// <param name="CMin">Sets the lower bound of the color domain. Value should have the same units as corresponding trace color array(s) and if set, `cmax` must be set as well.</param>
        /// <param name="CMid">Sets the mid-point of the color domain by scaling `cmin` and/or `cmax` to be equidistant to this point. Value should have the same units as corresponding trace color array(s). Has no effect when `cauto` is `false`.</param>
        /// <param name="CMax">Sets the upper bound of the color domain. Value should have the same units as corresponding trace color array(s) and if set, `cmin` must be set as well.</param>
        /// <param name="ColorBar">Sets the colorbar associated with this color axis.</param>
        /// <param name="ColorScale">Sets the colorscale. The colorscale must be an array containing arrays mapping a normalized value to an rgb, rgba, hex, hsl, hsv, or named color string. At minimum, a mapping for the lowest (0) and highest (1) values are required. For example, `[[0, 'rgb(0,0,255)'], [1, 'rgb(255,0,0)']]`. To control the bounds of the colorscale in color space, use`cmin` and `cmax`. Alternatively, `colorscale` may be a palette name string of the following list: Blackbody,Bluered,Blues,Cividis,Earth,Electric,Greens,Greys,Hot,Jet,Picnic,Portland,Rainbow,RdBu,Reds,Viridis,YlGnBu,YlOrRd.</param>
        /// <param name="ShowScale">Reverses the color mapping if true. If true, `cmin` will correspond to the last color in the array and `cmax` will correspond to the first color.</param>
        /// <param name="ReverseScale">Determines whether or not a colorbar is displayed for this trace.</param>
        static member init
            (
                ?AutoColorScale     : bool,
                ?CAuto              : float,
                ?CMin               : float,
                ?CMid               : float,
                ?CMax               : float,
                ?ColorBar           : ColorBar,
                ?ColorScale         : StyleParam.Colorscale,
                ?ShowScale          : bool,
                ?ReverseScale       : bool
            ) =
                
                ColorAxis()
                |> ColorAxis.style
                    (
                        ?AutoColorScale = AutoColorScale,
                        ?CAuto          = CAuto         ,
                        ?CMin           = CMin          ,
                        ?CMid           = CMid          ,
                        ?CMax           = CMax          ,
                        ?ColorBar       = ColorBar      ,
                        ?ColorScale     = ColorScale    ,
                        ?ShowScale      = ShowScale     ,
                        ?ReverseScale   = ReverseScale  
                    )
        /// <summary>
        /// Creates a function that applies the given style parameters to a ColorAxis object
        /// </summary>
        /// <param name="AutoColorScale">Determines whether the colorscale is a default palette (`autocolorscale: true`) or the palette determined by `colorscale`. In case `colorscale` is unspecified or `autocolorscale` is true, the default palette will be chosen according to whether numbers in the `color` array are all positive, all negative or mixed.</param>
        /// <param name="CAuto">Determines whether or not the color domain is computed with respect to the input data (here corresponding trace color array(s)) or the bounds set in `cmin` and `cmax` Defaults to `false` when `cmin` and `cmax` are set by the user.</param>
        /// <param name="CMin">Sets the lower bound of the color domain. Value should have the same units as corresponding trace color array(s) and if set, `cmax` must be set as well.</param>
        /// <param name="CMid">Sets the mid-point of the color domain by scaling `cmin` and/or `cmax` to be equidistant to this point. Value should have the same units as corresponding trace color array(s). Has no effect when `cauto` is `false`.</param>
        /// <param name="CMax">Sets the upper bound of the color domain. Value should have the same units as corresponding trace color array(s) and if set, `cmin` must be set as well.</param>
        /// <param name="ColorBar">Sets the colorbar associated with this color axis.</param>
        /// <param name="ColorScale">Sets the colorscale. The colorscale must be an array containing arrays mapping a normalized value to an rgb, rgba, hex, hsl, hsv, or named color string. At minimum, a mapping for the lowest (0) and highest (1) values are required. For example, `[[0, 'rgb(0,0,255)'], [1, 'rgb(255,0,0)']]`. To control the bounds of the colorscale in color space, use`cmin` and `cmax`. Alternatively, `colorscale` may be a palette name string of the following list: Blackbody,Bluered,Blues,Cividis,Earth,Electric,Greens,Greys,Hot,Jet,Picnic,Portland,Rainbow,RdBu,Reds,Viridis,YlGnBu,YlOrRd.</param>
        /// <param name="ShowScale">Reverses the color mapping if true. If true, `cmin` will correspond to the last color in the array and `cmax` will correspond to the first color.</param>
        /// <param name="ReverseScale">Determines whether or not a colorbar is displayed for this trace.</param>
        static member style
            (
                ?AutoColorScale     : bool,
                ?CAuto              : float,
                ?CMin               : float,
                ?CMid               : float,
                ?CMax               : float,
                ?ColorBar           : ColorBar,
                ?ColorScale         : StyleParam.Colorscale,
                ?ShowScale          : bool,
                ?ReverseScale       : bool
            ) =
                fun (ca:ColorAxis) ->

                    AutoColorScale  |> DynObj.setValueOpt ca "autocolorscale"
                    CAuto           |> DynObj.setValueOpt ca "cauto"
                    CMin            |> DynObj.setValueOpt ca "cmin"
                    CMid            |> DynObj.setValueOpt ca "cmid"
                    CMax            |> DynObj.setValueOpt ca "cmax"
                    ColorBar        |> DynObj.setValueOpt ca "colorbar"
                    ColorScale      |> DynObj.setValueOpt ca "colorscale"
                    ShowScale       |> DynObj.setValueOpt ca "showscale"
                    ReverseScale    |> DynObj.setValueOpt ca "reversescale"

                    ca