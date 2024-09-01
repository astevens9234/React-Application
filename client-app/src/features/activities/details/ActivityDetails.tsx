import { Button, Card, CardContent, CardDescription, CardHeader, CardMeta, Image } from "semantic-ui-react";
import { useStore } from "../../../app/stores/store";
import LoadingComponent from "../../../app/layout/LoadingComponents";


export default function ActivityDetails() {

    const { activityStore } = useStore();
    const { selectedActivity: activity, openForm, cancelSelectedActivity } = activityStore;

    // We know that we have an activity before this code is reached
    // so this is a workaround to save errors.
    if (!activity) return <LoadingComponent/>;

    return (
        <Card fluid>
            <Image src={`./assets/categoryImages/${activity.category}.jpg`} />
            <CardContent>
                <CardHeader>{activity.title}</CardHeader>
                <CardMeta>
                    <span>{activity.date}</span>
                </CardMeta>
                <CardDescription>
                    {activity.description}
                </CardDescription>
            </CardContent>
            <CardContent extra>
                <Button.Group width='2'>
                    <Button onClick={() => openForm(activity.id)} basic color='blue' content='Edit' />
                    <Button onClick={cancelSelectedActivity} basic color='grey' content='Cancel' />
                </Button.Group>
            </CardContent>
        </Card>
    )
}