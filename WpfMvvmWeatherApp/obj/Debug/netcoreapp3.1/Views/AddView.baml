   M S B A M L   `   `   `  ����L  HWpfMvvmWeatherApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:WpfMvvmWeatherApp.ViewsWpfMvvmWeatherApp.Views  5      d `Microsoft.Maps.MapControl.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35tRclr-namespace:Microsoft.Maps.MapControl.WPF;assembly=Microsoft.Maps.MapControl.WPFMicrosoft.Maps.MapControl.WPF 5      %    WpfMvvmWeatherApp.Views.AddView   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:WpfMvvmWeatherApp.Views     5      `mRclr-namespace:Microsoft.Maps.MapControl.WPF;assembly=Microsoft.Maps.MapControl.WPF     5      
�������$��20(�5	   J   .��5
      ]� .+�5   
   �� $	��Top=�6     �� TextAlignment$  Center=�6)   Add new location6R   A� 5   
   $��Bottom=�6    A� Rows$ 1��6.   .+�5      �� ��6   �� *	OkCommand+.��63   OK67   �� 5      ��6   �� *CancelCommand+.��67   Cancel6?   5      �� 5   
   $	��Top=�6   $��10q�6*   .+�5      	� -   5         	�Name$ NameRadioButton��5      $��0,20,0,0q�6T   $��Center=�6f    d� 	IsChecked 63   �� *
FindByName+.��6�   Find by city name6�   �� 5      
City name:6$   �� 5      -   5         ��Name$ CityNameTextBox��5      ��6/   �� *
CityName+ �� UpdateSourceTrigger$ PropertyChanged=� �� ValidatesOnDataErrors$
 True�� �� NotifyOnValidationError$
 True��{�6�   �� *
FindByName+6�   �� 5      
���  ��$��12(�6{   ��6   �� *%#(Validation.Errors)[0].ErrorContent+ �� ElementName$ CityNameTextBox��6{   	� 5      -   5        $ GeoRadioButton��5   B   $��0,20,0,0q�6Z   $��Center=�6l    6   �� *FindByGeolocation+.��6�   Find by geolocation6�   �� 5      	Latitude:6#   �� 5      -   5        $ LatitudeTextBox��5      ��6/   �� *
Latitude+$ PropertyChanged=�$
 True��$
 True��{�6�   �� *FindByGeolocation+6�   �� 5      
���  ��$��12(�6{   ��6   �� *%#(Validation.Errors)[0].ErrorContent+$ LatitudeTextBox��6{   �� 5      
Longitude:6$   �� 5      -   5        $ LongitudeTextBox��5      ��60   �� *	Longitude+$ PropertyChanged=�$
 True��$
 True��{�6�   �� *FindByGeolocation+6�   �� 5       
���  ��$��12(�6|   ��6   �� *%#(Validation.Errors)[0].ErrorContent+$ LongitudeTextBox��6|   5"      '  !Microsoft.Maps.MapControl.WPF.Map  5#   
   -   5        	  Name$		 Map��5$      $��10q�5'      +  %Microsoft.Maps.MapControl.WPF.MapCore
   CredentialsProviderT  NMicrosoft.Maps.MapControl.WPF.Design.ApplicationIdCredentialsProviderConverter$F
 @Agb4IZG_nCqXAevqb5vCb6vU_5hvV0mlxo9olIIhr-Ba0g3xx1tW_rZ_MdHDOAgK 5(      $��1��5)      $��0��5*      $��2��5+      {�5&      �� *FindByGeolocation+5-      5.      5/      