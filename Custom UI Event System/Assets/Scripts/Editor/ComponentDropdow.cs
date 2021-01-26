using UnityEditor.IMGUI.Controls;

class ComponentDropdow : AdvancedDropdown
{
    public ComponentDropdow(AdvancedDropdownState state) : base(state)
    {
    }

    protected override AdvancedDropdownItem BuildRoot()
    {
        var root = new AdvancedDropdownItem("Components");

        var firstHalf = new AdvancedDropdownItem("First half");
        var secondHalf = new AdvancedDropdownItem("Second half");
        var weekend = new AdvancedDropdownItem("Component");

        firstHalf.AddChild(new AdvancedDropdownItem("Component 1"));
        firstHalf.AddChild(new AdvancedDropdownItem("Component 2"));
        secondHalf.AddChild(new AdvancedDropdownItem("Component 3"));
        secondHalf.AddChild(new AdvancedDropdownItem("Component 4"));
        weekend.AddChild(new AdvancedDropdownItem("Component 5"));
        weekend.AddChild(new AdvancedDropdownItem("Component 6"));
        weekend.AddChild(new AdvancedDropdownItem("Component 7"));

        root.AddChild(firstHalf);
        root.AddChild(secondHalf);
        root.AddChild(weekend);

        return root;
    }
}
