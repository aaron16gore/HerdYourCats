<script lang="ts">
    import TopNavHeader from "$components/headers/TopNavHeader.svelte";
    import BaseDrawer from "$components/drawers/BaseDrawer.svelte";
    import TopNavMenuDropDown from "$components/drawers/TopNavMenuDropDown.svelte";
    import { onMount, getContext, setContext } from "svelte";
    import baseDrawerStore from "$stores/baseDrawerStore";
    import connection from "$services/signalr";
    import "@fortawesome/fontawesome-free/css/all.min.css";
    import PauseBackgroundOverlay from '$bcl/PauseBackgroundOverlay.svelte';

    let isBaseDrawerOpen: boolean = false;

    baseDrawerStore.subscribe((o) => {
        isBaseDrawerOpen = o;
    });

    let messages: string[] = [];
    let newMessage = "";

    const pauseOverlayIsActive: boolean = getContext('pause-overlay');

    setContext('pause-overlay', false);

    const sendMessage = async () => {
        if (newMessage.trim() !== "") {
            try {
                await connection.send("SendMessage", newMessage); // Use invoke instead of send
                newMessage = "";
            } catch (error) {
                console.error(error);
            }
        }
    };

    onMount(async () => {
        if (connection.state === "Disconnected") {
            try {
                await connection.start();
                console.log("Connection established.");
            } catch (error) {
                console.error("Error establishing connection:", error);
            }
        } else if (connection.state === "Connecting") {
            console.log("Connection is already connecting.");
        } else if (connection.state === "Connected") {
            console.log("Connection is already established.");
        }

        connection.on("ReceiveMessage", (message) => {
            messages = [...messages, message];
        });
    });
</script>

<html lang="en">
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, height=device-height, initial-scale=1.0" />
    <title>Herd Your Cats</title>
    <body>
        <header>
            <TopNavHeader />
        </header>
        <main>
            <!-- <BaseDrawer bind:isOpen={isBaseDrawerOpen}/> -->
            {#if pauseOverlayIsActive}
                <PauseBackgroundOverlay></PauseBackgroundOverlay>
            {/if}
            <slot />
        </main>
        <footer>
            
        </footer>
    </body>
</html>

<style lang="css">
    @import "./global-styles.css";

    :root {
        font-family: Arial, Helvetica, sans-serif;
        font-size: var(--hys-font-size);
    }

    main {
        margin-top: var(--top-nav-header-height);
        min-height: 100%;
        min-width: 100%;
        position: absolute;
        color: var(--hys-primary-color-1);
        background-color: var(--hys-primary-color-9);
        overflow: auto;
    }

    body {
        margin: 0;
        padding: 0;
        overflow: hidden;
    }
</style>
