# wpf-blazor-porting

Small demonstrator showing porting WPF to Blazor (Web Assembly). In this demonstrator we:

* Ported a simple calculator
* Mimick the WPF XAML grid system, button, textbox and textlist as a Razor Components
* Translate these to wrap to Blazorize
* Slightly alter the WPF code behind and XAML for proper databinding.

## Diff between XAMLS

```diff
-     <TextBox Height="28" HorizontalAlignment="Left" Margin="6,0,0,196" Name="textBox1" VerticalAlignment="Bottom" Width="188" IsReadOnly="True" HorizontalContentAlignment="Right" />
+     <ListBox Height="178" HorizontalAlignment="Left" Margin="6,40,0,0" Name="listBox1" VerticalAlignment="Top" Width="120" />
-     <TextBox Height="28" HorizontalAlignment="Left" Margin="6,0,0,196" @ref="textBox1" VerticalAlignment="Bottom" Width="188" IsReadOnly="True" HorizontalContentAlignment="Right"></TextBox>
+     <ListBox Height="178" HorizontalAlignment="Left" Margin="6,40,0,0" @ref="listBox1" VerticalAlignment="Top" Width="120" />
```

## Original XAML fragment

```XML
<Grid Height="230" HorizontalAlignment="Left" Margin="0,31,0,0" Name="grid2" VerticalAlignment="Top" Width="328">
    <TextBox Height="28" HorizontalAlignment="Left" Margin="6,0,0,196" Name="textBox1" VerticalAlignment="Bottom" Width="188" IsReadOnly="True" HorizontalContentAlignment="Right" />
    <ListBox Height="178" HorizontalAlignment="Left" Margin="6,40,0,0" Name="listBox1" VerticalAlignment="Top" Width="120" />
    <Grid Height="26" HorizontalAlignment="Left" Margin="200,8,0,0" Name="grid4" VerticalAlignment="Top" Width="122">
        <Button Content="+" Height="26" Name="add" VerticalAlignment="Top" Margin="0,0,96,0" Click="add_Click" />
        <Button Content="-" Height="26" HorizontalAlignment="Left" Margin="32,0,0,0" Name="minus" VerticalAlignment="Top" Width="26" Click="minus_Click" />
        <Button Content="x" Height="26" HorizontalAlignment="Left" Margin="64,0,0,0" Name="multiple" VerticalAlignment="Top" Width="26" Click="multiple_Click" />
        <Button Content="%" Height="26" HorizontalAlignment="Left" Margin="96,0,0,0" Name="divide" VerticalAlignment="Top" Width="26" Click="divide_Click" />
    </Grid>
    <Grid Height="190" HorizontalAlignment="Left" Margin="137,40,0,0" Name="grid3" VerticalAlignment="Top" Width="190">
        <Button Content="1" Height="40" HorizontalAlignment="Left" Name="one" VerticalAlignment="Top" Width="40" Click="one_Click" Margin="7,6,0,0" />
        <Button Content="2" Height="40" HorizontalAlignment="Left" Margin="53,6,0,0" Name="two" VerticalAlignment="Top" Width="40" Click="two_Click" />
        <Button Content="3" Height="40" HorizontalAlignment="Left" Margin="99,6,0,0" Name="three" VerticalAlignment="Top" Width="40" Click="three_Click" />
        <Button Content="C" Height="40" HorizontalAlignment="Left" Margin="145,6,0,0" Name="clearentry" VerticalAlignment="Top" Width="40" Click="clear_Click" />
        <Button Content="4" Height="40" HorizontalAlignment="Left" Margin="7,52,0,0" Name="four" VerticalAlignment="Top" Width="40" Click="four_Click" />
        <Button Content="5" Height="40" HorizontalAlignment="Left" Margin="53,52,0,0" Name="five" VerticalAlignment="Top" Width="40" Click="five_Click" />
        <Button Content="6" Height="40" HorizontalAlignment="Left" Margin="99,52,0,0" Name="six" VerticalAlignment="Top" Width="40" Click="six_Click" />
        <Button Content="7" Height="40" HorizontalAlignment="Left" Margin="7,98,0,0" Name="seven" VerticalAlignment="Top" Width="40" Click="seven_Click" />
        <Button Content="8" Height="40" HorizontalAlignment="Left" Margin="53,98,0,0" Name="eight" VerticalAlignment="Top" Width="40" Click="eight_Click" />
        <Button Content="CE" Height="40" HorizontalAlignment="Left" Margin="145,52,0,0" Name="clear" VerticalAlignment="Top" Width="40" Click="clearentry_Click" />
        <Button Content="Enter" Height="40" HorizontalAlignment="Left" Margin="99,144,0,0" Name="enter" VerticalAlignment="Top" Width="86" Click="enter_Click" />
        <Button Content="9" Height="40" HorizontalAlignment="Left" Margin="99,98,0,0" Name="nine" VerticalAlignment="Top" Width="40" Click="nine_Click" />
        <Button Content="+/-" Height="40" HorizontalAlignment="Left" Margin="145,98,0,0" Name="sign" VerticalAlignment="Top" Width="40" Click="sign_Click" />
        <Button Content="." Height="40" HorizontalAlignment="Left" Margin="7,144,0,0" Name="decipoint" VerticalAlignment="Top" Width="40" Click="decipoint_Click" />
        <Button Content="0" Height="40" HorizontalAlignment="Left" Margin="53,144,0,0" Name="nil" VerticalAlignment="Top" Width="40" Click="zero_Click" />
    </Grid>
</Grid>
```

