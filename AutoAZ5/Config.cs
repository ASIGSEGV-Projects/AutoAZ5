using System.ComponentModel;
using Exiled.API.Interfaces;

namespace AutoAZ5
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        
        [Description("In this case, debug will do next to nothing.")]
        public bool Debug { get; set; } = false;

        [Description("How long before the alpha-warhead detonates in seconds.")]
        public float AutoWarheadDelay { get; set; } = 1200; // 20 minutes default

        [Description("[SET TO '' TO DISABLE] The CASSIE announcement right before the auto warhead is started (it delays the warhead engagement by how long the announcement is + [CassieWarningDelay]).")]
        public string AutoWarheadWarningCassie { get; set; } = "PROTOCOL NATO_A NATO_Z 5 ACTIVATING . EVACUATE IMMEDIATELY"; 
        
        [Description("[SET TO '' TO DISABLE] The CASSIE subtitles (translation, if you will).")] 
        public string AutoWarheadWarningCassieSubtitles { get; set; } = "PROTOCOL AZ-5 ACTIVATING... EVACUATE IMMEDIATELY.";

        [Description("If the CASSIE announcement before engagement should override a current announcement")]
        public bool AutoWarheadWarningCassieOverrides { get; set; } = true;
        
        [Description("The time difference between the CASSIE warning and the auto-warhead engaging")]
        public float CassieWarningDelay { get; set; } = 10;

        [Description("[SET TO '' TO DISABLE] The Broadcast displayed after warhead engagement")]
        public string WarningText { get; set; } =
            "<br><color=red><size=40><b>[ Alpha Warhead ]</b></size></color><br><size=25>The Automatic Alpha Warhead has been engaged.<br>This is inevitable and can <b><color=#f54266>NOT</color></b> be stopped.</size>";

        [Description("How long the warning above should stay on their screens")]
        public float WarningDuration { get; set; } = 6.5f;
        
        [Description("[SET TO '' TO DISABLE] The CASSIE announcement right AFTER the auto warhead is detonated by AZ-5.")]
        public string SuccessfulDetonationAnnouncement { get; set; } = "PROTOCOL NATO_A NATO_Z 5 SUCCESSFULLY EXECUTED"; 
        
        [Description("[SET TO '' TO DISABLE] Subtitles for above.")] 
        public string SuccessfulDetonationAnnouncementSubtitles { get; set; } = "PROTOCOL AZ-5 SUCCESSFULLY EXECUTED.";
    }
}