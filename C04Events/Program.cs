using C04Events;

var pub = new EventPublisher(100);
var sub1 = new EventSubscriber();
var sub2 = new EventSubscriber();

pub.ValueHasChanged += sub1.OnValueChanged;
pub.ValueHasChanged += sub2.OnValueChanged;

for (int i = 0; i < 10; i++)
{
    pub.Value = i;
}

pub.ValueHasChanged -= sub1.OnValueChanged;

for (int i = 10; i < 20; i++)
{
    pub.Value = i;
}