## Converted XAML fragment

```XML
<Grid Height="230" HorizontalAlignment="Left" Margin="0,31,0,0" Name="grid2" VerticalAlignment="Top" Width="328">
    <TextBox Height="28" HorizontalAlignment="Left" Margin="6,0,0,196" @ref="textBox1" VerticalAlignment="Bottom" Width="188" IsReadOnly="True" HorizontalContentAlignment="Right"></TextBox>
    <ListBox Height="178" HorizontalAlignment="Left" Margin="6,40,0,0" @ref="listBox1" VerticalAlignment="Top" Width="120" />
    <Grid Height="26" HorizontalAlignment="Left" Margin="200,8,0,0" Name="grid4" VerticalAlignment="Top" Width="122">
        <Button Content="+" Height="26" Name="add" VerticalAlignment="Top" Margin="0,0,96,0" Click="add_Click" />
        <Button Content="-" Height="26" HorizontalAlignment="Left" Margin="32,0,0,0" Name="minus" VerticalAlignment="Top" Width="26" Click="minus_Click" />
        <Button Content="x" Height="26" HorizontalAlignment="Left" Margin="64,0,0,0" Name="multiple" VerticalAlignment="Top" Width="26" Click="multiple_Click" />
        <Button Content="%" Height="26" HorizontalAlignment="Left" Margin="96,0,0,0" Name="divide" VerticalAlignment="Top" Width="26" Click="divide_Click" />
    </Grid>
    <Grid Height="190" HorizontalAlignment="Left" Margin="137,40,0,0" Name="grid3" VerticalAlignment="Top" Width="190">
        <Button Content="1" Height="40" HorizontalAlignment="Left" Name="one" VerticalAlignment="Top" Width="40" Click="one_Click" Margin="7,6,0,0" />
        <Button Content="2" Height="40" HorizontalAlignment="Left" Margin="53,6,0,0" Name="two" VerticalAlignment="Top" Width="40" Click="two_Click" />
        <Button Content="3" Height="40" HorizontalAlignment="Left" Margin="99,6,0,0" Name="three" VerticalAlignment="Top" Width="40" Click="three_Click" />
        <Button Content="C" Height="40" HorizontalAlignment="Left" Margin="145,6,0,0" Name="clearentry" VerticalAlignment="Top" Width="40" Click="clear_Click" />
        <Button Content="4" Height="40" HorizontalAlignment="Left" Margin="7,52,0,0" Name="four" VerticalAlignment="Top" Width="40" Click="four_Click" />
        <Button Content="5" Height="40" HorizontalAlignment="Left" Margin="53,52,0,0" Name="five" VerticalAlignment="Top" Width="40" Click="five_Click" />
        <Button Content="6" Height="40" HorizontalAlignment="Left" Margin="99,52,0,0" Name="six" VerticalAlignment="Top" Width="40" Click="six_Click" />
        <Button Content="7" Height="40" HorizontalAlignment="Left" Margin="7,98,0,0" Name="seven" VerticalAlignment="Top" Width="40" Click="seven_Click" />
        <Button Content="8" Height="40" HorizontalAlignment="Left" Margin="53,98,0,0" Name="eight" VerticalAlignment="Top" Width="40" Click="eight_Click" />
        <Button Content="CE" Height="40" HorizontalAlignment="Left" Margin="145,52,0,0" Name="clear" VerticalAlignment="Top" Width="40" Click="clearentry_Click" />
        <Button Content="Enter" Height="40" HorizontalAlignment="Left" Margin="99,144,0,0" Name="enter" VerticalAlignment="Top" Width="86" Click="enter_Click" />
        <Button Content="9" Height="40" HorizontalAlignment="Left" Margin="99,98,0,0" Name="nine" VerticalAlignment="Top" Width="40" Click="nine_Click" />
        <Button Content="+/-" Height="40" HorizontalAlignment="Left" Margin="145,98,0,0" Name="sign" VerticalAlignment="Top" Width="40" Click="sign_Click" />
        <Button Content="." Height="40" HorizontalAlignment="Left" Margin="7,144,0,0" Name="decipoint" VerticalAlignment="Top" Width="40" Click="decipoint_Click" />
        <Button Content="0" Height="40" HorizontalAlignment="Left" Margin="53,144,0,0" Name="nil" VerticalAlignment="Top" Width="40" Click="zero_Click" />
    </Grid>
</Grid>
```

