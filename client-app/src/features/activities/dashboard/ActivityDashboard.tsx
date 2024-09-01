/* eslint-disable react-refresh/only-export-components */
import { Grid } from 'semantic-ui-react';
import { Activity } from '../../../app/models/activity';
import ActivityList from './ActivityList';
import ActivityDetails from '../details/ActivityDetails';
import ActivityForm from '../form/ActivityForm';
import { useStore } from '../../../app/stores/store';
import { observer } from 'mobx-react-lite';

interface Props {
    activities: Activity[];
    createOrEdit: (activity: Activity) => void;
    deleteActivity: (id: string) => void;
    submitting: boolean;
}

export default observer( function ActivityDashboard( 
    { submitting, activities, createOrEdit, deleteActivity }: Props) {

    const { activityStore } = useStore(); 
    const { selectedActivity, editMode } = activityStore;

    return (
        <Grid>
            <Grid.Column width='10'>
                <ActivityList
                    activities={activities}
                    deleteActivity={deleteActivity}
                    submitting={submitting }
                />
            </Grid.Column>
            <Grid.Column width='6'>
                {selectedActivity && !editMode &&
                    <ActivityDetails/>}
                {editMode &&
                    <ActivityForm
                        submitting={submitting}
                        createOrEdit={createOrEdit} />}
            </Grid.Column>
        </Grid>
    )
})