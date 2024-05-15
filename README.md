# Auto AZ-5
A highly customizable Auto-Alpha Warhead plugin. Makes the whole "you're about to die" experience just a little easier on the players. 
Keep in mind this IS my first plugin I publically made available so don't be afraid to open pull requests or issues.

## Default CONFIG:
```yml
auto_az5:
  is_enabled: true
  # In this case, debug will do next to nothing.
  debug: false
  # How long before the alpha-warhead detonates in seconds.
  auto_warhead_delay: 1200
  # [SET TO '' TO DISABLE] The CASSIE announcement right before the auto warhead is started (it delays the warhead engagement by how long the announcement is + [CassieWarningDelay]).
  auto_warhead_warning_cassie: 'PROTOCOL NATO_A NATO_Z 5 ACTIVATING . EVACUATE IMMEDIATELY'
  # [SET TO '' TO DISABLE] The CASSIE subtitles (translation, if you will).
  auto_warhead_warning_cassie_subtitles: 'PROTOCOL AZ-5 ACTIVATING... EVACUATE IMMEDIATELY.'
  # If the CASSIE announcement before engagement should override a current announcement
  auto_warhead_warning_cassie_overrides: true
  # The time difference between the CASSIE warning and the auto-warhead engaging
  cassie_warning_delay: 10
  # [SET TO '' TO DISABLE] The Broadcast displayed after warhead engagement
  warning_text: '<br><color=red><size=40><b>[ Alpha Warhead ]</b></size></color><br><size=25>The Automatic Alpha Warhead has been engaged.<br>This is inevitable and can <b><color=#f54266>NOT</color></b> be stopped.</size>'
  # How long the warning above should stay on their screens
  warning_duration: 6.5
  # [SET TO '' TO DISABLE] The CASSIE announcement right AFTER the auto warhead is detonated by AZ-5.
  successful_detonation_announcement: 'PROTOCOL NATO_A NATO_Z 5 SUCCESSFULLY EXECUTED'
  # [SET TO '' TO DISABLE] Subtitles for above.
  successful_detonation_announcement_subtitles: 'PROTOCOL AZ-5 SUCCESSFULLY EXECUTED.'
```

made with love by ASIGSEGV
