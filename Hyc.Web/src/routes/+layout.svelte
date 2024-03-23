<script lang="ts">
    import TopNavHeader from "$components/headers/TopNavHeader.svelte";
    import BaseDrawer from "$components/drawers/BaseDrawer.svelte";
    import TopNavMenuDropDown from "$components/drawers/TopNavMenuDropDown.svelte";
    import { onMount, getContext } from "svelte";
    import baseDrawerStore from '$stores/baseDrawerStore';
    import connection from '$services/signalr';
    import '@fortawesome/fontawesome-free/css/all.min.css'

    let isBaseDrawerOpen: boolean = false;
    
    baseDrawerStore.subscribe((o) => {
		isBaseDrawerOpen = o;
	});

    let messages = [];
    let newMessage = '';

    const sendMessage = async () => {
        if (newMessage.trim() !== '') {
            try {
                await connection.send('SendMessage', newMessage); // Use invoke instead of send
                newMessage = '';
            } catch (error) {
                console.error(error);
            }
        }
    };

    onMount(async () => {
        if (connection.state === 'Disconnected') {
            try {
                await connection.start();
                console.log('Connection established.');
            } catch (error) {
                console.error('Error establishing connection:', error);
            }
        } else if (connection.state === 'Connecting') {
            console.log('Connection is already connecting.');
        } else if (connection.state === 'Connected') {
            console.log('Connection is already established.');
        }

        connection.on('ReceiveMessage', (message) => {
            messages = [...messages, message];
        });
    });

</script>

<style lang="css" src="./+layout.css">
   
</style>

<html lang="en">
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Herd Your Cats</title>
    <body>
        <header>
            <TopNavHeader />
        </header>
        <main>
            <!-- <BaseDrawer bind:isOpen={isBaseDrawerOpen}/> -->
            <TopNavMenuDropDown bind:isOpen={isBaseDrawerOpen}/>
            <div class="base-canvas-container">
                <slot></slot>
            </div>
        </main>
    </body>
</html>