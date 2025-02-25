﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GrblExpress.Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("GrblExpress.Resources.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to A Axis.
        /// </summary>
        public static string AAxisLabel {
            get {
                return ResourceManager.GetString("AAxisLabel", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to B Axis.
        /// </summary>
        public static string BAxisLabel {
            get {
                return ResourceManager.GetString("BAxisLabel", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to C Axis.
        /// </summary>
        public static string CAxisLabel {
            get {
                return ResourceManager.GetString("CAxisLabel", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to DRO.
        /// </summary>
        public static string DRO {
            get {
                return ResourceManager.GetString("DRO", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Second dual axis limit switch failed to trigger within configured search distance after first. This can only occur on a Shapeoko 5 Pro in a few circumstances:
        ///
        ///The machine is way out of square the first time homing is attempted. If this is the case, run the initialization routine again to see if the problem goes away. If it does, the machine should now be within tolerance to home successfully in the future.
        ///The Y2 limit switch is not connected or malfunctioning..
        /// </summary>
        public static string GrblAlarmCode10Msg {
            get {
                return ResourceManager.GetString("GrblAlarmCode10Msg", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Homing fail.
        /// </summary>
        public static string GrblAlarmCode10Title {
            get {
                return ResourceManager.GetString("GrblAlarmCode10Title", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Hard limit has been triggered. Machine position is likely lost due to sudden halt. Re-homing is highly recommended..
        /// </summary>
        public static string GrblAlarmCode1Msg {
            get {
                return ResourceManager.GetString("GrblAlarmCode1Msg", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Hard Limit.
        /// </summary>
        public static string GrblAlarmCode1Title {
            get {
                return ResourceManager.GetString("GrblAlarmCode1Title", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Soft limit alarm. G-code motion target exceeds machine travel. Machine position retained. Alarm may be safely unlocked..
        /// </summary>
        public static string GrblAlarmCode2Msg {
            get {
                return ResourceManager.GetString("GrblAlarmCode2Msg", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Soft Limit.
        /// </summary>
        public static string GrblAlarmCode2Title {
            get {
                return ResourceManager.GetString("GrblAlarmCode2Title", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This error indicates that the machine controller was reset while in motion. Machine position was likely lost due to sudden halt so you will need to reinitialize the machine to continue working..
        /// </summary>
        public static string GrblAlarmCode3Msg {
            get {
                return ResourceManager.GetString("GrblAlarmCode3Msg", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Abort during cycle.
        /// </summary>
        public static string GrblAlarmCode3Title {
            get {
                return ResourceManager.GetString("GrblAlarmCode3Title", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The probe is not in the expected initial state before starting a probing cycle. This can occur in the following cases:
        ///
        ///If the bit is touching the BitSetter before beginning a tool measurement.
        ///If the tool is touching the BitZero when beginning a probe cycle..
        /// </summary>
        public static string GrblAlarmCode4Msg {
            get {
                return ResourceManager.GetString("GrblAlarmCode4Msg", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Probe fail.
        /// </summary>
        public static string GrblAlarmCode4Title {
            get {
                return ResourceManager.GetString("GrblAlarmCode4Title", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The probe did not contact the workpiece within the programmed travel. This can happen in a few cases:
        ///
        ///During a tool measurement with BitSetter, the tool is too short to reach the BitSetter.
        ///The BitSetter is faulty or not connected during a tool measurement.
        ///During a probing cycle with the BitZero, the tool begins too far away from the BitZero, and it is unable to touch it within the preprogrammed travel distance.
        ///During a probing cycle, the BitZero is faulty, or not plugged in, so the machine never de [rest of string was truncated]&quot;;.
        /// </summary>
        public static string GrblAlarmCode5Msg {
            get {
                return ResourceManager.GetString("GrblAlarmCode5Msg", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Probe fail.
        /// </summary>
        public static string GrblAlarmCode5Title {
            get {
                return ResourceManager.GetString("GrblAlarmCode5Title", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This indicates that the machine was reset while a homing cycle was running. The machine position will be lost, but you can re-initialize the machine to clear this error..
        /// </summary>
        public static string GrblAlarmCode6Msg {
            get {
                return ResourceManager.GetString("GrblAlarmCode6Msg", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Homing fail.
        /// </summary>
        public static string GrblAlarmCode6Title {
            get {
                return ResourceManager.GetString("GrblAlarmCode6Title", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Safety door was opened during homing cycle..
        /// </summary>
        public static string GrblAlarmCode7Msg {
            get {
                return ResourceManager.GetString("GrblAlarmCode7Msg", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Homing fail.
        /// </summary>
        public static string GrblAlarmCode7Title {
            get {
                return ResourceManager.GetString("GrblAlarmCode7Title", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Pull off travel failed to clear limit switch..
        /// </summary>
        public static string GrblAlarmCode8Msg {
            get {
                return ResourceManager.GetString("GrblAlarmCode8Msg", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Homing fail.
        /// </summary>
        public static string GrblAlarmCode8Title {
            get {
                return ResourceManager.GetString("GrblAlarmCode8Title", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Could not find limit switch within search distances. This indicates that one or more of the limit switches may be disconnected or malfunctioning..
        /// </summary>
        public static string GrblAlarmCode9Msg {
            get {
                return ResourceManager.GetString("GrblAlarmCode9Msg", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Homing fail.
        /// </summary>
        public static string GrblAlarmCode9Title {
            get {
                return ResourceManager.GetString("GrblAlarmCode9Title", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Limits.
        /// </summary>
        public static string Limits {
            get {
                return ResourceManager.GetString("Limits", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Machine Limits.
        /// </summary>
        public static string MachineLimits {
            get {
                return ResourceManager.GetString("MachineLimits", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Max.
        /// </summary>
        public static string MaximumShort {
            get {
                return ResourceManager.GetString("MaximumShort", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Min.
        /// </summary>
        public static string MinimunShort {
            get {
                return ResourceManager.GetString("MinimunShort", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Program Limits.
        /// </summary>
        public static string ProgramLimits {
            get {
                return ResourceManager.GetString("ProgramLimits", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This is the most common connection method, utilizing a physical USB cable to directly link your computer to the GRBL controller. This provides a stable and reliable connection for most users..
        /// </summary>
        public static string SerialConnectionDescription {
            get {
                return ResourceManager.GetString("SerialConnectionDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Telnet is an outdated protocol that uses a network connection. This allows you to control your CNC machine over a network (e.g., Ethernet or Wi-Fi), enabling remote operation or convenient access from different devices on the same network. It is generally slow and not commonly used..
        /// </summary>
        public static string TelnetConnectionDescription {
            get {
                return ResourceManager.GetString("TelnetConnectionDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to U Axis.
        /// </summary>
        public static string UAxisLabel {
            get {
                return ResourceManager.GetString("UAxisLabel", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to V Axis.
        /// </summary>
        public static string VAxisLabel {
            get {
                return ResourceManager.GetString("VAxisLabel", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to W Axis.
        /// </summary>
        public static string WAxisLabel {
            get {
                return ResourceManager.GetString("WAxisLabel", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Websocket provides a modern, efficient, and bi-directional communication channel over a network. It offers faster data transfer and real-time updates. This is a suitable choice if your GRBL controller supports Websocket communication and you prioritize performance and responsiveness..
        /// </summary>
        public static string WebsocketConnectionDescription {
            get {
                return ResourceManager.GetString("WebsocketConnectionDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to X Axis.
        /// </summary>
        public static string XAxisLabel {
            get {
                return ResourceManager.GetString("XAxisLabel", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Y Axis.
        /// </summary>
        public static string YAxisLabel {
            get {
                return ResourceManager.GetString("YAxisLabel", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Z Axis.
        /// </summary>
        public static string ZAxisLabel {
            get {
                return ResourceManager.GetString("ZAxisLabel", resourceCulture);
            }
        }
    }
}
